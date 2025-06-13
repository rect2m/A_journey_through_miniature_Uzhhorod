using HelixToolkit.Wpf;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    public partial class _3DModelView : Window
    {
        private bool isDragging = false;
        private System.Windows.Point lastMousePosition;
        private Model3D model;
        private double rotationSpeed = 0.5;
        private string tempModelDirectory;
        private ModelVisual3D modelVisual;

        public _3DModelView(string modelPath)
        {
            InitializeComponent();
            LoadModel(modelPath);
            CompositionTarget.Rendering += RotateCameraSmooth;
        }

        private async void LoadModel(string modelUrl)
        {
            var importer = new ModelImporter();
            try
            {
                LoadingOverlay.Visibility = Visibility.Visible;

                var sw = Stopwatch.StartNew();
                string localObjPath = await DownloadModelWithDependencies(modelUrl);

                model = await Dispatcher.InvokeAsync(() => importer.Load(localObjPath));
                modelVisual = new ModelVisual3D { Content = model };
                viewPort.Children.Add(modelVisual);
                AdjustCameraToModel(modelVisual);

                sw.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження моделі: {ex.Message}");
            }
            finally
            {
                LoadingOverlay.Visibility = Visibility.Collapsed;
            }
        }


        private static readonly HttpClient httpClient = new HttpClient();

        private async Task<string> DownloadModelWithDependencies(string objUrl)
        {
            string cacheRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureModels");
            string modelKey = Path.GetFileNameWithoutExtension(new Uri(objUrl).LocalPath);
            tempModelDirectory = Path.Combine(cacheRoot, modelKey);

            Directory.CreateDirectory(tempModelDirectory);

            string baseUri = objUrl.Substring(0, objUrl.LastIndexOf("/") + 1);
            string objFileName = Path.GetFileName(new Uri(objUrl).AbsolutePath);
            string objFile = Path.Combine(tempModelDirectory, objFileName);

            // ✅ Завантаження .obj з перевіркою кешу
            if (!File.Exists(objFile))
            {
                var objBytes = await httpClient.GetByteArrayAsync(objUrl);
                await File.WriteAllBytesAsync(objFile, objBytes);
            }

            // 🔍 Перевірка на .mtl
            string mtlFileName = File.ReadLines(objFile)
                .FirstOrDefault(l => l.StartsWith("mtllib "))?
                .Substring(7).Trim();

            if (!string.IsNullOrEmpty(mtlFileName))
            {
                string mtlUrl = baseUri + mtlFileName;
                string mtlFilePath = Path.Combine(tempModelDirectory, mtlFileName);

                if (!File.Exists(mtlFilePath))
                {
                    try
                    {
                        var mtlBytes = await httpClient.GetByteArrayAsync(mtlUrl);
                        await File.WriteAllBytesAsync(mtlFilePath, mtlBytes);
                    }
                    catch { }
                }

                if (File.Exists(mtlFilePath))
                {
                    var textureTasks = File.ReadLines(mtlFilePath)
                        .Where(l => l.StartsWith("map_"))
                        .Select(async line =>
                        {
                            string textureFile = line.Split(' ').Last().Trim();
                            string textureUrl = baseUri + textureFile;
                            string texturePath = Path.Combine(tempModelDirectory, textureFile);

                            if (!File.Exists(texturePath))
                            {
                                try
                                {
                                    var textureBytes = await httpClient.GetByteArrayAsync(textureUrl);
                                    await File.WriteAllBytesAsync(texturePath, textureBytes);
                                }
                                catch { }
                            }
                        });

                    await Task.WhenAll(textureTasks);
                }
            }

            return objFile;
        }


        private void AdjustCameraToModel(ModelVisual3D modelVisual)
        {
            if (modelVisual?.Content == null) return;

            Rect3D bounds = modelVisual.Content.Bounds;
            double maxSize = Math.Max(bounds.SizeX, Math.Max(bounds.SizeY, bounds.SizeZ));
            if (maxSize < 0.01) return;

            double distance = maxSize * 2.5;
            Point3D center = new Point3D(bounds.X + bounds.SizeX / 2, bounds.Y + bounds.SizeY / 2, bounds.Z + bounds.SizeZ / 2);

            mainCamera.Position = new Point3D(center.X, center.Y, center.Z + distance);
            mainCamera.LookDirection = new Vector3D(0, 0, -distance);
            mainCamera.UpDirection = new Vector3D(0, 1, 0);
        }

        private void RotateCameraSmooth(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                double angle = rotationSpeed;
                var axis = new Vector3D(0, 1, 0);

                var matrix = mainCamera.Transform.Value;
                var rotate = new RotateTransform3D(new AxisAngleRotation3D(axis, angle));
                matrix = Matrix3D.Multiply(matrix, rotate.Value);

                mainCamera.Transform = new MatrixTransform3D(matrix);
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                viewPort.Children.Clear();
                modelVisual = null;
                model = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // Позначити директорію для видалення
                if (!string.IsNullOrEmpty(tempModelDirectory) && Directory.Exists(tempModelDirectory))
                {
                    string marker = Path.Combine(tempModelDirectory, "delete_me.txt");
                    File.WriteAllText(marker, "mark for deletion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[OnClosed] Внутрішня помилка:\n{ex.Message}");
            }
        }
    }
}

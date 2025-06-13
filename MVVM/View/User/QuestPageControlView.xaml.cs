// QuestPageControlView.xaml.cs
using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    public partial class QuestPageControlView : UserControl
    {
        public QuestViewModel ViewModel { get; set; }

        private Point _lastMousePosition;
        private bool _isDragging = false;
        private double _scale = 1.0;

        public QuestPageControlView()
        {
            InitializeComponent();

            var context = App._host.Services.GetService(typeof(IAppDbContextFactory)) as IAppDbContextFactory;
            var questService = App._host.Services.GetService(typeof(QuestService)) as QuestService;

            if (context != null && questService != null)
            {
                ViewModel = new QuestViewModel(context, questService);
                DataContext = ViewModel;
            }
            else
            {
                MessageBox.Show("Не вдалося ініціалізувати ViewModel.");
            }

            this.Loaded += UserControl_Loaded;
            this.PreviewMouseWheel += Grid_MouseWheel;

            LanguageManager.LanguageChanged += () =>
            {
                ViewModel.BuildTree();
                RenderTree();
                CenterTree();
            };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.BuildTree();
            RenderTree();
            CenterTree();
        }

        private void RenderTree()
        {
            QuestCanvas.Children.Clear();

            foreach (var node in ViewModel.Nodes.SelectMany(Flatten))
            {
                //node.IsClickable = false; // Забороняємо взаємодію з квестами користувача

                var control = new QuestNode { DataContext = node };
                Canvas.SetLeft(control, node.X);
                Canvas.SetTop(control, node.Y);
                QuestCanvas.Children.Add(control);

                foreach (var child in node.Children)
                {
                    double radius = 50;
                    double dx = child.X - node.X;
                    double dy = child.Y - node.Y;
                    double angle = Math.Atan2(dy, dx);

                    double x1 = node.X + radius + Math.Cos(angle) * radius;
                    double y1 = node.Y + radius + Math.Sin(angle) * radius;
                    double x2 = child.X + radius - Math.Cos(angle) * radius;
                    double y2 = child.Y + radius - Math.Sin(angle) * radius;

                    var line = new Line
                    {
                        X1 = x1,
                        Y1 = y1,
                        X2 = x2,
                        Y2 = y2,
                        Stroke = node.IsCompleted ? Brushes.Green : Brushes.DarkGray,
                        StrokeThickness = 5
                    };

                    QuestCanvas.Children.Add(line);
                }
            }
        }

        private static IEnumerable<QuestNodeViewModel> Flatten(QuestNodeViewModel root)
        {
            yield return root;
            foreach (var child in root.Children.SelectMany(Flatten))
                yield return child;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lastMousePosition = e.GetPosition(this);
            _isDragging = true;
            Mouse.Capture((UIElement)sender);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                Point pos = e.GetPosition(this);
                Vector delta = pos - _lastMousePosition;

                CanvasTranslateTransform.X += delta.X;
                CanvasTranslateTransform.Y += delta.Y;

                _lastMousePosition = pos;
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            Mouse.Capture(null);
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double zoomDelta = e.Delta > 0 ? 0.1 : -0.1;
            AnimateZoom(zoomDelta, e.GetPosition(QuestCanvas));
            e.Handled = true;
        }

        private void AnimateZoom(double delta, Point pos)
        {
            double newScale = Math.Clamp(_scale + delta, 0.5, 1.0);
            if (Math.Abs(newScale - _scale) < 0.001) return;

            double offsetX = (pos.X - CanvasTranslateTransform.X) / _scale;
            double offsetY = (pos.Y - CanvasTranslateTransform.Y) / _scale;

            var animX = new DoubleAnimation(newScale, TimeSpan.FromMilliseconds(150))
            {
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
            };
            var animY = new DoubleAnimation(newScale, TimeSpan.FromMilliseconds(150))
            {
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut }
            };

            CanvasScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animX);
            CanvasScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animY);

            _scale = newScale;
            CanvasTranslateTransform.X = pos.X - offsetX * _scale;
            CanvasTranslateTransform.Y = pos.Y - offsetY * _scale;

            ZoomIndicator.Text = $"{(int)(_scale * 100)}%";
        }

        private void CenterTree_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(CenterTree, System.Windows.Threading.DispatcherPriority.Loaded);
        }

        private void CenterTree()
        {
            if (ViewModel.RootNode != null)
            {
                double nodeCenterX = ViewModel.RootNode.X + 50;
                double nodeCenterY = ViewModel.RootNode.Y + 50;

                double viewerWidth = ScrollViewer.ViewportWidth > 0 ? ScrollViewer.ViewportWidth : ScrollViewer.ActualWidth;
                double viewerHeight = ScrollViewer.ViewportHeight > 0 ? ScrollViewer.ViewportHeight : ScrollViewer.ActualHeight;

                CanvasTranslateTransform.X = (viewerWidth / 2.0 - nodeCenterX * _scale);
                CanvasTranslateTransform.Y = (viewerHeight / 2.0 - nodeCenterY * _scale);
            }
        }
    }
}

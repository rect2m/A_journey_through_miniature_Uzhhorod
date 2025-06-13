using FontAwesome.Sharp;
using System.ComponentModel;
using System.Windows.Media;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class QuestNodeViewModel : INotifyPropertyChanged
    {
        public int QuestId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";

        public string IconName { get; set; } = "Question";
        public IconChar Icon => Enum.TryParse(IconName, out IconChar icon) ? icon : IconChar.Question;

        private int _progress;
        public int Progress
        {
            get => _progress;
            set => SetProgress(value);
        }

        private int _targetCount;
        public int TargetCount
        {
            get => _targetCount;
            set
            {
                _targetCount = value;
                OnPropertyChanged(nameof(TargetCount));
                OnPropertyChanged(nameof(ProgressText));
                OnPropertyChanged(nameof(ProgressArc));
            }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
                OnPropertyChanged(nameof(BackgroundStroke));
                OnPropertyChanged(nameof(ProgressArc));
                OnPropertyChanged(nameof(ProgressStroke));
            }
        }

        public bool IsAvailable => Progress > 0 || IsCompleted;

        public bool IsActive { get; set; }

        public string ProgressText => $"{Progress}/{TargetCount}";

        public Brush ProgressStroke => IsCompleted || Progress > 0 ? Brushes.Green : Brushes.Transparent;

        public Brush BackgroundStroke =>
            IsCompleted ? Brushes.Green :
            Progress > 0 ? Brushes.White : Brushes.DarkGray;

        public Geometry ProgressArc
        {
            get
            {
                if (TargetCount == 0 || Progress == 0) return Geometry.Empty;

                double percentage = Math.Min(1.0, (double)Progress / TargetCount);
                double angle = percentage * 360.0;
                double radius = 48;
                double centerX = 50, centerY = 50;
                double startAngle = -90;
                double endAngle = startAngle + angle;

                double startX = centerX + radius * Math.Cos(startAngle * Math.PI / 180);
                double startY = centerY + radius * Math.Sin(startAngle * Math.PI / 180);
                double endX = centerX + radius * Math.Cos(endAngle * Math.PI / 180);
                double endY = centerY + radius * Math.Sin(endAngle * Math.PI / 180);
                bool isLargeArc = angle > 180;

                var geometry = new StreamGeometry();
                using (var ctx = geometry.Open())
                {
                    ctx.BeginFigure(new System.Windows.Point(startX, startY), false, false);
                    ctx.ArcTo(
                        new System.Windows.Point(endX, endY),
                        new System.Windows.Size(radius, radius),
                        0,
                        isLargeArc,
                        SweepDirection.Clockwise,
                        true,
                        false);
                }

                geometry.Freeze();
                return geometry;
            }
        }

        public double X { get; set; }
        public double Y { get; set; }

        public List<QuestNodeViewModel> Children { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void SetProgress(int value)
        {
            _progress = value;
            OnPropertyChanged(nameof(Progress));
            OnPropertyChanged(nameof(ProgressText));
            OnPropertyChanged(nameof(ProgressArc));
            OnPropertyChanged(nameof(ProgressStroke));
            OnPropertyChanged(nameof(BackgroundStroke));
        }
    }
}

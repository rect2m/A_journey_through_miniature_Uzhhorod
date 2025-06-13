using A_journey_through_miniature_Uzhhorod.MVVM.View;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Notification
{
    public class ToastManager
    {
        private Grid? _container;

        public void SetContainer(Grid container)
        {
            _container = container;
        }

        public void ShowToast(string title, string description, string iconPath)
        {
            if (_container == null) return;

            Application.Current.Dispatcher.Invoke(() =>
            {
                var toast = new ToastNotificationControl
                {
                    DataContext = new
                    {
                        Title = title,
                        Description = description,
                        IconPath = iconPath
                    }
                };

                toast.Opacity = 0;
                toast.HorizontalAlignment = HorizontalAlignment.Right;
                toast.VerticalAlignment = VerticalAlignment.Bottom;

                _container.Children.Add(toast);
                try
                {
                    var player = new SoundPlayer("Resources/toast.wav");
                    player.Load();
                    player.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка звуку: " + ex.Message);
                }

                var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
                var stay = new DoubleAnimation(1, 1, TimeSpan.FromSeconds(2)) { BeginTime = TimeSpan.FromSeconds(0.5) };
                var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5)) { BeginTime = TimeSpan.FromSeconds(2.5) };

                var sb = new Storyboard();
                sb.Children.Add(fadeIn);
                sb.Children.Add(stay);
                sb.Children.Add(fadeOut);
                Storyboard.SetTarget(fadeIn, toast);
                Storyboard.SetTarget(stay, toast);
                Storyboard.SetTarget(fadeOut, toast);
                Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));
                Storyboard.SetTargetProperty(stay, new PropertyPath("Opacity"));
                Storyboard.SetTargetProperty(fadeOut, new PropertyPath("Opacity"));

                sb.Completed += (s, e) => _container.Children.Remove(toast);
                sb.Begin();
            });
        }

    }

}

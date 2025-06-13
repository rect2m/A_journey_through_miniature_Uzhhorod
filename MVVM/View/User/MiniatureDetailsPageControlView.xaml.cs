
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    /// <summary>
    /// Interaction logic for MiniatureDetailsPageControlView.xaml
    /// </summary>
    public partial class MiniatureDetailsPageControlView : UserControl
    {
        public MiniatureDetailsPageControlView()
        {
            InitializeComponent();
        }

        private void StarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button hoveredButton && StarPanel != null)
            {
                int starIndex = int.Parse(hoveredButton.Tag.ToString());

                foreach (var child in StarPanel.Children)
                {
                    if (child is Button btn && int.Parse(btn.Tag.ToString()) <= starIndex)
                    {
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC047")); // Зміна Tag
                    }
                }
            }
        }

        private void StarButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (StarPanel != null)
            {
                foreach (var child in StarPanel.Children)
                {
                    if (child is Button btn)
                    {
                        btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9497CD")); // Повернення до стандартного кольору
                    }
                }
            }
        }


    }
}

using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    public partial class HomePageControlView : UserControl
    {
        public HomePageControlView()
        {
            InitializeComponent();
        }

        private void MiniatureButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо мініатюру з параметра
            if (sender is Button button && button.Tag is MiniaturesViewModel.MiniatureViewModel selectedMiniature)
            {
                // Отримуємо ViewModel
                if (DataContext is HomeViewModel homeViewModel)
                {
                    homeViewModel.NavigateToMiniature(selectedMiniature);
                }
            }
        }
    }
}

using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    /// <summary>
    /// Interaction logic for PersonalOfficePageControlView.xaml
    /// </summary>
    public partial class PersonalOfficePageControlView : UserControl
    {
        public bool validUsername = true;
        public bool validEmail = true;
        public bool validPassword = true;

        public PersonalOfficePageControlView()
        {
            InitializeComponent();
        }

        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PersonalOfficeViewModel viewModel)
            {
                viewModel.NewPassword = ((PasswordBox)sender).Password;
            }
        }

        private void OldPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PersonalOfficeViewModel viewModel)
            {
                viewModel.OldPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}

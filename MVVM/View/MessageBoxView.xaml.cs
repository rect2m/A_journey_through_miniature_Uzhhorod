using System.Windows;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    /// <summary>
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public static bool buttonYesClicked = false;
        public static bool buttonOkClicked = false;
        public static bool buttonNoClicked = false;

        public MessageBoxView()
        {
            InitializeComponent();

            MessageBoxTextBox.Visibility = Visibility.Hidden;
            MessageBoxPasswordBox.Visibility = Visibility.Hidden;
        }

        public void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            buttonNoClicked = true;
            Window message = Window.GetWindow(this);
            // Закрити вікно
            message.Close();
        }

        public void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            buttonYesClicked = true;
            Window message = Window.GetWindow(this);

            // Закрити вікно
            message.Close();
        }

        public void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            buttonOkClicked = true;
            Window message = Window.GetWindow(this);

            // Закрити вікно
            message.Close();
        }
    }
}

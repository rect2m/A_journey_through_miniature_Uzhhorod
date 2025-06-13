using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View.Admin
{
    public partial class EditEventsPageControlView : UserControl
    {
        public EditEventsPageControlView()
        {
            InitializeComponent();
        }

        private static readonly Regex UkrainianCharsRegex = new("[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ]", RegexOptions.Compiled);

        private void TextBox_PreviewTextInputLanguageRestricted(object sender, TextCompositionEventArgs e)
        {
            if (DataContext is EditEventsViewModel vm && vm.SelectedLanguage == "en")
            {
                if (UkrainianCharsRegex.IsMatch(e.Text))
                {
                    e.Handled = true; // Заборонити введення
                }
            }
        }
    }
}

using System.Windows.Controls;

namespace Polia02.Views
{
    public partial class RegisterView : UserControl
    {
        private RegisterViewModel _registerViewModel;

        public RegisterView()
        {
            InitializeComponent();
            _registerViewModel = new RegisterViewModel();
            DataContext = _registerViewModel;
        }
    }
}

using System.Windows;

namespace Polia02.Views
{
    public partial class RegisterView : Window
    {
        private RegisterViewModel _registerViewModel;
        private EditViewModel _editViewModel;

        public enum Mode { Add, Edit }

        public RegisterView(Mode mode = Mode.Add, Person p = null)
        {
            InitializeComponent();
            if(mode == Mode.Edit)
            {
                _editViewModel = new EditViewModel(p);
                DataContext = _editViewModel;
            }
            else
            {
                _registerViewModel = new RegisterViewModel();
                DataContext = _registerViewModel;
            }
        }
    }
}

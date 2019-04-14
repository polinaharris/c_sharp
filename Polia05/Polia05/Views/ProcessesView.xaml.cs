using System.Windows;
using System.Windows.Controls;

namespace Polia05
{
    public partial class ProcessesView : Window
    {
        private ProcessesViewModel _processesViewModel;

        public ProcessesView()
        {
            InitializeComponent();
            _processesViewModel = new ProcessesViewModel(delegate () { Dispatcher.Invoke(ProcessesDataGrid.Items.Refresh); });
            DataContext = _processesViewModel;
            //_processesViewModel.Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var id = button.CommandParameter;
            _processesViewModel.KillCommand(id);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var id = button.CommandParameter;
            _processesViewModel.OpenFolder(id);
        }
    }
}

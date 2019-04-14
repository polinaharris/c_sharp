using System;
using System.ComponentModel;
using System.Windows;

namespace Polia02
{
    /// <summary>
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : Window
    {
        public InfoView(Person person)
        {
            InitializeComponent();
            DataContext = new InfoViewModel(person);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }

        public void SetPerson(Person person)
        {
            InitializeComponent();
            InfoViewModel vm = (InfoViewModel)DataContext;
            vm.SetPerson(person);
        }
    }
}

using Polia02.Managers;
using Polia02.Models;
using Polia02.Windows;
using System.Windows;

namespace Polia02
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ContentWindow contentWindow = new ContentWindow();
            NavigationModel navigationModel = new NavigationModel(contentWindow);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate(ModesEnum.Register);
        }
    }
}

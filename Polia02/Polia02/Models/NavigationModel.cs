using Polia02.Managers;
using Polia02.Views;
using Polia02.Windows;
using System;

namespace Polia02.Models
{
    public enum ModesEnum
    {
        Info,
        Register
    }

    public class NavigationModel
    {
        private ContentWindow _contentWindow;  
        private InfoView _infoView;
        private RegisterView _registerView;

        public NavigationModel(ContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
            _registerView = new RegisterView();
            _infoView = new InfoView();
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Info:
                    //((InfoViewModel)_infoView.DataContext).Person = PersonManager.Person;
                    _contentWindow.ContentControl.Content = _infoView;
                    break;
                case ModesEnum.Register:
                    _contentWindow.ContentControl.Content = _registerView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}

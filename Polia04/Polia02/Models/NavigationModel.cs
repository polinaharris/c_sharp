using Polia02.Views;
using Polia02.Windows;
using System;

namespace Polia02.Models
{
    public enum ModesEnum
    {
        Info   
    }

    public class NavigationModel
    {
        private ContentWindow _contentWindow;  
        private InfoView _infoView;

        public NavigationModel(ContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
            _infoView = new InfoView();
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Info:
                    _contentWindow.ContentControl.Content = _infoView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}

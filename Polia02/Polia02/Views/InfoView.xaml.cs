﻿using Polia02.Managers;
using System.Windows.Controls;

namespace Polia02.Views
{
    public partial class InfoView : UserControl
    {
        private InfoViewModel _infoViewModel;

        public InfoView()
        {
            InitializeComponent();
            _infoViewModel = new InfoViewModel();
            PersonManager.InfoViewModel = _infoViewModel;
            DataContext = _infoViewModel;
        }
    }
}

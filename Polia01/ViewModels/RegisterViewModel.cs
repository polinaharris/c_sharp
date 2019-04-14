using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using JetBrains.Annotations;

namespace Polia01
{
    class RegisterViewModel : INotifyPropertyChanged
    {
    
        private DateTime _birthday = DateTime.Today;
        private RelayCommand _signInCommand;
        private InfoView _infoView;

       

        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public string BirthdayText { get; set; }

        internal RegisterViewModel()
        {

        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand(RegisterPerson, o => 
                                
                                !string.IsNullOrWhiteSpace(BirthdayText)));
            }
        }

        private async void RegisterPerson(object o)
        {
            Person person = null;
            await Task.Run(() =>
            {
                person = new Person(_birthday);
            });
            if(_infoView == null)
            {
                _infoView = new InfoView(person);
            }
            else
            {
                _infoView.SetPerson(person);
            }

           
            _infoView.Show();
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using JetBrains.Annotations;

namespace Polia02
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday = DateTime.Today;
        private RelayCommand _signInCommand;
        private InfoView _infoView;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

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
                                !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_surname) &&
                                !string.IsNullOrWhiteSpace(_email) &&
                                !string.IsNullOrWhiteSpace(BirthdayText)));
            }
        }

        private async void RegisterPerson(object o)
        {
            Person person = null;
            await Task.Run(() =>
            {
                person = new Person(_name, _surname, _email, _birthday);
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
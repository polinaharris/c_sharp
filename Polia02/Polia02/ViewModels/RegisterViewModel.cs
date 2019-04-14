using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Polia02.Managers;
using Polia02.Models;

namespace Polia02
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday = DateTime.Today;
        private RelayCommand _signInCommand;

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

        public RelayCommand RegisterCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand(RegisterPerson, o => RegisterCanExecute()));
            }
        }

        public RegisterViewModel()
        {

        }

        private async void RegisterPerson(object o)
        {
            await Task.Run(() =>
            {
                PersonManager.Update(new Person(_name, _surname, _email, _birthday));
            });
            NavigationManager.Instance.Navigate(ModesEnum.Info);
        }


        private bool RegisterCanExecute()
        {
            return !string.IsNullOrWhiteSpace(_name) &&
                    !string.IsNullOrWhiteSpace(_surname) &&
                    !string.IsNullOrWhiteSpace(_email) &&
                    !string.IsNullOrWhiteSpace(BirthdayText);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
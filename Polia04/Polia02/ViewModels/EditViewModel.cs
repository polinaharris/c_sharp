using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using JetBrains.Annotations;
using Polia02.Managers;

namespace Polia02
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday = DateTime.Today;
        private RelayCommand _editCommand;
        private Person _person;

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
                return _editCommand ?? (_editCommand = new RelayCommand(EditCommand, o => RegisterCanExecute()));
            }
        }

        public EditViewModel(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            Birthday = person.Birthday;
            _person = person;
        }

        private void EditCommand(object o)
        {
            try
            {
                PersonManager.UpdateUser(_person, new Person(Name, Surname, Email, Birthday));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            return;
            }
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
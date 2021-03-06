﻿using JetBrains.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Polia02
{
    public class InfoViewModel : INotifyPropertyChanged
    {
        private Person _person;
        public string Name => _person.Name;
        public string Surname => _person.Surname;
        public string Email => _person.Email;
        public string Birthday => _person.Birthday.ToShortDateString();
        public string IsAdult => $"{(_person.IsAdult ? "" : "not ")}adult";
        public string IsBirthday => $"Today is {(_person.IsBirthday ? "" : "not ")}your birthday";
        public string SunSign => _person.SunSign.ToString();
        public string ChineseSign => _person.ChineseSign.ToString();

        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged(null);
            }
        }


        public InfoViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

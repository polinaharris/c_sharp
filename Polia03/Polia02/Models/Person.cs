using Polia02.Exceptions;
using Polia02.Tools;
using System;

namespace Polia02
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private  DateTime _birthday;

        private readonly ChineseSign _chineseSign;
        private readonly SunSign _sunSign;

        public string Name {  get;  private set; }

        public string Surname { get; private set; }

        public string Email { get;  private set; }

        public DateTime Birthday { get;  private set; }


        public bool IsAdult
        {
            get
            {
                return (DateTime.Today - Birthday).TotalDays / 365 >= 18;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return DateTime.Today.DayOfYear == Birthday.DayOfYear;
            }
        }

        public ChineseSign ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        public SunSign SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            if (EmailValidator.ValidateEmail(email))
            {
                throw new InvalidEmailException(email);
            }

            var yearsDif = (DateTime.Today - birthday).TotalDays / 365;
            if (yearsDif < 0 || yearsDif > 120)
            {
                throw new InvalidBirthdayException(birthday);
            }

            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;

            _sunSign = ZodiacHelper.GetSunSign(Birthday);
            _chineseSign = ZodiacHelper.GetChineseSign(Birthday);
        }

        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today)
        {

        }

        public Person(string name, string surname, DateTime birthday) : this(name, surname, "", birthday)
        {

        }
    }
}

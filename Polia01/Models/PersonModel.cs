using Polia01.Tools;
using System;

namespace Polia01
{
    public class Person
    {
        private DateTime _birthday;

        private readonly ChineseSign _chineseSign;
        private readonly SunSign _sunSign;

        public DateTime Birthday
        {
            get => _birthday;
            private set => _birthday = value;
        }


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

        public Person(DateTime birthday)
        {
            Birthday = birthday;

            _sunSign = ZodiacHelper.GetSunSign(Birthday);
            _chineseSign = ZodiacHelper.GetChineseSign(Birthday);
        }
    }
}


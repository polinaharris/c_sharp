using System;

namespace Polia02.Tools
{
    public enum SunSign
    {
        Ram, Bull, Twins, Crab, Lion, Virgin, Scales, Scorpion, Archer, MountainSeaGoat, WaterBearer, Fish
    }

    public enum ChineseSign
    {
        Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey, Rooster, Dog, Pig
    }

    internal static class ZodiacHelper
    {
        internal static SunSign GetSunSign(DateTime birthday)
        {
            switch (birthday.Month)
            {
                case 1:
                    return (SunSign)(birthday.Day <= 20 ? 9 : 10);
                case 2:
                    return (SunSign)(birthday.Day <= 19 ? 10 : 11);
                case 3:
                    return (SunSign)(birthday.Day <= 20 ? 11 : 0);
                case 4:
                    return (SunSign)(birthday.Day <= 20 ? 0 : 1);
                case 5:
                    return (SunSign)(birthday.Day <= 20 ? 1 : 2);
                case 6:
                    return (SunSign)(birthday.Day <= 20 ? 2 : 3);
                case 7:
                    return (SunSign)(birthday.Day <= 21 ? 3 : 4);
                case 8:
                    return (SunSign)(birthday.Day <= 22 ? 4 : 5);
                case 9:
                    return (SunSign)(birthday.Day <= 21 ? 5 : 6);
                case 10:
                    return (SunSign)(birthday.Day <= 21 ? 6 : 7);
                case 11:
                    return (SunSign)(birthday.Day <= 21 ? 7 : 8);
                case 12:
                    return (SunSign)(birthday.Day <= 21 ? 8 : 9);
                default:
                    throw new Exception("Wrong birthday date");
            }
        }

        internal static ChineseSign GetChineseSign(DateTime birthday)
        {
            return (ChineseSign)((birthday.Year + 8) % 12);
        }
    }
}

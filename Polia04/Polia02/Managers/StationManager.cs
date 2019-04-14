using Polia02.Tools;
using System;
using System.Collections.Generic;

namespace Polia02.Managers
{
    internal static class StationManager
    {
        private static readonly string[] Names = { "Barrett", "Shaffer", "Curry", "Banks", "Caldwell", "Aguirre", "Hurley", "Morgan", "Atkinson", "Dodson", "Bowers", "Diaz", "Payne", "James", "Dean", "Sweeney", "Buchanan", "Foley", "Acevedo", "Salas", "Livingston", "Benitez", "Carney", "Pollard", "Miles", "Key", "Weiss", "Baxter", "Potts", "Mullen", "Wheeler", "Hudson", "Hoover", "Glenn", "Sims", "Avery", "Randolph", "Newman", "Krause", "Middleton", "Morris", "Santos", "Sheppard", "Spears", "Greene", "Frederick", "Greer", "Johnson", "Stark", "Cochran" };
        private static readonly string[] Surnames = { "Moody", "Nixon", "Mckay", "Herman", "Brooks", "Herrera", "Cordova", "Esparza", "Mora", "Garner", "Prince", "Hampton", "Barker", "Armstrong", "Rosales", "Myers", "Burton", "Fry", "Nguyen", "Everett", "Duran", "Mueller", "Silva", "Bolton", "Odom", "Cooper", "Stark", "Oconnor", "Hendricks", "Acosta", "Black", "Moore", "Holder", "Owen", "Atkinson", "Dawson", "Vang", "Rogers", "Carney", "Oliver", "Pittman", "Weeks", "Peters", "Foley", "Hodges", "Tran", "Hudson", "Pennington", "Pierce", "Pitts" };
        internal static List<Person> CurrentUsers { get; set; } = new List<Person>();

        internal static void SaveUsers()
        {
            SerializationManager.Serialize(CurrentUsers, FileFolderHelper.LastUserFilePath);
        }

        public static void LoadUsers()
        {
            if (FileFolderHelper.FileExists(FileFolderHelper.LastUserFilePath))
            {
                CurrentUsers = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.LastUserFilePath);
            }
            else
            {
                var random = new Random();

                for (var i = 0; i < 50; ++i)
                {
                    var name = Names[random.Next(Names.Length)];
                    var surname = Surnames[random.Next(Surnames.Length)];
                    CurrentUsers.Add(new Person(name, surname, $"{name}.{surname}@gmail.com", DateTime.Now.AddYears(-random.Next(10, 80)).AddDays(-random.Next(31)).AddMonths(-random.Next(12))));
                }
            }
        }

        public static void RemoveUser(Person selectedUser)
        {
            CurrentUsers.Remove(selectedUser);
        }
    }
}

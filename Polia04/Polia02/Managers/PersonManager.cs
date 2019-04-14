
namespace Polia02.Managers
{
    public class PersonManager
    {
        public static InfoViewModel InfoViewModel { get; set; }

        public static void AddUser(Person person)
        {
            StationManager.CurrentUsers.Add(person);
            InfoViewModel.PersonsList = StationManager.CurrentUsers;
            InfoViewModel.RefreshPersonsAction();
        }

        public static void UpdateUser(Person person, Person copy)
        {
            var per = StationManager.CurrentUsers.Find(p => person == p);
            per.Name = copy.Name;
            per.Surname = copy.Surname;
            per.Email = copy.Email;
            per.Birthday = copy.Birthday;

            InfoViewModel.PersonsList = StationManager.CurrentUsers;
            InfoViewModel.RefreshPersonsAction();
        }
    }
}

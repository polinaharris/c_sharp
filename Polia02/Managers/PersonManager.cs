namespace Polia02.Managers
{
    public class PersonManager
    {
        public static InfoViewModel InfoViewModel { get; set; }

        public static void Update(Person person)
        {
            InfoViewModel.Person = person;
        }
    }
}

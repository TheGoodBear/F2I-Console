namespace ProjetsFormation
{
    public class Person
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public int BirthYear { get; set; }



        public Person(
            string LastName,
            string FirstName,
            string Sex,
            int BirthYear)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Sex = Sex;
            this.BirthYear = BirthYear;
        }
    }
}

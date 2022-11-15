namespace FileManagement
{
    public class Person
    {

        public enum eITLevel
        {
            Débutant,
            Intermédiaire,
            Avancé
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public int BirthYear { get; set; }
        public eITLevel ITLevel { get; set; }
        public int GroupNumber { get; set; }



        public Person(
            string LastName,
            string FirstName,
            string Sex,
            int BirthYear,
            eITLevel ITLevel,
            int GroupNumber)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Sex = Sex;
            this.BirthYear = BirthYear;
            this.ITLevel = ITLevel;
            this.GroupNumber = GroupNumber;
        }
    }
}

namespace FileManagement
{
    public class Person
    {

        public enum eSex
        {
            Féminin,
            Masculin,
            Autre
        }
        public enum eITLevel
        {
            Débutant,
            Intermédiaire,
            Avancé
        }
        public enum eTechnology
        {
            None,
            ASPNetMVC,
            MAUI,
            UWP
        }
        public enum eLocation
        {
            Présentiel,
            Distanciel
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public eSex Sex { get; set; }
        public int BirthYear { get; set; }
        public eITLevel ITLevel { get; set; }
        public eLocation Location { get; set; }
        public int GroupNumber { get; set; }
        public string ProjectName { get; set; }
        public eTechnology Technology { get; set; }
        public int Age => DateTime.Now.Year - BirthYear;


        public Person(
            string LastName,
            string FirstName,
            eSex Sex,
            int BirthYear,
            eITLevel ITLevel,
            eLocation Location,
            int GroupNumber,
            string ProjectName,
            eTechnology Technology)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Sex = Sex;
            this.BirthYear = BirthYear;
            this.ITLevel = ITLevel;
            this.Location = Location;
            this.GroupNumber = GroupNumber;
            this.ProjectName = ProjectName;
            this.Technology = Technology;
        }
    }
}

namespace ProjetsFormation.Models
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
        public enum eLocation
        {
            Présentiel,
            Distanciel
        }

        // raed/write (get/set) properties
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public eSex Sex { get; set; }
        public int BirthYear { get; set; }
        public eITLevel ITLevel { get; set; }
        public eLocation Location { get; set; }
        public int IdGroup { get; set; }

        // read only (get) properties
        public int Age => DateTime.Now.Year - BirthYear;


        public Person(
            string LastName,
            string FirstName,
            eSex Sex,
            int BirthYear,
            eITLevel ITLevel,
            eLocation Location,
            int IdGroup)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Sex = Sex;
            this.BirthYear = BirthYear;
            this.ITLevel = ITLevel;
            this.Location = Location;
            this.IdGroup = IdGroup;
        }
        public Person(
            string[] Data)
        {
            this.LastName = Data[0];
            this.FirstName = Data[1];
            this.Sex = (eSex)Convert.ToInt32(Data[2]);
            this.BirthYear = Convert.ToInt32(Data[3]);
            this.ITLevel = (eITLevel)Convert.ToInt32(Data[4]);
            this.Location = (eLocation)Convert.ToInt32(Data[5]);
            this.IdGroup = Convert.ToInt32(Data[6]);
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}

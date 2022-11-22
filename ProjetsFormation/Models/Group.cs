namespace ProjetsFormation.Models
{
    public class Group
    {
        public enum eTechnology
        {
            None,
            ASPNetMVC,
            MAUI,
            UWP
        }

        // raed/write (get/set) properties
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public eTechnology Technology { get; set; }
        public int IdProject { get; set; }

        // read only (get) properties


        public Group(
            int Number,
            string Name,
            eTechnology Technology,
            int IdProject)
        {
            this.Number = Number;
            this.Name = Name;
            this.Technology = Technology;
            this.IdProject = IdProject;
        }
        public Group(
            string[] Data)
        {
            this.Number = Convert.ToInt32(Data[0]);
            this.Name = Data[1];
            this.Technology = (eTechnology)Convert.ToInt32(Data[2]);
            this.IdProject = Convert.ToInt32(Data[3]);
        }

        public override string ToString()
        {
            return $"({Number}) {Name}";
        }

    }
}

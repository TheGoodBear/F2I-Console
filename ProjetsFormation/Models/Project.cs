namespace ProjetsFormation.Models
{
    public class Project

    {

        // read/write (get/set) properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // read only (get) properties


        public Project(
            string Name,
            string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
        public Project(
            string[] Data)
        {
            this.Name = Data[0];
            this.Description = Data[1];
        }


        public override string ToString()
        {
            return $"{Name}";
        }

    }
}

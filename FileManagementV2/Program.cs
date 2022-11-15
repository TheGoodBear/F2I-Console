using System.Text;

namespace FileManagement
{
    internal class Program
    {

        public static string FilePath =
            "C:\\Users\\FORMATEUR\\Documents\\F2I\\";
        public static string FileName =
            "FileManagement1.csv";
        public static List<Person> Persons = new List<Person>();
        public static List<Person> Students = new List<Person>();


        public static void Main()
        {
            InitializeData();
            WriteFile(FilePath, FileName, Persons);
            ReadFile(FilePath, FileName);
            ListData(Students);
        }


        public static void WriteFile(
            string FilePath,
            string FileName,
            List<Person> Data)
        {

            using StreamWriter? MyStream = new StreamWriter(
                FilePath + FileName,
                false,
                Encoding.UTF8);
            {
                foreach (Person CurrentPerson in Data)
                {
                    MyStream.WriteLine(
                        $"{CurrentPerson.LastName};" +
                        $"{CurrentPerson.FirstName};" +
                        $"{CurrentPerson.Sex};" +
                        $"{CurrentPerson.BirthYear};" +
                        $"{(int)CurrentPerson.ITLevel};" +
                        $"{CurrentPerson.GroupNumber}");
                }
            }

            Console.WriteLine($"Le fichier {FileName} a été écrit.\n");

        }


        public static void ReadFile(
            string FilePath,
            string FileName)
        {

            using StreamReader? MyStream = new StreamReader(FilePath + FileName);
            {
                string Result = MyStream.ReadLine();
                while (Result != null)
                {
                    string[] StudentData = Result.Split(";");
                    Students.Add(new Person(
                        StudentData[0],
                        StudentData[1],
                        StudentData[2],
                        Convert.ToInt32(StudentData[3]),
                        (Person.eITLevel)Convert.ToInt32(StudentData[4]),
                        Convert.ToInt32(StudentData[5])));
                    Result = MyStream.ReadLine();
                }
            }

            Console.WriteLine($"Le fichier {FileName} a été lu.\n");
        }


        private static void ListData(List<Person> MyList)
        {
            MyList = MyList
                .OrderBy(S => S.LastName)
                .OrderBy(S => (int)S.ITLevel).ToList();

            foreach (Person CurrentPerson in MyList)
            {
                Console.WriteLine(
                    $"{CurrentPerson.FirstName} " +
                    $"{CurrentPerson.LastName} " +
                    $"de sexe {CurrentPerson.Sex} " +
                    $"né(e) en {CurrentPerson.BirthYear} " +
                    $"de niveau {CurrentPerson.ITLevel} " +
                    $"est dans le groupe {CurrentPerson.GroupNumber}");
            }
        }

        private static void InitializeData()
        {
            //Persons.Add(new Person("Micalaudie", "Alain", "M", 1967));
            Persons.Add(new Person("Audisso", "Julien", "M", 1985, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Moniz", "David", "M", 1996, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Ibombo", "Borel", "M", 2001, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Velin", "Daïka", "F", 1989, Person.eITLevel.Débutant, 0));
            Persons.Add(new Person("Chaieb", "Rania", "F", 1996, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Ghaem", "Hamid", "M", 1963, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Hijazi", "Samer", "M", 1972, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Molla", "Jean-Pierre", "M", 1984, Person.eITLevel.Avancé, 0));
            Persons.Add(new Person("Lependu", "Thierry", "M", 1995, Person.eITLevel.Avancé, 0));
            Persons.Add(new Person("Diaby", "Alhousseny", "M", 2000, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Sadat", "Lyes", "M", 1987, Person.eITLevel.Débutant, 0));
            Persons.Add(new Person("Haj kacem", "Slim", "M", 1986, Person.eITLevel.Avancé, 0));
            Persons.Add(new Person("Aliouchouche", "Tarek", "M", 1971, Person.eITLevel.Intermédiaire, 0));
            Persons.Add(new Person("Ait Ben Ahmed", "Mohamed", "M", 1986, Person.eITLevel.Intermédiaire, 0));
        }
    }
}

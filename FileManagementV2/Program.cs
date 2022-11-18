using System.Reflection;
using System.Text;

namespace FileManagement
{
    internal class Program
    {

        //public static string FilePath =
        //    "C:\\Users\\FORMATEUR\\Documents\\F2I\\";
        static string AssemblyPath = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
        static string FilePath = Path.Combine(AssemblyPath, "Data");
        public static string FileName = "POECProjects.csv";

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
                        $"{(int)CurrentPerson.Sex};" +
                        $"{CurrentPerson.BirthYear};" +
                        $"{(int)CurrentPerson.ITLevel};" +
                        $"{(int)CurrentPerson.Location};" +
                        $"{CurrentPerson.GroupNumber};" +
                        $"{CurrentPerson.ProjectName};" +
                        $"{(int)CurrentPerson.Technology}");
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
                        (Person.eSex)Convert.ToInt32(StudentData[2]),
                        Convert.ToInt32(StudentData[3]),
                        (Person.eITLevel)Convert.ToInt32(StudentData[4]),
                        (Person.eLocation)Convert.ToInt32(StudentData[5]),
                        Convert.ToInt32(StudentData[6]),
                        StudentData[7],
                        (Person.eTechnology)Convert.ToInt32(StudentData[8])));
                    Result = MyStream.ReadLine();
                }
            }

            Console.WriteLine($"Le fichier {FileName} a été lu.\n");
        }


        private static void ListData(List<Person> MyList)
        {
            Console.WriteLine("\nListe des étudiants par groupe :");

            MyList = MyList
                .OrderBy(S => (int)S.ITLevel)
                .OrderBy(S => S.GroupNumber)
                .ToList();

            int CurrentGroup = 0;
            foreach (Person CurrentPerson in MyList)
            {
                //string Prefix = (CurrentPerson.GroupNumber == CurrentGroup ? "" : "\n");
                //CurrentGroup = CurrentPerson.GroupNumber;

                //Console.WriteLine(
                //    $"{Prefix}" +
                //    $"{CurrentPerson.FirstName} " +
                //    $"{CurrentPerson.LastName} " +
                //    $"de sexe {CurrentPerson.Sex} " +
                //    $"né(e) en {CurrentPerson.BirthYear} " +
                //    $"de niveau {CurrentPerson.ITLevel} " +
                //    $"est dans le groupe {CurrentPerson.GroupNumber}");

                if (CurrentPerson.GroupNumber != CurrentGroup)
                {
                    Console.WriteLine(
                        $"\n" +
                        $"Groupe {CurrentPerson.GroupNumber} " +
                        $"- Projet : {CurrentPerson.ProjectName} " +
                        $"({CurrentPerson.Technology})");
                    CurrentGroup = CurrentPerson.GroupNumber;
                }

                Console.WriteLine(
                    $"{CurrentPerson.FirstName} " +
                    $"{CurrentPerson.LastName} " +
                    $"({CurrentPerson.Sex}, " +
                    $"{CurrentPerson.Age} ans), " +
                    $"niveau {CurrentPerson.ITLevel} " +
                    $"({CurrentPerson.Location})");
            }
        }

        private static void InitializeData()
        {
            //Persons.Add(new Person("Micalaudie", "Alain", "M", 1967));
            Persons.Add(new Person("Audisso", "Julien", Person.eSex.Masculin, 1985, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 1, "Site de e-Commerce", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Moniz", "David", Person.eSex.Masculin, 1996, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 4, "Programme de fitness", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Ibombo", "Borel", Person.eSex.Masculin, 2001, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5, "Simulateur de trains", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Velin", "Daïka", Person.eSex.Féminin, 1989, Person.eITLevel.Débutant, Person.eLocation.Présentiel, 4, "Programme de fitness", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Chaieb", "Rania", Person.eSex.Féminin, 1996, Person.eITLevel.Intermédiaire, Person.eLocation.Distanciel, 4, "Programme de fitness", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Ghaem", "Hamid", Person.eSex.Masculin, 1963, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 2, "Gestion de centre de formation", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Hijazi", "Samer", Person.eSex.Masculin, 1972, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 2, "Gestion de centre de formation", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Molla", "Jean-Pierre", Person.eSex.Masculin, 1984, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 1, "Site de e-Commerce", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Lependu", "Thierry", Person.eSex.Masculin, 1995, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 3, "Gestion de centre de formation", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Diaby", "Alhousseny", Person.eSex.Masculin, 2000, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5, "Simulateur de trains", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Sadat", "Lyes", Person.eSex.Masculin, 1987, Person.eITLevel.Débutant, Person.eLocation.Présentiel, 3, "Gestion de centre de formation", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Haj kacem", "Slim", Person.eSex.Masculin, 1986, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 2, "Gestion de centre de formation", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Aliouchouche", "Tarek", Person.eSex.Masculin, 1971, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 1, "Site de e-Commerce", Person.eTechnology.ASPNetMVC));
            Persons.Add(new Person("Ait Ben Ahmed", "Mohamed", Person.eSex.Masculin, 1986, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5, "Simulateur de trains", Person.eTechnology.ASPNetMVC));
        }
    }
}

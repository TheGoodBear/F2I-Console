
// Variable declarations
string? Name = "";
int BirthYear = 0;
int CurrentYear = DateTime.Now.Year;

// Start program
Console.WriteLine("Programme de calcul de l'age");

// Ask user input
while (Name == "")
{
    Console.Write("\nEntre ton nom : ");
    Name = Console.ReadLine();
    if (Name == "")
        Console.WriteLine("Tu dois entrer ton nom !");
}

while (BirthYear < 1800 || BirthYear > CurrentYear)
{
    Console.Write("\nEntre ton année de naissance : ");
    BirthYear = Convert.ToInt32(Console.ReadLine());

    if (BirthYear < 1800)
        Console.WriteLine("Tu dois entrer une année de naissance supérieure ou égale à 1800 !");
    if (BirthYear > CurrentYear)
        Console.WriteLine($"Tu dois entrer une année de naissance inférieure ou égale à l'année en cours ({CurrentYear}) !");
}

// Print result
int Age = CurrentYear - BirthYear;
Console.WriteLine($"\nBonjour {Name}, tu as {Age} ans.");
//Console.WriteLine($"\nBonjour {Name}, tu as {CurrentYear - BirthYear} ans.");

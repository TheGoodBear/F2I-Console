
#region "Initialization"
// Variable initialization
int LowestNumber = 1;
int HighestNumber = 100;
bool PlayAgain = true;
#endregion


#region "Main code"
// Program
GameStart();
string PlayerName = GetUserData();

// Game loop
while (PlayAgain)
{
    Random rnd = new Random();
    int MysteriousNumber = rnd.Next(LowestNumber, HighestNumber + 1);

    Console.WriteLine($"\nDémarrage de la partie...");

    int Rounds = GameLoop(MysteriousNumber);

    GameEnd(Rounds);

}

Console.WriteLine($"\nAu revoir {PlayerName}.");
#endregion


#region "Functions"
// Functions
void GameStart()
{
    // Program start
    Console.WriteLine("Jeu du nombre mystérieux");
    Console.WriteLine("------------------------");
    Console.WriteLine($"\nL'objectif est de trouver un nombre compris entre {LowestNumber} et {HighestNumber} en un minimum de coups");
}

string GetUserData()
{
    string UserName = "";

    // Ask user data
    while (UserName.Length < 3)
    {
        Console.Write("\nQuel est ton nom ? ");
        UserName = Console.ReadLine();
        if (int.TryParse(UserName, out int BadName))
        {
            Console.WriteLine("Vous ne pouvez pas entrer un nombre");
            UserName = "";
        } 
        else if (UserName.Length < 3)
            Console.WriteLine("Merci d'entrer un nom d'au moins 3 caractères");
    }
    Console.WriteLine($"\nBonjour {UserName}.");

    return UserName;
}

int GameLoop(int MysteriousNbr)
{
    int GuessNumber = 0;
    int Rounds = 0;

    while (GuessNumber != MysteriousNbr)
    {
        Console.Write($"\nEntre un nombre entre {LowestNumber} et {HighestNumber} : ");

        if (int.TryParse(Console.ReadLine(), out GuessNumber))
        {
            Rounds++;
            if (GuessNumber < MysteriousNbr)
            {
                Console.WriteLine($"\nLe nombre mystérieux est plus grand que {GuessNumber}");
            }
            else if (GuessNumber > MysteriousNbr)
            {
                Console.WriteLine($"\nLe nombre mystérieux est plus petit que {GuessNumber}");
            }
        }
        else
            Console.WriteLine($"Ceci n'est pas un nombre !");

    }

    return Rounds;
}

void GameEnd(int Rounds)
{
    // Player wins
    Console.WriteLine($"\nBravo {PlayerName} ! Tu as gagné en {Rounds} coups.");

    Console.Write($"\nVeux-tu rejouer ? (O)ui ou (N)on : ");
    if (!Console.ReadLine().ToLower().StartsWith("o"))
        PlayAgain = false;
}
#endregion

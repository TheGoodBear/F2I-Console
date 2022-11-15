//// Variable initialization
//int LowestNumber = 1;
//int HighestNumber = 100;
//int Rounds = 0;
//int MysteriousNumber = 0;
//int GuessNumber = 0;
//string? PlayerName = "";
//bool PlayAgain = true;

//// Program start
//Console.WriteLine("Jeu du nombre mystérieux");
//Console.WriteLine("------------------------");
//Console.WriteLine($"\nL'objectif est de trouver un nombre compris entre {LowestNumber} et {HighestNumber} en un minimum de coups");

//// Ask user data
//while (PlayerName.Length < 3)
//{
//    Console.Write("\nQuel est ton nom ? ");
//    PlayerName = Console.ReadLine();
//    if (int.TryParse(PlayerName, out int BadName))
//    {
//        Console.WriteLine("Vous ne pouvez pas entrer un nombre");
//        PlayerName = "";
//    }
//    else if (PlayerName.Length < 3)
//        Console.WriteLine("Merci d'entrer un nom d'au moins 3 caractères");
//}
//Console.WriteLine($"\nBonjour {PlayerName}.");

//// Game loop
//while (PlayAgain)
//{
//    Random rnd = new Random();
//    MysteriousNumber = rnd.Next(LowestNumber, HighestNumber + 1);
//    Rounds = 0;

//    Console.WriteLine($"\nDémarrage de la partie...");

//    while (GuessNumber != MysteriousNumber)
//    {
//        Console.Write($"\nEntre un nombre entre {LowestNumber} et {HighestNumber} : ");

//        if (int.TryParse(Console.ReadLine(), out GuessNumber))
//        {
//            Rounds++;
//            if (GuessNumber < MysteriousNumber)
//            {
//                Console.WriteLine($"\nLe nombre mystérieux est plus grand que {GuessNumber}");
//            }
//            else if (GuessNumber > MysteriousNumber)
//            {
//                Console.WriteLine($"\nLe nombre mystérieux est plus petit que {GuessNumber}");
//            }
//        }
//        else
//            Console.WriteLine($"Ceci n'est pas un nombre !");

//    }

//    // Player wins
//    Console.WriteLine($"\nBravo {PlayerName} ! Tu as gagné en {Rounds} coups.");

//    Console.Write($"\nVeux-tu rejouer ? (O)ui ou (N)on : ");
//    if (!Console.ReadLine().ToLower().StartsWith("o"))
//        PlayAgain = false;

//}

//Console.WriteLine($"\nAu revoir {PlayerName}.");

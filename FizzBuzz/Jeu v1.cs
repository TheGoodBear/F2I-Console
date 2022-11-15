
//#region "Declarations"

//const int MaxNumberOfPlayers = 10;
//const int GoodAnswerProbability = 90;

//List<string> Players = new List<string>();
//int CurrentPlayer = 0;
//Random rnd = new Random();

//#endregion


//#region "Main code"

//ShowGameRules();
//GetPlayerList();
//ShowPlayerList();
//StartGame();

//#endregion


//#region "Functions"

//void ShowGameRules()
//{
//    Console.WriteLine("Simulateur de FizzBuzz multijoueurs");

//    Console.WriteLine($"\nCe programme simule un jeu de FizzBuzz entre {MaxNumberOfPlayers} joueurs, chaque joueur a {GoodAnswerProbability}% de chance de donner la bonne réponse. Est déclaré vainqueur le dernier joueur en jeu.");
//}


//void GetPlayerList()
//{
//    Console.WriteLine("\nJoueurs, entrez vos noms...");

//    string Name = null;
//    while (Name != "" && CurrentPlayer < MaxNumberOfPlayers)
//    {
//        Name = GetPlayerName();
//        if (Name != "")
//            Players.Add(Name);
//    }
//}


//string GetPlayerName()
//{
//    Console.Write($"Joueur {CurrentPlayer + 1}, entre ton nom (enter pour arrêter) : ");
//    string Name = Console.ReadLine();
//    CurrentPlayer++;
//    return Name;
//}


//void ShowPlayerList()
//{
//    Console.WriteLine($"\nListe des {Players.Count} joueurs");

//    foreach (string Name in Players)
//        Console.WriteLine(Name);

//}


//void StartGame()
//{
//    int CurrentRound = 0;

//    while (Players.Count > 1)
//    {
//        CurrentRound++;

//        Console.WriteLine($"\nDébut du round {CurrentRound}");

//        StartRound();
//    }

//    Console.WriteLine($"\nFélicitation {Players[0]}, tu as gagné !!!");

//}


//void StartRound()
//{
//    int CurrentNumber = 1;
//    CurrentPlayer = rnd.Next(1, Players.Count + 1);

//    bool GoodAnswer = true;
//    while (GoodAnswer)
//    {
//        int AnswerProbability = rnd.Next(100);
//        GoodAnswer = (AnswerProbability <= GoodAnswerProbability);

//        string Answer = "";
//        if (GoodAnswer)
//        {
//            if (CurrentNumber % 15 == 0)
//                Answer = "FizzBuzz";
//            else if (CurrentNumber % 5 == 0)
//                Answer = "Buzz";
//            else if (CurrentNumber % 3 == 0)
//                Answer = "Fizz";
//            else
//                Answer = CurrentNumber.ToString();
//        }
//        else
//            Answer = "Mauvaise réponse !!!";

//        Console.WriteLine($"{Players[CurrentPlayer - 1]} dit {Answer}");

//        if (GoodAnswer)
//        {
//            CurrentNumber++;
//            CurrentPlayer++;
//            if (CurrentPlayer > Players.Count)
//                CurrentPlayer = 1;
//        }
//        else
//        {
//            Console.WriteLine($"{Players[CurrentPlayer - 1]} est éliminé !");
//            Players.RemoveAt(CurrentPlayer - 1);
//        }

//    }
//}

//#endregion

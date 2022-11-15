
// Initialization
int PlayerNumber = 0;
List<string> PlayerList = 
    new List<string> 
    { 
        "Tarek", 
        "Lyes", 
        "Hamid", 
        "Julien", 
        "Rania", 
        "Thierry", 
        "Samer"
    };
//PlayerList[2] = "Jean-Pierre";


// Main code
//PlayerList = ArrayDemo().ToList();
//PlayerList = ListDemo();
ShowPlayerList(PlayerList);

PlayerList.Add("Jean-Pierre");
ShowPlayerList(PlayerList);

PlayerList.Insert(3, "Borel");
ShowPlayerList(PlayerList);

PlayerList.RemoveAt(3);
ShowPlayerList(PlayerList);

PlayerList.Remove("Thierry");
ShowPlayerList(PlayerList);

PlayerList.Add("Alain");
PlayerList.Insert(1, "Alain");
PlayerList.Insert(4, "Alain");
ShowPlayerList(PlayerList);
PlayerList.Remove("Alain");
ShowPlayerList(PlayerList);
PlayerList.RemoveAll(e => e == "Alain");
ShowPlayerList(PlayerList);


// Functions
string[] ArrayDemo()
{
    string[] Players = new string[10];

    string Name = null;
    while (Name != "")
    {
        Name = GetPlayerName();
        if (Name != "")
        {
            Players[PlayerNumber] = Name;
        }
    }

    Console.WriteLine($"Taille du tableau = {Players.Length}");
    Console.WriteLine($"Nb d'éléments dans le tableau = {Players.Count(e => e != null)}");

    return Players;
}


List<string> ListDemo()
{
    List<string> Players = new List<string>();

    string Name = null;
    while (Name != "")
    {
        Name = GetPlayerName();
        if (Name != "")
            Players.Add(Name);
    }

    Console.WriteLine($"Nb d'éléments dans le tableau = {Players.Count()}");
    Console.WriteLine($"Eléments numéro 3 = {Players[2]}");
    Console.WriteLine($"Eléments numéro 3 = {Players.ElementAt(2)}");
    Console.WriteLine($"Eléments ccc = {Players.FindIndex(e => e == "ccc")}");

    return Players;
}


string GetPlayerName()
{
    Console.Write($"Joueur {PlayerNumber + 1}, entre ton nom (laisser vide pour arrêter) : ");
    string Name = Console.ReadLine();
    PlayerNumber++;
    return Name;
}


void ShowPlayerList(List<string> PlayerList)
{
    Console.WriteLine($"\nListe des {PlayerList.Count} joueurs");
    
    //for (int Nb = 0; Nb < PlayerList.Count; Nb++)
    //    Console.WriteLine(PlayerList[Nb]);

    foreach (string Name in PlayerList)
        Console.WriteLine(Name);

}

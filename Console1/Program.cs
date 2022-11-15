
string FirstName = "Alain";
//string firstName = "Alain";
//string first_name = "Alain";
int Age = 8;
//Age = Age + 1;
//Age += 1;
//Age++;

//if (<Condition 1>)
//{
//    Code à exécuter si Condition 1 est vrai 
//}
//else if (<Condition 2>)
//{
//    Code à exécuter si Condition 2 est vrai
//}
//else if (<Condition 3>)
//{
//    Code à exécuter si Condition 3 est vrai
//}
//else if (<Condition n>)
//{
//    Code à exécuter si Condition n est vrai
//}
//else
//{
//    Code à exécuter si aucune des condition précédentes n'est vraie
//}

//Condition → test qui retourne vrai ou faux (booléen)
//<Variable> <Opérateur de comparaison> <Valeur litérale>|<Variable>
//Opérateurs de comparaison : ==  !=  <  <=  >  >=

// EXemples 
// Variables Age = 18, Année = 22
// Age == Année     Age > 35     Age != 20



Age = 2;
if (Age >= 0)
{
    if (Age <= 3)
    {
        Console.WriteLine($"Salut");
        Console.WriteLine($"Je m'appelle {FirstName} et j'ai {Age} ans (je suis un bébé).");
    }
    else if (Age <= 12)
    {
        Console.WriteLine($"Je m'appelle {FirstName} et j'ai {Age} ans (je suis un enfant).");
    }
    else if (Age <= 18)
    {
        Console.WriteLine($"Je m'appelle {FirstName} et j'ai {Age} ans (je suis un ado).");
    }
    else if (Age <= 70)
    {
        Console.WriteLine($"Je m'appelle {FirstName} et j'ai {Age} ans (je suis un adulte).");
    }
    else
    {
        Console.WriteLine($"Je m'appelle {FirstName} et j'ai {Age} ans (je suis un senior).");
    }
}
else
{
    Console.WriteLine("Vous devez saisir un age positif");
}


//Console.WriteLine("Je m'appelle " + FirstName + " et j'ai " + Age + " ans.");

//for (int i = 1; i < 30; i++)
//{
//    if (i % 2 == 0)
//    {
//        Console.WriteLine($"{i} est un nombre pair");
//    }
//    else if (i % 2 != 0)
//    {
//        Console.WriteLine($"{i} est un nombre impair");
//    }
//}

Console.WriteLine("Terminé");

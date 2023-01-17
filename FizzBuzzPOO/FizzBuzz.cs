namespace FizzBuzzPOO;

public class FizzBuzz
{

    public static int MinValue = 1;
    public static int MaxValue = 100;


    public static void Main()
    {

        Console.WriteLine(
            $"\nFizzBuzz de {MinValue} à {MaxValue}\n");

        var FBG = new FBGame();
        FBG.PlayFizzBuzz();

        Console.WriteLine();

    }

}


public class FBGame : IFBPoo
{ 

    public void PlayFizzBuzz()
    {

        for (int Nb = FizzBuzz.MinValue; Nb <= FizzBuzz.MaxValue; Nb++) 
        { 
            string NumberResult = GetNumberResult(Nb);
            Console.Write(NumberResult);

            if (Nb != FizzBuzz.MaxValue)
                Console.Write(", ");
        }

    }


    public string GetNumberResult(
        object Number)
    {

        string ReturnValue = "";

        if (IsDivisibleBy3(Number))
            ReturnValue = "Fizz";

        if (IsDivisibleBy5((int)Number))
            ReturnValue += "Buzz";

        if (ReturnValue == "")
            ReturnValue = Number.ToString();

        return ReturnValue;

    }


    public bool IsDivisibleBy3(
        object Number) 
    {

        if (Number.GetType() != typeof(int))
            throw new FormatException();

        bool ReturnValue;

        if ((int)Number % 3 == 0) 
            ReturnValue = true;
        else
            ReturnValue = false;

        return ReturnValue;

    }


    public bool IsDivisibleBy5(
        int Number)
    {

        return Number % 5 == 0;

    }

}

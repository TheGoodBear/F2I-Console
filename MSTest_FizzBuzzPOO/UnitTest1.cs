using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzPOO;
using System.Security.Principal;


namespace MSTest_FizzBuzzPOO;

[TestClass]
public class FizzBuzzTest
{

    [TestMethod]
    public void Test_IsDivisibleBy3_Result()
    {

        // prepare
        var FBG = new FBGame();
        var Number = 9;

        // call
        var Result = FBG.IsDivisibleBy3(Number);

        // expect
        Assert.IsTrue(Result);

    }

    [TestMethod]
    public void Test_IsDivisibleBy3_NotANumber()
    {

        // prepare
        var FBG = new FBGame();
        var Number = "9";

        // call and expect
        Assert.ThrowsException<System.FormatException>(
            () => FBG.IsDivisibleBy3(Number));

    }

    [TestMethod]
    public void Test_Result_Fizz()
    {

        // prepare
        var FBG = new FBGame();
        var Number = 27;
        var Expected = "Fizz";

        // call
        var Result = FBG.GetNumberResult(Number);

        // expect
        Assert.AreEqual(
            Result, Expected);

    }

    [TestMethod]
    public void Test_Results()
    {

        // prepare
        var FBG = new FBGame();
        var Numbers = new int[] { 7, 18, 50, 75, 30 };
        var Expected = new string[] { "7", "Fizz", "Buzz", "FizzBuzz", "FizzBuzz" };
        var Results = new List<string>();

        // call
        foreach(var Number in Numbers) 
        {
            Results.Add(FBG.GetNumberResult(Number).ToString());
        }

        // expect
        for(var i = 0; i < Expected.Count(); i++)
        {
            Assert.AreEqual(
                Results[i], Expected[i]);
        }
        //Assert.IsTrue(
        //    Results.SequenceEqual(Expected));

    }

}

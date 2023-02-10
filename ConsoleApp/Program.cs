using System;

//In this program we have a console app about numbers,
//We have one interface called NumberInterface
//NumberInterface has three properties: a indexer('this'), an event ('WeHaveNumbers'), and a method ('Addition')
interface NumberInterface
{
    int MyOddNumber { get; set; }
    int MyEvenNumber { get; set; }
    int Addition(int number1, int number2);
    event EventHandler WeHaveNumbers;
    int this[int index] { get; set; }
}

class NumberClass : NumberInterface
{
    private int OddNumber;
    private int EvenNumber;
    private int[] indexerArray = new int[3];

    public int MyOddNumber
    {
        get {
            return OddNumber; }
        set { 
            OddNumber = value; }
    }

    public int MyEvenNumber
    {
        get { 
            return EvenNumber; }
        set { 
            EvenNumber = value; }
    }

    public int Addition(int number1, int number2)
    {
        return number1 + number2;
    }

    public event EventHandler WeHaveNumbers;

    public void raisedEventofNumbers()
    {
        if (WeHaveNumbers != null)
        {
            WeHaveNumbers(this, EventArgs.Empty);
        }
    }
    public int this[int index]
    {
        get { return indexerArray[index]; }
        set { indexerArray[index] = value; }
    }
}

public class NumberExist
{  
    public void MyEventHandler(object sender, EventArgs e)
    {
        Console.WriteLine("We do have numbers");
    }
}
    
class Program
{
    static void Main(string[] args)
    {
        NumberClass Numbers = new NumberClass();
        Numbers.MyOddNumber = 13;
        Numbers.MyEvenNumber = 12;
        Console.WriteLine("MyOddNumber: " + Numbers.MyOddNumber);
        Console.WriteLine("MyEvenNumber: " + Numbers.MyEvenNumber);
        Console.WriteLine("MyMethod: " + Numbers.Addition(3, 4));
        var HavingNumber = new NumberExist();
        Numbers.WeHaveNumbers += HavingNumber.MyEventHandler;
        Numbers.raisedEventofNumbers();
        Console.WriteLine("3 Hard Coded Indexer:");
        Numbers[0] = 100;
        Numbers[1] = 50;
        Numbers[2] = 0;
        Console.WriteLine("In Indexer 0: " + Numbers[0]);
        Console.WriteLine("In Indexer 1: " + Numbers[1]);
        Console.WriteLine("In Indexer 2: " + Numbers[2]);
        Console.ReadLine();
    }

}
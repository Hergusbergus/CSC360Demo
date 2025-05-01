internal class Program
{
    private static void Main(string[] args)
    {
        var fileText = File.ReadAllText("ReadThis.txt");
        var newText = fileText.ToUpper();
        Console.WriteLine(newText);
    }
}
using System;

class Error
{
    public static void Message(string type, string message)
    {
        Console.WriteLine(type + " Error - " + message);
        System.Environment.Exit(0);
    }
}

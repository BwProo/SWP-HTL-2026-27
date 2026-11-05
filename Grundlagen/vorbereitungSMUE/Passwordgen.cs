// KI

using System;
using System.Text;

class Passwordgen
{
    static void Main()
    {
        Console.WriteLine("--- C# Passwort-Generator ---");

        // Länge des Passworts festlegen
        int length = 12;
        string generatedPassword = GeneratePassword(length);

        Console.WriteLine($"Dein generiertes Passwort ({length} Zeichen):");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(generatedPassword);
        Console.ResetColor();
    }

    static string GeneratePassword(int length)
    {
        const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
        StringBuilder result = new StringBuilder();
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = rnd.Next(validChars.Length);
            result.Append(validChars[index]);
        }

        return result.ToString();
    }
}
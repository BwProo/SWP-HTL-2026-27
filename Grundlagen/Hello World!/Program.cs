using System;
using System.Linq;

namespace KonsolenApp
{
    /* 
     * PR-Kommentar / Theoriefragen:
     * 
     * 1. Wozu benötigt C# überhaupt Datentypen?
     * - Speicherreservierung: Damit der Computer weiß, wie viel Arbeitsspeicher (RAM) reserviert werden muss.
     * - Typsicherheit: Verhindert ungültige Operationen (z. B. Rechnen mit Text).
     * - Klarheit: Macht den Code verständlicher.
     * 
     * 2. Welche Datentypen kennt C#?
     * - Wertedypen (Value Types): z. B. int, double, bool, char, decimal
     * - Verweistypen (Reference Types): z. B. string, object, Arrays, Klassen
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte einen String eingeben: ");
            string eingabe = Console.ReadLine();

            if (eingabe != null)
            {
                // String in ein char-Array umwandeln, umkehren und wieder zu einem String zusammenfügen
                char[] charArray = eingabe.ToCharArray();
                Array.Reverse(charArray);
                string umgedreht = new string(charArray);

                Console.WriteLine($"Ausgabe: {umgedreht}");
                Console.ReadKey();
            }
        }
    }
}
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
                // 1. Versuche, die Eingabe als Ganzzahl (int) zu interpretieren
                if (int.TryParse(eingabe, out int intWert))
                {
                    Console.WriteLine($"Erkannt: Integer (Ganzzahl) -> {intWert}");
                }
                // 2. Versuche, die Eingabe als Kommazahl (double) zu interpretieren
                else if (double.TryParse(eingabe, out double doubleWert))
                {
                    Console.WriteLine($"Erkannt: Rationale Zahl (Double) -> {doubleWert}");
                }
                // 3. Versuche, die Eingabe als Wahrheitswert (bool) zu interpretieren
                else if (bool.TryParse(eingabe, out bool boolWert))
                {
                    Console.WriteLine($"Erkannt: Boolean (Wahrheitswert) -> {boolWert}");
                }
                // 4. Wenn nichts davon zutrifft, bleibt es ein String
                else
                {
                    Console.WriteLine($"Erkannt: Regulärer String (Text) -> {eingabe}");
                }

                Console.ReadKey();
            }
        }
    }
}
using System;
using System.Linq;

namespace KonsolenApp
{

    class Program
    {
        static void Main(string[] args)
        {
            bool programmLäuft = true;

            // Eine Schleife, damit das Menü nach jeder Aktion wiederkommt
            while (programmLäuft)
            {
                Console.Clear(); // Löscht den Bildschirm für eine saubere Ansicht
                Console.WriteLine("============================");
                Console.WriteLine("       HAUPTMENÜ           ");
                Console.WriteLine("============================");
                Console.WriteLine("1 - String umkehren");
                Console.WriteLine("2 - Datentyp erkennen");
                Console.WriteLine("3 - Hello SWP!");
                Console.WriteLine("0 - Programm beenden");
                Console.Write("\nBitte wähle eine Option: ");

                string auswahl = Console.ReadLine();
                Console.WriteLine(); // Leerzeile für den Abstand

                // Hier wird ausgewertet, welche Zahl der Benutzer eingegeben hat
                switch (auswahl)
                {
                    case "1":
                        StringUmkehren();
                        break;
                    case "2":
                        DatentypErkennen();
                        break;
                    case "3":
                        HelloWorld();
                        break;
                    case "0":
                        programmLäuft = false;
                        Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
                        break;
                    
                    default:
                        Console.WriteLine("Ungültige Auswahl! Bitte eine Zahl aus dem Menü wählen.");
                        break;
                }

                // Wenn das Programm nicht beendet wurde, warten wir kurz, bis der Nutzer weiterwill
                if (programmLäuft)
                {
                    Console.WriteLine("\nDrücke eine beliebige Taste, um ins Menü zurückzukehren...");
                    Console.ReadKey();
                }
            }
        }

        // --- HIER SIND DEINE EINZELNEN FUNKTIONEN ---

        // Funktion 1: String umkehren (aus der ersten Aufgabe)
        static void StringUmkehren()

        {
            Console.WriteLine("--- Modus: String umkehren ---");
            Console.Write("Bitte einen String eingeben: ");
            string eingabe = Console.ReadLine();

            if (!string.IsNullOrEmpty(eingabe))
            {
                char[] charArray = eingabe.ToCharArray();
                Array.Reverse(charArray);
                string umgedreht = new string(charArray);

                Console.WriteLine($"Ausgabe: {umgedreht}");
            }
        }

        // Funktion 2: Datentyp erkennen (aus der aktuellen Aufgabe)
        static void DatentypErkennen()

        {
            Console.WriteLine("--- Modus: Datentyp erkennen ---");
            Console.Write("Bitte einen Wert eingeben: ");
            string eingabe = Console.ReadLine();

            if (eingabe != null)
            {
                if (int.TryParse(eingabe, out int intWert))
                {
                    Console.WriteLine($"Erkannt: Integer (Ganzzahl) -> {intWert}");
                }
                else if (double.TryParse(eingabe, out double doubleWert))
                {
                    Console.WriteLine($"Erkannt: Rationale Zahl (Double) -> {doubleWert}");
                }
                else if (bool.TryParse(eingabe, out bool boolWert))
                {
                    Console.WriteLine($"Erkannt: Boolean (Wahrheitswert) -> {boolWert}");
                }
                else
                {
                    Console.WriteLine($"Erkannt: Regulärer String (Text) -> {eingabe}");
                }
            }
        }

            static void HelloWorld()

            {
             Console.WriteLine("Hello, SWP");
             Console.ReadKey();
        }
    }
}

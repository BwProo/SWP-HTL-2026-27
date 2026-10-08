namespace KonsolenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programmLäuft = true;

            while (programmLäuft)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("           HAUPTMENÜ             ");
                Console.WriteLine("=================================");
                Console.WriteLine("1 - String umkehren");
                Console.WriteLine("2 - Datentyp erkennen");
                Console.WriteLine("3 - Datentyp erkennen ohne if true");
                Console.WriteLine("4 - Hello SWP!");
                Console.WriteLine("5 - Mathematische Operationen");
                Console.WriteLine("0 - Programm beenden");
                Console.Write("\nBitte wähle eine Option: ");

                string? auswahl = Console.ReadLine();
                Console.WriteLine();

                switch (auswahl)
                {
                    case "1":
                        StringUmkehren();
                        break;
                    case "2":
                        DatentypErkennen();
                        break;
                    case "3":
                        DatentypErkennenoiftrue();
                        break;
                    case "4":
                        HelloWorld();
                        break;
                    case "5":
                        MathematischeOperationen();
                        break;
                    case "0":
                        programmLäuft = false;
                        Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl! Bitte eine Zahl aus dem Menü wählen.");
                        break;
                }

                if (programmLäuft)
                {
                    Console.WriteLine("\nDrücke eine beliebige Taste, um ins Menü zurückzukehren...");
                    Console.ReadKey();
                }
            }
        }

        // --- FUNKTIONEN ---

        static void StringUmkehren()
        {
            Console.WriteLine("--- Modus: String umkehren ---");
            Console.Write("Bitte einen String eingeben: ");
            string? eingabe = Console.ReadLine();

            if (!string.IsNullOrEmpty(eingabe))
            {
                char[] charArray = eingabe.ToCharArray();
                Array.Reverse(charArray);
                string umgedreht = new string(charArray);

                Console.WriteLine($"Ausgabe: {umgedreht}");
            }
        }

        static void DatentypErkennen()
        {
            Console.WriteLine("--- Modus: Datentyp erkennen ---");
            Console.Write("Bitte einen Wert eingeben: ");
            string? eingabe = Console.ReadLine();

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

        // Menüpunkt 3: Extrem einfach und kompakt mit einem switch-Ausdruck
        static void DatentypErkennenoiftrue()
        {
            Console.WriteLine("--- Modus: Datentyp erkennen ---");
            Console.Write("Bitte einen Wert eingeben: ");
            string? eingabe = Console.ReadLine();

            if (eingabe != null)
            {
                string ausgabe = eingabe switch
                {
                    _ when int.TryParse(eingabe, out int i) => $"Erkannt: Integer (Ganzzahl) -> {i}",
                    _ when double.TryParse(eingabe, out double d) => $"Erkannt: Rationale Zahl (Double) -> {d}",
                    _ when bool.TryParse(eingabe, out bool b) => $"Erkannt: Boolean (Wahrheitswert) -> {b}",
                    _ => $"Erkannt: Regulärer String (Text) -> {eingabe}"
                };

                Console.WriteLine(ausgabe);
            }
        }

        static void MathematischeOperationen()
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" Modus: Mathematische Operationen");
            Console.WriteLine("=================================");
            Console.WriteLine("1 - Quadrat");
            Console.WriteLine("2 - Quadratwurzel");
            Console.WriteLine("3 - Fakultät");
            Console.Write("Bitte wähle eine Operation (1-3): ");

            string? eingabe = Console.ReadLine();

            if (eingabe == "1" || eingabe == "2" || eingabe == "3")
            {
                Console.Write("Bitte gib eine Zahl ein: ");

                if (double.TryParse(Console.ReadLine(), out double zahl))
                {
                    string ausgabe = eingabe switch
                    {
                        "1" => $"Ergebnis (Quadrat): {zahl * zahl}",

                        "2" => zahl >= 0
                            ? $"Ergebnis (Wurzel): {Math.Sqrt(zahl)}"
                            : "Fehler: Keine Wurzel aus negativen Zahlen möglich!",

                        "3" => (zahl >= 0 && zahl == Math.Floor(zahl))
                            ? $"Ergebnis (Fakultät): {BerechneFakultaet((int)zahl)}"
                            : "Fehler: Fakultät nur für ganze, positive Zahlen!",

                        _ => "Ungültige Auswahl."
                    };

                    Console.WriteLine(ausgabe);
                }
                else
                {
                    Console.WriteLine("Fehler: Das war keine gültige Zahl!");
                }
            }
            else
            {
                Console.WriteLine("Fehler: Du hast eine ungültige Operation gewählt.");
            }
        }

        static long BerechneFakultaet(int n)
        {
            if (n == 0 || n == 1) return 1;

            long ergebnis = 1;
            for (int i = 2; i <= n; i++)
            {
                ergebnis *= i;
            }
            return ergebnis;
        }




    }
}
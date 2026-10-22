class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zahl oder Text!");
        string eingabe = Console.ReadLine();

        if (int.TryParse(eingabe, out int zahl))
        {
            ZahlBerechnen(zahl);
            return;
        }

        TextBearbeiten(eingabe);
    }

    static void ZahlBerechnen(int zahl)
    {
        Console.WriteLine("1) Addition");
        Console.WriteLine("2) Multiplikation");
        Console.WriteLine("3) Division");
        Console.WriteLine("4) Fakultät");
        Console.WriteLine("5) Wurzelziehen");

        string auswahl = Console.ReadLine();

        switch (auswahl)
        {
            case "1":
                Addieren(zahl);
                break;
            case "2":
                Multiplizieren(zahl);
                break;
            case "3":
                Dividieren(zahl);
                break;
            case "4":
                FakultaetBerechnen(zahl);
                break;
            case "5":
                WurzelZiehen(zahl);
                break;
            default:
                Console.WriteLine("Error, ungültige Auswahl.");
                break;
        }
    }

    static void Addieren(int ersteZahl)
    {
        Console.Write("Gib mir die Zweite Zahl:");
        if (!double.TryParse(Console.ReadLine(), out double zweiteZahl))
        {
            Console.WriteLine("Error, ungültige Eingabe.");
            return;
        }

        double ergebnis = ersteZahl + zweiteZahl;
        Console.WriteLine("Ergebnis: " + ersteZahl + " + " + zweiteZahl + " = " + ergebnis);
    }

    static void Multiplizieren(int ersteZahl)
    {
        Console.Write("Mit welcher zahl soll Multipliziert werden? ");
        if (!double.TryParse(Console.ReadLine(), out double zweiteZahl))
        {
            Console.WriteLine("Error, ungültige Eingabe.");
            return;
        }

        double ergebnis = ersteZahl * zweiteZahl;
        Console.WriteLine("Ergebnis: " + ersteZahl + " * " + zweiteZahl + " = " + ergebnis);
    }

    static void Dividieren(int ersteZahl)
    {
        Console.Write("Mit welcher zahl soll geteilt werden? ");
        if (!double.TryParse(Console.ReadLine(), out double zweiteZahl))
        {
            Console.WriteLine("Error, ungültige Eingabe.");
            return;
        }

        if (zweiteZahl == 0)
        {
            Console.WriteLine("Error, durch Null teilen klappt net!");
            return;
        }

        double ergebnis = (double)ersteZahl / zweiteZahl;
        Console.WriteLine("Ergebnis: " + ersteZahl + " / " + zweiteZahl + " = " + ergebnis);
    }

    static void FakultaetBerechnen(int zahl)
    {
        if (zahl < 0)
        {
            Console.WriteLine("Error, Fakultät für Minus-Zahlen geht ned!");
            return;
        }

        long ergebnis = 1;
        for (int i = 1; i <= zahl; i++)
        {
            ergebnis = ergebnis * i;
        }
        Console.WriteLine("Ergebnis: " + zahl + "! = " + ergebnis);
    }

    static void WurzelZiehen(int zahl)
    {
        if (zahl < 0)
        {
            Console.WriteLine("Error, Wurzel aus ner negativen Zahl geht ned!");
            return;
        }

        double ergebnis = Math.Sqrt(zahl);
        Console.WriteLine("Ergebnis: Wurzel aus " + zahl + " ist " + ergebnis);
    }

    static void TextBearbeiten(string text)
    {
        Console.WriteLine("1) Selbstlaute (a,e,i,o,u) rauslöschen");
        Console.WriteLine("2) Die Zeichenkette 'umdrehen' (aus 'Hallo' ein 'ollaH')");
        Console.WriteLine("3) Die Anzahl der Zeichen augeben");

        string auswahl = Console.ReadLine();

        switch (auswahl)
        {
            case "1":
                SelbstlauteEntfernen(text);
                break;
            case "2":
                StringUmdrehen(text);
                break;
            case "3":
                ZeichenZaehlen(text);
                break;
            default:
                Console.WriteLine("Error, keine gültige Auswahl.");
                break;
        }
    }

    static void SelbstlauteEntfernen(string text)
    {
        char[] selbstlaute = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        string ergebnis = text;

        foreach (char buchstabe in selbstlaute)
        {
            ergebnis = ergebnis.Replace(buchstabe.ToString(), "");
        }

        Console.WriteLine("ohne Selbstlaute: " + ergebnis);
    }

    static void StringUmdrehen(string text)
    {
        char[] zeichenArray = text.ToCharArray();
        Array.Reverse(zeichenArray);
        string umgedreht = new string(zeichenArray);
        Console.WriteLine("Rückwärts: " + umgedreht);
    }

    static void ZeichenZaehlen(string text)
    {
        int anzahl = text.Length;
        Console.WriteLine("Es sind " + anzahl + " Zeichen.");
    }
}
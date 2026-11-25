using System;
using System.Globalization;

// Test (Top-Level-Statements, ab C# 9 / .NET 5)
// Achtung: In C# ist der Monat 1-basiert (5 = Mai, 12 = Dezember), anders als in JavaScript!
var myKuh = new Cow("Kuh1", "weiß", new DateTime(2020, 5, 15));
var myKatze = new Cat("Katze1", "schwarz", new DateTime(2023, 12, 1));

myKuh.MakeSound();   // Muuuuh
myKatze.MakeSound(); // Miau

Console.WriteLine(myKuh.Name + " ist " + myKuh.GetAge() + " Jahre alt");     // Kuh1 ist 6 Jahre alt
Console.WriteLine(myKatze.Name + " ist " + myKatze.GetAge() + " Jahre alt"); // Katze1 ist 2 Jahre alt
Console.WriteLine(myKuh.Name + " wurde am " + myKuh.BirthDate.ToString("d.M.yyyy", new CultureInfo("de-DE")) + " geboren"); // 15.5.2020

var myKuh2 = myKuh;
Console.WriteLine(myKuh2 == myKuh); // True – dieselbe Instanz
myKuh.Colour = "braun";
Console.WriteLine(myKuh2.Colour);   // braun

// ---- Überladene Konstruktoren ----
var myKuh3 = new Cow("Kuh3", "gefleckt"); // ohne Geburtsdatum -> heute geboren
var myKatze3 = new Cat("Katze3");         // ohne Farbe und Geburtsdatum
Console.WriteLine(myKuh3.Name + ": " + myKuh3.Colour + ", " + myKuh3.GetAge() + " Jahre");       // Kuh3: gefleckt, 0 Jahre
Console.WriteLine(myKatze3.Name + ": " + myKatze3.Colour + ", " + myKatze3.GetAge() + " Jahre"); // Katze3: unbekannt, 0 Jahre

// ---- Überladene Methoden ----
myKatze.MakeSound(3);            // Miau Miau Miau
myKuh.MakeSound("Guten Morgen"); // Kuh1 sagt: Guten Morgen ... Muuuuh

Console.WriteLine(myKuh.Name + " ist am 1.1.2030 " + myKuh.GetAge(new DateTime(2030, 1, 1)) + " Jahre alt"); // 9

// Geburtsdatum in der Zukunft wird abgelehnt
try
{
    new Cat("Katze2", "grau", new DateTime(2099, 1, 1));
}
catch (ArgumentException e)
{
    Console.WriteLine("Fehler: " + e.Message); // Fehler: Geburtsdatum liegt in der Zukunft
}

// Stichtag vor der Geburt wird abgelehnt
try
{
    myKuh.GetAge(new DateTime(2000, 1, 1));
}
catch (ArgumentException e)
{
    Console.WriteLine("Fehler: " + e.Message); // Fehler: Stichtag liegt vor dem Geburtsdatum
}

abstract class Animal // Basisklasse für Tiere – gemeinsame Attribute und Methoden
{
    private readonly string _name;
    private string _colour;
    private readonly DateTime _birthDate;

    // ---- Konstruktor-Überladungen ----
    protected Animal(string name, string colour, DateTime birthDate) // "Haupt"-Konstruktor
    {
        if (birthDate > DateTime.Now) // Geburtsdatum darf nicht in der Zukunft liegen
        {
            throw new ArgumentException("Geburtsdatum liegt in der Zukunft");
        }
        _name = name;
        _colour = colour;
        _birthDate = birthDate;
    }

    protected Animal(string name, string colour) // ohne Geburtsdatum -> heute
        : this(name, colour, DateTime.Today) { }  // ruft den Haupt-Konstruktor auf

    protected Animal(string name)                 // nur Name -> Farbe unbekannt, heute geboren
        : this(name, "unbekannt") { }

    public string Name => _name;                                     // öffentlicher Getter für den Namen
    public string Colour { get => _colour; set => _colour = value; } // öffentlicher Getter und Setter für die Farbe
    public DateTime BirthDate => _birthDate;                         // öffentlicher Getter für das Geburtsdatum

    // ---- Methoden-Überladungen: GetAge ----
    public int GetAge() // Alter heute
    {
        return GetAge(DateTime.Today);
    }

    public int GetAge(DateTime stichtag) // Alter zu einem beliebigen Stichtag
    {
        if (stichtag < _birthDate)
        {
            throw new ArgumentException("Stichtag liegt vor dem Geburtsdatum");
        }
        int age = stichtag.Year - _birthDate.Year;
        bool hadBirthday =
            stichtag.Month > _birthDate.Month ||
            (stichtag.Month == _birthDate.Month && stichtag.Day >= _birthDate.Day);
        if (!hadBirthday)
        {
            age--; // Geburtstag war in diesem Jahr noch nicht
        }
        return age;
    }

    // ---- Methoden-Überladungen: MakeSound ----
    public abstract void MakeSound(); // muss in jeder abgeleiteten Klasse umgesetzt werden

    public void MakeSound(int anzahl) // Laut mehrmals machen
    {
        for (int i = 0; i < anzahl; i++)
        {
            MakeSound();
        }
    }

    public void MakeSound(string nachricht) // vorher noch etwas "sagen"
    {
        Console.Write(_name + " sagt: " + nachricht + " ... ");
        MakeSound();
    }
}

class Cow : Animal // abgeleitete Klasse von Animal
{
    public Cow(string name, string colour, DateTime birthDate) : base(name, colour, birthDate) { }
    public Cow(string name, string colour) : base(name, colour) { }
    public Cow(string name) : base(name) { }

    public override void MakeSound() => Console.WriteLine("Muuuuh");
}

class Cat : Animal // abgeleitete Klasse von Animal
{
    public Cat(string name, string colour, DateTime birthDate) : base(name, colour, birthDate) { }
    public Cat(string name, string colour) : base(name, colour) { }
    public Cat(string name) : base(name) { }

    public override void MakeSound() => Console.WriteLine("Miau");
}
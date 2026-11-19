using System;
using System.Globalization;

// Test (Top-Level-Statements, ab C# 9 / .NET 5)
// Achtung: In C# ist der Monat 1-basiert (5 = Mai, 12 = Dezember), anders als in JavaScript!
var myKuh = new Cow("Kuh1", "weiß", new DateTime(2020, 5, 15));
var myKatze = new Cat("Katze1", "schwarz", new DateTime(2023, 12, 1));

myKuh.MakeSound();   // Muuuuh
myKatze.MakeSound(); // Miau

Console.WriteLine(myKuh.Name + " ist " + myKuh.GetAge() + " Jahre alt");     // Kuh1 ist 6 Jahre alt (Stand 19.11.2026)
Console.WriteLine(myKatze.Name + " ist " + myKatze.GetAge() + " Jahre alt"); // Katze1 ist 2 Jahre alt (Stand 19.11.2026)
Console.WriteLine(myKuh.Name + " wurde am " + myKuh.BirthDate.ToString("d.M.yyyy", new CultureInfo("de-DE")) + " geboren"); // 15.5.2020

var myKuh2 = myKuh;
Console.WriteLine(myKuh2 == myKuh); // True – dieselbe Instanz
myKuh.Colour = "braun";
Console.WriteLine(myKuh2.Colour);   // braun

// Geburtsdatum in der Zukunft wird abgelehnt
try
{
    new Cat("Katze2", "grau", new DateTime(2099, 1, 1));
}
catch (ArgumentException e)
{
    Console.WriteLine("Fehler: " + e.Message); // Fehler: Geburtsdatum liegt in der Zukunft
}

abstract class Animal // Basisklasse für Tiere – gemeinsame Attribute und Methoden
{
    private readonly string _name;
    private string _colour;
    private readonly DateTime _birthDate;

    protected Animal(string name, string colour, DateTime birthDate) // Konstruktor => "konstruiert" ein Tier
    {
        if (birthDate > DateTime.Now) // Geburtsdatum darf nicht in der Zukunft liegen
        {
            throw new ArgumentException("Geburtsdatum liegt in der Zukunft");
        }
        _name = name;
        _colour = colour;
        _birthDate = birthDate;
    }

    public string Name => _name;                                  // öffentlicher Getter für den Namen
    public string Colour { get => _colour; set => _colour = value; } // öffentlicher Getter und Setter für die Farbe
    public DateTime BirthDate => _birthDate;                      // öffentlicher Getter für das Geburtsdatum

    public int GetAge() // berechnet das Alter in Jahren aus dem Geburtsdatum
    {
        DateTime today = DateTime.Today;
        int age = today.Year - _birthDate.Year;
        bool hadBirthdayThisYear =
            today.Month > _birthDate.Month ||
            (today.Month == _birthDate.Month && today.Day >= _birthDate.Day);
        if (!hadBirthdayThisYear)
        {
            age--; // Geburtstag war dieses Jahr noch nicht
        }
        return age;
    }

    public abstract void MakeSound(); // muss in jeder abgeleiteten Klasse umgesetzt werden
}

class Cow : Animal // abgeleitete Klasse von Animal
{
    public Cow(string name, string colour, DateTime birthDate) : base(name, colour, birthDate) { }
    public override void MakeSound() => Console.WriteLine("Muuuuh");
}

class Cat : Animal // abgeleitete Klasse von Animal
{
    public Cat(string name, string colour, DateTime birthDate) : base(name, colour, birthDate) { }
    public override void MakeSound() => Console.WriteLine("Miau");
}
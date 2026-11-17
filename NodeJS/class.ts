abstract class Animal { // Basisklasse für Tiere – gemeinsame Attribute und Methoden
    private _name: string;
    private _colour: string;
    private _birthDate: Date;

    constructor(name: string, colour: string, birthDate: Date) { // Konstruktor => "konstruiert" ein Tier
        if (birthDate > new Date()) { // Geburtsdatum darf nicht in der Zukunft liegen
            throw new Error("Geburtsdatum liegt in der Zukunft");
        }
        this._name = name;
        this._colour = colour;
        this._birthDate = birthDate;
    }

    public get Name() {return this._name;}                   // öffentlicher Getter für den Namen
    public get Colour() {return this._colour;}               // öffentlicher Getter für die Farbe
    public set Colour(value: string) {this._colour = value;} // öffentlicher Setter für die Farbe
    public get BirthDate() {return this._birthDate;}         // öffentlicher Getter für das Geburtsdatum

    public getAge(): number { // berechnet das Alter in Jahren aus dem Geburtsdatum
        const today = new Date();
        let age = today.getFullYear() - this._birthDate.getFullYear();
        const hadBirthdayThisYear =
            today.getMonth() > this._birthDate.getMonth() ||
            (today.getMonth() === this._birthDate.getMonth() && today.getDate() >= this._birthDate.getDate());
        if (!hadBirthdayThisYear) {
            age--; // Geburtstag war dieses Jahr noch nicht
        }
        return age;
    }

    public abstract makeSound(): void; // muss in jeder abgeleiteten Klasse umgesetzt werden
}

class Cow extends Animal { // abgeleitete Klasse von Animal
    public makeSound(): void {console.log("Muuuuh");}
}

class Cat extends Animal { // abgeleitete Klasse von Animal
    public makeSound(): void {console.log("Miau");}
}

// Test
// Datum als (Jahr, Monat, Tag) angeben – Monat ist 0-basiert (4 = Mai, 11 = Dezember).
// So wird das Datum in lokaler Zeit erstellt und es gibt keine Zeitzonen-Verschiebung.
const myKuh = new Cow("Kuh1", "weiß", new Date(2020, 4, 15));
const myKatze = new Cat("Katze1", "schwarz", new Date(2023, 11, 1));

myKuh.makeSound();   // Muuuuh
myKatze.makeSound(); // Miau

console.log(myKuh.Name + " ist " + myKuh.getAge() + " Jahre alt");     // Kuh1 ist 6 Jahre alt (Stand 17.11.2026)
console.log(myKatze.Name + " ist " + myKatze.getAge() + " Jahre alt"); // Katze1 ist 2 Jahre alt (Stand 17.11.2026)
console.log(myKuh.Name + " wurde am " + myKuh.BirthDate.toLocaleDateString("de-DE") + " geboren"); // 15.5.2020

const myKuh2 = myKuh;
console.log(myKuh2 == myKuh); // true – dieselbe Instanz
myKuh.Colour = "braun";
console.log(myKuh2.Colour);   // braun

// Geburtsdatum in der Zukunft wird abgelehnt
try {
    new Cat("Katze2", "grau", new Date(2099, 0, 1));
} catch (e) {
    console.log("Fehler: " + (e as Error).message); // Fehler: Geburtsdatum liegt in der Zukunft
}

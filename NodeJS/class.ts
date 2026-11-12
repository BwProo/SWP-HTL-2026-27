abstract class Animal { // Basisklasse für Tiere – gemeinsame Attribute und Methoden
    private _name: string;
    private _colour: string;
    private _birthDate: Date;

    constructor(name: string, colour: string, birthDate: Date) { // Konstruktor => "konstruiert" ein Tier
        this._name = name;
        this._colour = colour;
        this._birthDate = birthDate;
    }

    public get Name() {return this._name;} // öffentliche Methode, um den Namen abzurufen
    public get Colour() {return this._colour;} // öffentliche Methode, um die Farbe abzurufen
    public set Colour(value: string) {this._colour = value;} // öffentliche Methode, um die Farbe zu setzen

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
    public makeSound() {console.log("Muuuuh");}
}

class Cat extends Animal { // abgeleitete Klasse von Animal
    public makeSound() {console.log("Miau");}
}

// Test
let myKuh = new Cow("Kuh1", "weiß", new Date("2020-05-15"));
let myKatze = new Cat("Katze1", "schwarz", new Date("2023-12-01"));

myKuh.makeSound();   // Muuuuh
myKatze.makeSound(); // Miau

console.log(myKuh.Name + " ist " + myKuh.getAge() + " Jahre alt");     // Kuh1 ist 6 Jahre alt
console.log(myKatze.Name + " ist " + myKatze.getAge() + " Jahre alt"); // Katze1 ist 2 Jahre alt

let myKuh2 = myKuh;
console.log(myKuh2 == myKuh); // true – dieselbe Instanz
myKuh.Colour = "braun";
console.log(myKuh2.Colour);   // braun
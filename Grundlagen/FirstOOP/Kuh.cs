using System;
using System.Collections.Generic;
using System.Text;

namespace FirstOOP
{
    public class Kuh
    {
        string _name; // private field for the name of the Kuh
        string _colour; // private field for the colour of the Kuh

        public string Name // public property for the name of the Kuh
        {
            get { return _name; } // getter for the name
            set { _name = value; } // setter for the name
        }

        public string Colour // public property for the colour of the Kuh
        {
            get { return _colour; } // getter for the colour
            set { _colour = value; } // setter for the colour
        }

        // Constructor for the Kuh class
        public Kuh(string? name, string colour)
        {
            // HIER FEHLTE DIE PRÜFUNG:
            // Wenn der Name null oder leer ("") ist, werfen wir die erwartete Exception!
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("Der Name darf nicht leer oder null sein!");
            }

            _name = name;
            _colour = colour;
        }
    }
}
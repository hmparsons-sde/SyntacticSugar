using SyntacticSugar;
using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName
        {
            get => $"{this.Name} the {this.Species}";

        }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        // REMINDER: If a constructor can be implemented as a single statement, you can use an expression body definition
        public string PreyList() => string.Join(",", this.Prey);

        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);

        // Convert this to expression method
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate {food}." : $"{this.Name} is still hungry.";
    }
}
public class Program
{
    static void Main(string[] args)
    {

        List<string> Predators = new List<string>()
            {
                "Arvie",
                "Roman Josi",
                "Pekke Rinne",
                "Scores-berg"
            };

        List<string> Prey = new List<string>(){
                "Ovie",
                "Crosby",
                "Malkin",
                "Subban" };

        var newBug = new Bug("Shea Weber", "Loui Eriksson", Predators, Prey);

        Console.WriteLine(newBug.Eat("Arvie"));
        Console.WriteLine(newBug.FormalName);
    }
}

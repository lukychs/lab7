using System;

namespace ClassLibrary1
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommentAttribute : Attribute
    {
        public string Comment { get; }
        public CommentAttribute(string comment)
        {
            Comment = comment;
        }
    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [Comment("Class Animal")]
    public abstract class Animal
    {
        public abstract string Country { get; set; }
        public abstract bool HideFromOtherAnimals { get; set; }
        public abstract string Name { get; set; }
        public abstract string WhatAnimal { get; set; }

        public Animal(string Country, bool HideFromOtherAnimals, string Name, string WhatAnimal)
        {
            this.Country = Country;
            this.HideFromOtherAnimals = HideFromOtherAnimals;
            this.Name = Name;
            this.WhatAnimal = WhatAnimal;
        }

        public abstract eClassificationAnimal GetClassificationAnimal();
        public abstract eFavouriteFood GetFavouriteFood();
        public abstract string SayHello();

        public void Deconstruct(out string country, out bool hide, out string name, out string whatAnimal)
        {
            country = Country;
            hide = HideFromOtherAnimals;
            name = Name;
            whatAnimal = WhatAnimal;
        }

    }

    [Comment("Class Cow")]
    public class Cow : Animal
    {
        public string country;
        public bool hide;
        public string name;
        public string whatanimal;

        public override string Country { get; set; }
        public override bool HideFromOtherAnimals { get; set; }
        public override string Name { get; set; }
        public override string WhatAnimal { get; set; }

        public Cow(string country, bool hide, string name, string whatanimal, string food) : base(country, hide, name, whatanimal) { }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Meat;

        }

        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Herbivores;
        }

        public override string SayHello()
        {
            return "a";
        }

    }

    [Comment("Class Lion")]
    public class Lion : Animal
    {
        public string country;
        public bool hide;
        public string name;
        public string whatanimal;

        public override string Country { get; set; }
        public override bool HideFromOtherAnimals { get; set; }
        public override string Name { get; set; }
        public override string WhatAnimal { get; set; }

        public Lion(string country, bool hide, string name, string whatanimal, string food) : base(country, hide, name, whatanimal) { }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;

        }

        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Carnivores;
        }

        public override string SayHello()
        {
            return "b";
        }

    }

    [Comment("Class Pig")]
    public class Pig : Animal
    {
        public string country;
        public bool hide;
        public string name;
        public string whatanimal;

        public override string Country { get; set; }
        public override bool HideFromOtherAnimals { get; set; }
        public override string Name { get; set; }
        public override string WhatAnimal { get; set; }

        public Pig(string country, bool hide, string name, string whatanimal, string food) : base(country, hide, name, whatanimal) { }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Everything;

        }

        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Omnivores;
        }

        public override string SayHello()
        {
            return "c";
        }

    }

}
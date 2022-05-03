using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSamling.Models
{
    public partial class Pokemon : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string type;

        


        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string imagePath;

        public static List<Pokemon> GettingStarted => new()
        {
            new Pokemon
            {
                Name = "Bulbasaur",
                Type = "Grass and poison type pokemon",
                Description = "Bulbasaur is a small, quadrupedal amphibian Pokémon that has blue-green skin with darker patches. It has red eyes with white pupils, pointed, ear-like structures on top of its head, and a short, blunt snout with a wide mouth. A pair of small, pointed teeth are visible in the upper jaw when its mouth is open. Each of its thick legs ends with three sharp claws. On Bulbasaur's back is a green plant bulb, which is grown from a seed planted there at birth. The bulb also conceals two slender, tentacle-like vines and provides it with energy through photosynthesis as well as from the nutrient-rich seeds contained within.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/DinDjarin.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            },
            new Pokemon
            {
                Name = "Grogu",
                Type = "Alien",
                Description = "Grogu, known to many simply as 'the Child', was a male Force-sensitive Jedi and Mandalorian foundling who belonged to the same species as Jedi Grand Master Yoda and Jedi Master Yaddle. Grogu was born in the year 41 BBY, and was raised at the Jedi Temple on Coruscant.",
                ImagePath = "/Assets/Grogu.png"
            }
        };

        public Pokemon()
        {
            name = "(new)";
            type = string.Empty;
            description = string.Empty;
            imagePath = "/Assets/*.png";
        }

        public Pokemon Clone()
        {
            return new Pokemon
            {
                Name = $"{Name} clone",
                Type = Type,
                Description = Description,
                ImagePath = ImagePath
            };
        }

        public Pokemon UpdateFrom(Pokemon otherPokemon)
        {
            Name = otherPokemon.Name;
            Type = otherPokemon.Type;
            Description = otherPokemon.Description;
            ImagePath = otherPokemon.ImagePath;

            return this;
        }

        public bool ApplyFilter(string filter)
        {
            return Name.Contains(
                    filter, StringComparison.InvariantCultureIgnoreCase)
                || (Type is not null && Type.Contains(filter, StringComparison.InvariantCultureIgnoreCase))
                || (Description is not null && Description.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}


/*
 * Daniel Brenes
 * Lab 5 ITSE 1430
 * Character Creator
 * Character Class
 * 12/11/2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Web.Models
{
    
    public class CharacterModel// : IValidatableObject
    {
        public CharacterModel ()
        { }

        //public CharacterModel ( Character character )
        //{
        //    Id = character.Id;
        //    Name = character.Name;
        //    Profession = character.Profession;
        //    Race = character.Race;
        //    Strength = character.Strength;
        //    Intelligence = character.Intelligence;
        //    Agility = character.Agility;
        //    Constitution = character.Constitution;
        //    Charisma = character.Charisma;

        //}
        
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Profession { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Race { get; set; }

        [Range(0, 100, ErrorMessage = "Strength must be between 0 and 100.")]
        public int Strength { get; set; }

        [Range(0, 100, ErrorMessage = "Intelligence must be between 0 and 100.")]
        public int Intelligence { get; set; }

        [Range(0, 100, ErrorMessage = "Agility must be between 0 and 100.")]
        public int Agility { get; set; }

        [Range(0, 100, ErrorMessage = "Constitution must be between 0 and 100.")]
        public int Constitution { get; set; }

        [Range(0, 100, ErrorMessage = "Charisma must be between 0 and 100.")]
        public int Charisma { get; set; }       
        
        
        public string Description { get; set; }        
        

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{

            //if (String.IsNullOrEmpty(Name))
            //    yield return new ValidationResult("Name of character is required", new[] { nameof(Name) });

            //if (String.IsNullOrEmpty(Profession))
            //    yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });

            //if (String.IsNullOrEmpty(Race))
            //    yield return new ValidationResult("Race is required", new[] { nameof(Race) });

            //if (Constitution < 0 || Constitution > 100)
            //    yield return new ValidationResult("Constitution must be 50 or greater", new[] { nameof(Name) });

            //if (Charisma < 0 || Charisma > 100)
            //    yield return new ValidationResult("Charisma must be 50 or greater", new[] { nameof(Name) });

            //if (Agility < 0 || Agility > 100)
            //    yield return new ValidationResult("Agility must be 50 or greater", new[] { nameof(Name) });

            //if (Strength < 0 || Strength > 100)
            //    yield return new ValidationResult("Strength must be 50 or greater", new[] { nameof(Name) });

            //if (Intelligence < 0 || Intelligence > 100)
            //    yield return new ValidationResult("Intelligence must be 50 or greater", new[] { nameof(Name) });
        //}
    }
}

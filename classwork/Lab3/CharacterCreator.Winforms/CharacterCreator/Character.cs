/* Daniel Brenes
 * Lab 3 ITSE 1430
 * Character Creator
 * Character Class
 * 10/30/2020
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public int Id { get; set; }
        public string Name
        {
            get {
                return _name ?? "";
            }
            set {
                _name = value;
            }
        }
        private string _name = "";

        public string Profession
        {
            get {
                return _profession ?? "";
            }
            set {
                _profession = value;
            }
        }
        private string _profession = "";

        public string Race
        {
            get {
                return _race ?? "";
            }
            set {
                _race = value;
            }
        }
        private string _race = "";

        public int Strength
        {
            get; set;

        }
        public int Intelligence
        {
            get; set;

        }
        public int Agility
        {
            get; set;

        }
        public int Constitution
        {
            get; set;

        }
        public int Charisma
        {
            get;
            set;

        }


        public string Description
        {
            get;
            set;
        }
        public override string ToString ()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {

            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name of character is required", new[] { nameof(Name) });

            if (String.IsNullOrEmpty(Profession))
                yield return new ValidationResult("Profession is required", new[] { nameof(Profession) });

            if (String.IsNullOrEmpty(Race))
                yield return new ValidationResult("Race is required", new[] { nameof(Race) });

            if (Constitution < 50)
                yield return new ValidationResult("Constitution must be 50 or greater", new[] { nameof(Name) });

            if (Charisma < 50)
                yield return new ValidationResult("Charisma must be 50 or greater", new[] { nameof(Name) });

            if (Agility < 50)
                yield return new ValidationResult("Agility must be 50 or greater", new[] { nameof(Name) });

            if (Strength < 50)
                yield return new ValidationResult("Strength must be 50 or greater", new[] { nameof(Name) });

            if (Intelligence < 50)
                yield return new ValidationResult("Intelligence must be 50 or greater", new[] { nameof(Name) });
        }
    }
}

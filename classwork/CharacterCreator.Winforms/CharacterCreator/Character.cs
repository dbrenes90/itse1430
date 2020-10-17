using System;

namespace CharacterCreator
{
    public class Character
    {
        public int Id { get; private set; }
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
        private string _profession;

        public string Race
        {
            get {
                return _race ?? "";
            }
            set {
                _race = value;
            }
        }
        private string _race;

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
        private int _strength, _intelligence, _agility, _constitution, _charisma;

        public string Description
        {
            get;
            set;
        }
        public override string ToString ()
        {
            return Name;
        }

        public string Validate ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Name is required";

            if (String.IsNullOrEmpty(Profession))
                return "Profession is required";

            if (String.IsNullOrEmpty(Race))
                return "Race is required";

            return null;
        }

    }
}

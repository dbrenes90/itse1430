using System;

namespace CharacterCreator
{
    public class Character
    {
        public string Name
        {
            get 
            {
                return _name ?? "";
            }
            set 
            {
                _name = value;
            }
        }
        private string _name = "";

        public string Profession
        {
            get 
            {
                return _profession ?? "";
            }
            set 
            {
                _profession = value;
            }
        }
        private string _profession;

        public string Race
        {
            get 
            {
                return _race ?? "";
            }
            set 
            {
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

        public string Validate ()
        {
            return null;
        }

    }
}

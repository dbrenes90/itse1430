/* Daniel Brenes
 * Lab 3 ITSE 1430
 * Character Creator
 * Character Database
 * 10/30/2020
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CharacterCreator
{
    public class MemoryCharacterDatabase : ICharacterDatabase
    {
        public Character Add ( Character character, out string error )
        {
            var item = CloneCharacter(character);
            error = "";
            _characters.Add(item);

            character.Id = item.Id;

            return character;

        }
        public void Delete ( int id )
        {

            var character = GetById(id);
            if (character!= null)
            {
                //mus tus the same instance that is stored in the list so ref equality works
                _characters.Remove(character);
            };
        }
        public IEnumerable<Character> GetAll ()
        {
            foreach (var character in _characters)

                yield return CloneCharacter(character);
            ;
        }
        public Character Get ( int id )
        {
            var character = GetById(id);

            //Clone movie if we found it
            return (character!=null) ? CloneCharacter(character) : null;
        }

        private Character GetById ( int id )
        {
            // foreach ( var id in array) Statement
            //for (var index = 0; index<_movies.Length; ++index)
            foreach (var character in _characters)
            {

                if (character?.Id == id)
                    return character;
            };

            return null;
        }
        public string Update ( int id, Character character )
        {
            var existing = GetById(id);
            if (existing == null)
                return "Character not found";
            CopyCharacter(existing, character);

            return "";
        }
        private void CopyCharacter ( Character target, Character source )
        {
            //var item = new Movie();
            //item.Id = movie.Id;
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Strength = source.Strength;
            target.Charisma = source.Charisma;
            target.Constitution = source.Constitution;
            target.Intelligence = source.Intelligence;
            target.Agility = source.Agility;
        }
        private Character CloneCharacter ( Character character )
        {
            var item = new Character();
            item.Id = character.Id;
            CopyCharacter(item, character);
            return item;

        }
        private List<Character> _characters = new List<Character>();
        private int _id = 1;
    }
}

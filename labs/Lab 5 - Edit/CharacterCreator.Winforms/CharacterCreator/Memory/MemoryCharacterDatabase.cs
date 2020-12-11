/* Daniel Brenes
 * Lab 3 ITSE 1430
 * Character Creator
 * Memory Character Database
 * 11/02/2020
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CharacterCreator.Memory
{
    public class MemoryCharacterDatabase : CharacterDatabase
    {
        protected override Character AddCore ( Character character)
        {
            var item = CloneCharacter(character);
            item.Id = _id++;
            _characters.Add(item);

            return character;

        }
        protected override void DeleteCore(int id)
        {              

            var character = FindById(id);
            if (character!= null)
            {
                //mus tus the same instance that is stored in the list so ref equality works
                _characters.Remove(character);
            };
        }
        protected override IEnumerable<Character> GetAllCore ()
        {
            foreach (var character in _characters)

                yield return CloneCharacter(character);
            ;
        }
        private Character FindById ( int id )
        {           
            foreach (var character in _characters)
            {
                if (character?.Id == id)
                    return character;
            };

            return null;
        }
        protected override Character GetByIdCore ( int id)
        {
            var character = FindById(id);

            return (character != null) ? CloneCharacter(character) : null;
        }
        protected override Character GetByName (string name)
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character.Name, name, true) == 0)
                    return CloneCharacter(character);
            };

            return null;
        }
        protected override void UpdateCore ( int id, Character character )
        {
            var existing = FindById(id);            
            CopyCharacter(existing, character);           
        }
        private void CopyCharacter ( Character target, Character source )
        {            
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Strength = source.Strength;
            target.Charisma = source.Charisma;
            target.Constitution = source.Constitution;
            target.Intelligence = source.Intelligence;
            target.Agility = source.Agility;
            target.Description = source.Description;
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

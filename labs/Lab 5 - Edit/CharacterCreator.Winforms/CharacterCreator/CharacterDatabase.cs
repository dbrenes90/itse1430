/* Daniel Brenes
 * Lab 3 ITSE 1430
 * Character Creator
 * Character Database
 * 11/02/2020
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CharacterCreator
{
    public abstract class CharacterDatabase : ICharacterDatabase
    {       
        public Character Add ( Character character, out string error )
        {
            //var item = CloneCharacter(character);
            //item.Id = _id++;
            //error = "";
            //_characters.Add(item);
            //character.Id = item.Id;
            var results = new ObjectValidator().TryValidateFullObject(character);
            if (results.Count() > 0)
            {
                foreach ( var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                }
            }
            var existing = GetByName(character.Name);
            if (existing != null)
            {
                error = "Character name must be unique";
                return null;
            }

            error = null;
            return AddCore(character);
        }
        protected abstract Character AddCore(Character character);
        protected abstract void DeleteCore(int id);

        public void Delete ( int id )
        {
            DeleteCore(id);
        }
        public IEnumerable<Character> GetAll ()
        {
            return GetAllCore();
        }
        protected abstract IEnumerable<Character> GetAllCore();
        public Character Get ( int id )
        {
            return GetByIdCore(id);
        }
        protected abstract Character GetByIdCore(int id);
        protected virtual Character GetByName ( string name)
        {
            foreach ( var character in GetAll())
            {
                if (String.Compare(character.Name, name, true) == 0)
                    return character;
            };
            return null;

        }     
        public string Update ( int id, Character character )
        {
            var results = new ObjectValidator().TryValidateFullObject(character);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    return result.ErrorMessage;
                }
            }
            var existing = GetByName(character.Name);
            if (existing != null && existing.Id!= id)
                return "Character name must be unique";

            UpdateCore(id, character);

            return "";
        }
        protected abstract void UpdateCore(int id, Character character);      
       
    }
}

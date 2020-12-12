/*
 * Daniel Brenes
 * Lab 5 ITSE 1430
 * Character Creator
 * Character Class
 * 12/11/2020
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CharacterCreator
{
    public abstract class CharacterDatabase : ICharacterDatabase
    {       
        public Character Add ( Character character )
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character)); 

            //ObjectValidator.ValidateFullObject(character);
            
            var existing = GetByName(character.Name);
            if (existing != null)
                throw new InvalidOperationException("Character must be unique");

            try
            {
                return AddCore(character);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Add Failed", e);
            };
        }
        protected abstract Character AddCore(Character character);
        protected abstract void DeleteCore(int id);

        public void Delete ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
                DeleteCore(id);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("DeleteFailed", e);
            };
        }
        public IEnumerable<Character> GetAll ()
        {
            try
            {
                return GetAllCore();
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("GetAll Failed", e);
            };
        }
        protected abstract IEnumerable<Character> GetAllCore();
        public Character Get ( int id )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
                return GetByIdCore(id);
            } catch (Exception e)
            {               
                throw new InvalidOperationException("Get Failed", e);
            };
        }
        protected abstract Character GetByIdCore(int id);
        protected virtual Character GetByName ( string name ) => GetAll().FirstOrDefault(x => String.Compare(x.Name, name, true) == 0);
           
        public void Update ( int id, Character character )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            // Character exists //TODO: Movie is valid
           // ObjectValidator.ValidateFullObject(movie);

            // Movie name is unique
            var existing = GetByName(character.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Character must be unique");

            try
            {
                UpdateCore(id, character);
            } catch (Exception e)
            {
                //Throwing a new exception 
                throw new InvalidOperationException("Update Failed", e);
            };
        }
        protected abstract void UpdateCore(int id, Character character);      
       
    }
}

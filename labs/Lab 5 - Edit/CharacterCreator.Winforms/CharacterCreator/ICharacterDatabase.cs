//Daniel Brenes
//ITSE 1430
//11/02/2020
//Character Creator Interface
using System.Collections.Generic;


namespace CharacterCreator
{
    public interface ICharacterDatabase
    {
        /// <summary>Adds a character to the database.</summary>
        /// <param name="character">The character to add.</param>
        /// <param name="error">The error message, if any.</param>
        /// <returns>The new character.</returns>
        Character Add ( Character character );
        /// <summary>
        /// Deletes a character from the database.</summary>
        /// <param name="id">The character to delete.</param>
        void Delete ( int id );
        /// <summary>Gets a character from the database.</summary>
        /// <param name="id">The character to retrieve.</param>
        /// <returns></returns>
        Character Get ( int id );
        /// <summary>Gets all the characters.</summary>
        /// <returns></returns>
        IEnumerable<Character> GetAll ();
        /// <summary>Updates the selected character.</summary>
        /// <param name="id">The character to update.</param>
        /// <param name="character">The name of the character.</param>
        /// <returns></returns>
        void Update ( int id, Character character );
    }
}
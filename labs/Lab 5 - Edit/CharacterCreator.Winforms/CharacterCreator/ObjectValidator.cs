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
using System.Text;

namespace CharacterCreator
{
    public class ObjectValidator
    {
        public IEnumerable<ValidationResult> TryValidateFullObject ( IValidatableObject value )
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), validationResults, true);

            return validationResults;
        }
    }
}

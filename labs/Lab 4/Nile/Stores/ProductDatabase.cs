/* Daniel Brenes
 * Lab 4
 * 12/5/2020
 * ITSE 1430
 */
using System;
using System.Collections.Generic;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            var existing = GetByName(product.Name);
            if (existing != null)
                throw new InvalidOperationException("Product must be unique");
            //TODO: Validate product
            ObjectValidator.ValidateFullObject(product);
            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            try
            {
                return GetCore(id);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Get Failed", e);
            };
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            //try
            //{
                RemoveCore(id);
            //} catch (Exception e)
            //{
             //   throw new InvalidOperationException("Delete Failed", e);
            //};
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update(Product product)
        {
            //Get existing product
            var existing = GetCore(product.Id);


            var namecompare = GetByName(product.Name);

            //TODO: Validate product
            ObjectValidator.ValidateFullObject(product);
            //TODO: Check arguments            
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (product.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Id must be greater than zero");

            if (namecompare != null && namecompare.Id != product.Id)
                throw new InvalidOperationException("Product name must be unique");
            try
            {
                return UpdateCore(existing, product);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Update Failed ", e);
            };
        }

        #region Protected Members
        protected virtual Product GetByName(string name)
        {
            
            foreach (var product in GetAll())
            {
                if (String.Compare(product.Name, name, true) == 0)
                    return product;
            };
            return null;
        }
        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}

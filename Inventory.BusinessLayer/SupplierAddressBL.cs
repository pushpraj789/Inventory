using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Inventory.Contracts.BLContracts;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.DataAccessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.BusinessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting SupplierAddresss from SupplierAddresss collection.
    /// </summary>
    public class SupplierAddressBL : BLBase<SupplierAddress>, ISupplierAddressBL, IDisposable
    {
        //fields
        SupplierAddressDALBase SupplierAddressDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SupplierAddressBL()
        {
            this.SupplierAddressDAL = new SupplierAddressDAL();
        }

        ///// <summary>
        ///// Validations on data before adding or updating.
        ///// </summary>
        ///// <param name="entityObject">Represents object to be validated.</param>
        ///// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        //protected async override Task<bool> Validate(SupplierAddress entityObject)
        //{
        //    //Create string builder
        //    StringBuilder sb = new StringBuilder();
        //    bool valid = await base.Validate(entityObject);

        //    //Email is Unique
        //    var existingObject = await GetSupplierAddressByEmailBL(entityObject.Email);
        //    if (existingObject != null && existingObject?.AddressID != entityObject.AddressID)
        //    {
        //        valid = false;
        //        sb.Append(Environment.NewLine + $"Email {entityObject.Email} already exists");
        //    }

        //    if (valid == false)
        //        throw new InventoryException(sb.ToString());
        //    return valid;
        //}

        /// <summary>
        /// Adds new SupplierAddress to SupplierAddresss collection.
        /// </summary>
        /// <param name="newSupplierAddress">Contains the SupplierAddress details to be added.</param>
        /// <returns>Determinates whether the new SupplierAddress is added.</returns>
        public async Task<bool> AddSupplierAddressBL(SupplierAddress newSupplierAddress)
        {
            bool SupplierAddressAdded = false;
            try
            {
                if (await Validate(newSupplierAddress))
                {
                    await Task.Run(() =>
                    {
                        this.SupplierAddressDAL.AddSupplierAddressDAL(newSupplierAddress);
                        SupplierAddressAdded = true;
                        Serialize();
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressAdded;
        }

        /// <summary>
        /// Gets all SupplierAddresss from the collection.
        /// </summary>
        /// <returns>Returns list of all SupplierAddresss.</returns>
        public async Task<List<SupplierAddress>> GetAllSuppliersAddressesBL()
        {
            List<SupplierAddress> SupplierAddresssList = null;
            try
            {
                await Task.Run(() =>
                {
                    SupplierAddresssList = SupplierAddressDAL.GetAllSuppliersAddressesDAL();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddresssList;
        }

        /// <summary>
        /// Gets SupplierAddress based on SupplierAddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public async Task<SupplierAddress> GetSupplierAddressBySupplierAddressIDBL(Guid searchAddressID)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                await Task.Run(() =>
                {
                    matchingSupplierAddress = SupplierAddressDAL.GetSupplierAddressBySupplierAddressIDDAL(searchAddressID);
                });
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

       
        /// <summary>
        /// Updates SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="updateSupplierAddress">Represents SupplierAddress details including AddressID, SupplierAddressName etc.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public async Task<bool> UpdateSupplierAddressBL(SupplierAddress updateSupplierAddress)
        {
            bool SupplierAddressUpdated = false;
            try
            {
                if ((await Validate(updateSupplierAddress)) && (await GetSupplierAddressBySupplierAddressIDBL(updateSupplierAddress.SupplierAddressID)) != null)
                {
                    this.SupplierAddressDAL.UpdateSupplierAddressDAL(updateSupplierAddress);
                    SupplierAddressUpdated = true;
                    Serialize();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressUpdated;
        }

        /// <summary>
        /// Deletes SupplierAddress based on AddressID.
        /// </summary>
        /// <param name="deleteAddressID">Represents AddressID to delete.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public async Task<bool> DeleteSupplierAddressBL(Guid deleteAddressID)
        {
            bool SupplierAddressDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    SupplierAddressDeleted = SupplierAddressDAL.DeleteSupplierAddressDAL(deleteAddressID);
                    Serialize();
                });
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressDeleted;
        }

        
        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((SupplierAddressDAL)SupplierAddressDAL).Dispose();
        }

        /// <summary>
        /// Invokes Serialize method of DAL.
        /// </summary>
        public void Serialize()
        {
            try
            {
                SupplierAddressDALBase.Serialize();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///Invokes Deserialize method of DAL.
        /// </summary>
        public void Deserialize()
        {
            try
            {
                SupplierAddressDALBase.Deserialize();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
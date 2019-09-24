using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capgemini.Inventory.Contracts.DALContracts;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;

namespace Capgemini.Inventory.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting SupplierAddresss from SupplierAddresss collection.
    /// </summary>
    public class SupplierAddressDAL : SupplierAddressDALBase, IDisposable
    {
        /// <summary>
        /// Adds new SupplierAddress to SupplierAddresss collection.
        /// </summary>
        /// <param name="newSupplierAddress">Contains the SupplierAddress details to be added.</param>
        /// <returns>Determinates whether the new SupplierAddress is added.</returns>
        public override bool AddSupplierAddressDAL(SupplierAddress newSupplierAddress)
        {
            bool SupplierAddressAdded = false;
            try
            {
                newSupplierAddress.SupplierAddressID = Guid.NewGuid();
                SupplierAddressList.Add(newSupplierAddress);
                SupplierAddressAdded = true;
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
        public override List<SupplierAddress> GetAllSuppliersAddressesDAL()
        {
            return SupplierAddressList;
        }

        /// <summary>
        /// Gets SupplierAddress based on SupplierAddressID.
        /// </summary>
        /// <param name="searchSupplierAddressID">Represents SupplierAddressID to search.</param>
        /// <returns>Returns SupplierAddress object.</returns>
        public override SupplierAddress GetSupplierAddressBySupplierAddressIDDAL(Guid searchSupplierAddressID)
        {
            SupplierAddress matchingSupplierAddress = null;
            try
            {
                //Find SupplierAddress based on searchSupplierAddressID
                matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.SupplierAddressID == searchSupplierAddressID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSupplierAddress;
        }

       
        
        /// <summary>
        /// Updates SupplierAddress based on SupplierAddressID.
        /// </summary>
        /// <param name="updateSupplierAddress">Represents SupplierAddress details including SupplierAddressID, SupplierAddressName etc.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public override bool UpdateSupplierAddressDAL(SupplierAddress updateSupplierAddress)
        {
            bool SupplierAddressUpdated = false;
            try
            {
                //Find SupplierAddress based on SupplierAddressID
                SupplierAddress matchingSupplierAddress = GetSupplierAddressBySupplierAddressIDDAL(updateSupplierAddress.SupplierAddressID);

                if (matchingSupplierAddress != null)
                {
                    //Update SupplierAddress details
                    ReflectionHelpers.CopyProperties(updateSupplierAddress, matchingSupplierAddress, new List<string>() { "SupplierAddressLine1", "SupplierAddressLine2", "PinCode","State","City" });
                 

                    SupplierAddressUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressUpdated;
        }

        /// <summary>
        /// Deletes SupplierAddress based on SupplierAddressID.
        /// </summary>
        /// <param name="deleteSupplierAddressID">Represents SupplierAddressID to delete.</param>
        /// <returns>Determinates whether the existing SupplierAddress is updated.</returns>
        public override bool DeleteSupplierAddressDAL(Guid deleteSupplierAddressID)
        {
            bool SupplierAddressDeleted = false;
            try
            {
                //Find SupplierAddress based on searchSupplierAddressID
                SupplierAddress matchingSupplierAddress = SupplierAddressList.Find(
                    (item) => { return item.SupplierAddressID == deleteSupplierAddressID; }
                );

                if (matchingSupplierAddress != null)
                {
                    //Delete SupplierAddress from the collection
                    SupplierAddressList.Remove(matchingSupplierAddress);
                    SupplierAddressDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SupplierAddressDeleted;
        }

        
        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}
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
    /// Contains data access layer methods for inserting, updating, deleting DistributorAddresss from DistributorAddresss collection.
    /// </summary>
    public class DistributorAddressDAL : DistributorAddressDALBase, IDisposable
    {
        /// <summary>
        /// Adds new DistributorAddress to DistributorAddresss collection.
        /// </summary>
        /// <param name="newDistributorAddress">Contains the DistributorAddress details to be added.</param>
        /// <returns>Determinates whether the new DistributorAddress is added.</returns>
        public override bool AddDistributorAddressDAL(DistributorAddress newDistributorAddress)
        {
            bool DistributorAddressAdded = false;
            try
            {
                newDistributorAddress.DistributorAddressID = Guid.NewGuid();
                DistributorAddressList.Add(newDistributorAddress);
                DistributorAddressAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressAdded;
        }

        /// <summary>
        /// Gets all DistributorAddresss from the collection.
        /// </summary>
        /// <returns>Returns list of all DistributorAddresss.</returns>
        public override List<DistributorAddress> GetAllDistributorAddressesDAL()
        {
            return DistributorAddressList;
        }

        /// <summary>
        /// Gets DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="searchAddressID">Represents AddressID to search.</param>
        /// <returns>Returns DistributorAddress object.</returns>
        public override DistributorAddress GetDistributorAddressByDistributorAddressIDDAL(Guid searchAddressID)
        {
            DistributorAddress matchingDistributorAddress = null;
            try
            {
                //Find DistributorAddress based on searchAddressID
                matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.DistributorAddressID == searchAddressID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingDistributorAddress;
        }


        /// <summary>
        /// Updates DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="updateDistributorAddress">Represents DistributorAddress details including AddressID, DistributorAddressName etc.</param>
        /// <returns>Determinates whether the existing DistributorAddress is updated.</returns>
        public override bool UpdateDistributorAddressDAL(DistributorAddress updateDistributorAddress)
        {
            bool DistributorAddressUpdated = false;
            try
            {
                //Find DistributorAddress based on AddressID
                DistributorAddress matchingDistributorAddress = GetDistributorAddressByDistributorAddressIDDAL(updateDistributorAddress.DistributorAddressID);

                if (matchingDistributorAddress != null)
                {
                    //Update DistributorAddress details
                    ReflectionHelpers.CopyProperties(updateDistributorAddress, matchingDistributorAddress, new List<string>() { "DistributorAddressLine1", "DistributorAddressLine2", "PinCode", "City","State" });
                    

                    DistributorAddressUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressUpdated;
        }

        /// <summary>
        /// Deletes DistributorAddress based on AddressID.
        /// </summary>
        /// <param name="deleteAddressID">Represents AddressID to delete.</param>
        /// <returns>Determinates whether the existing DistributorAddress is updated.</returns>
        public override bool DeleteDistributorAddressDAL(Guid deleteAddressID)
        {
            bool DistributorAddressDeleted = false;
            try
            {
                //Find DistributorAddress based on searchAddressID
                DistributorAddress matchingDistributorAddress = DistributorAddressList.Find(
                    (item) => { return item.DistributorAddressID == deleteAddressID; }
                );

                if (matchingDistributorAddress != null)
                {
                    //Delete DistributorAddress from the collection
                    DistributorAddressList.Remove(matchingDistributorAddress);
                    DistributorAddressDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return DistributorAddressDeleted;
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
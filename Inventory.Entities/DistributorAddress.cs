using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for SystemUser Entity
    /// </summary>
    public interface IDistributorAddress
    {
        Guid DistributorAddressID { get; set; }
        Guid DistributorID { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string PinCode { get; set; }
        string City { get; set; }
        string State { get; set; }
    }


    /// <summary>
    /// Represents SystemUser
    /// </summary>
    public class DistributorAddress : IDistributorAddress
    {
        /* Auto-Implemented Properties */
        [Required("Distributor Address ID can't be blank.")]
        public Guid DistributorAddressID { get; set; }

        
        [Required("AddressLine1 should be supplier or  distributor")]
        public string AddressLine1 { get; set; }

        [Required("AddressLine2 should be supplier or  distributor")]
        public string AddressLine2 { get; set; }

        [Required("PinCode should not be blank")]
        public string PinCode { get; set; }

        [Required("City should not be blank")]
        public string City { get; set; }

        [Required("State should not be blank")]
        public string State { get; set; }

        [Required("Distributor  ID can't be blank.")]
        public Guid DistributorID { get; set; }


        public DistributorAddress()
        {
            DistributorAddressID = default(Guid);
            DistributorID = default(Guid);
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            PinCode = string.Empty;
            City = string.Empty;
            State = string.Empty;
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.Inventory.Helpers.ValidationAttributes;

namespace Capgemini.Inventory.Entities
{
    /// <summary>
    /// Interface for SystemUser Entity
    /// </summary>
    public interface ISupplierAddress
    {
        Guid SupplierAddressID { get; set; }
        
        Guid SupplierID { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string PinCode { get; set; }
        string City { get; set; }
        string State { get; set; }
    }


            /// <summary>
            /// Represents SystemUser
            /// </summary>
  public class SupplierAddress : ISupplierAddress
  {
    /* Auto-Implemented Properties */
    [Required("SupplierAddress ID can't be blank.")]
     public Guid SupplierAddressID { get; set; }

    [Required("Supplier ID can't be blank.")]
     public Guid SupplierID { get; set; }

    [Required("AddressLine1 should be supplier or  distributor")]
     public string AddressLine1 { get; set; }

    [Required("AddressLine2 should be supplier or  distributor")]
    public string AddressLine2 { get; set; }

    [Required("City should not be blank")]
     public string City { get; set; }

    [Required("State should not be blank")]
    public string State { get; set; }

    [Required("PinCode should not be blank")]
    [RegExp(@"^[1-9][0-9]{5}$", "Pin Code should contain 6 digits and should not start with 0")]
     public string PinCode { get; set; }





    public SupplierAddress()
    {
        SupplierAddressID = default(Guid);
        SupplierID = default(Guid);
        AddressLine1 = string.Empty;
        AddressLine2 = string.Empty;
        PinCode = string.Empty;
        City = string.Empty;
        State = string.Empty;
        
    }















  }
}

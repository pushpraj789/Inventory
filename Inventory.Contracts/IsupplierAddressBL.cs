using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface ISupplierAddressBL : IDisposable
    {
        Task<bool> AddSupplierAddressBL(SupplierAddress newSupplierAddress);
        Task<List<SupplierAddress>> GetAllSuppliersAddressesBL();
        Task<SupplierAddress> GetSupplierAddressBySupplierAddressIDBL(Guid searchAddressID);
        Task<bool> UpdateSupplierAddressBL(SupplierAddress updateSupplierAddress);
        Task<bool> DeleteSupplierAddressBL(Guid deleteAddressID);
    }
}
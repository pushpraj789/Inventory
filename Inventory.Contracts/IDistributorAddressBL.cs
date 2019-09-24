using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IDistributorAddressBL : IDisposable
    {
        Task<bool> AddDistributorAddressBL(DistributorAddress newDistributorAddress);
        Task<List<DistributorAddress>> GetAllDistributorAddressesBL();
        Task<DistributorAddress> GetDistributorAddressByDistributorAddressIDBL(Guid searchAddressID);
        Task<bool> UpdateDistributorAddressBL(DistributorAddress updateDistributorAddress);
        Task<bool> DeleteDistributorAddressBL(Guid deleteAddressID);
    }
}
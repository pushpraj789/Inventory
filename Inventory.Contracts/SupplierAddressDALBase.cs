using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for SupplierAddressDAL class
    /// </summary>
    public abstract class SupplierAddressDALBase
    {
        //Collection of SupplierAddress
        protected static List<SupplierAddress> SupplierAddressList = new List<SupplierAddress>();
        private static string fileName = "SupplierAddresses.json";

        //Methods for CRUD operations
        public abstract bool AddSupplierAddressDAL(SupplierAddress newSupplierAddress);
        public abstract List<SupplierAddress> GetAllSuppliersAddressesDAL();
        public abstract SupplierAddress GetSupplierAddressBySupplierAddressIDDAL(Guid searchAddressID);
        public abstract bool UpdateSupplierAddressDAL(SupplierAddress updateSupplierAddress);
        public abstract bool DeleteSupplierAddressDAL(Guid deleteSupplierAddressID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(SupplierAddressList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var SupplierAddressListFromFile = JsonConvert.DeserializeObject<List<SupplierAddress>>(fileContent);
                if (SupplierAddressListFromFile != null)
                {
                    SupplierAddressList = SupplierAddressListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static SupplierAddressDALBase()
        {
            Deserialize();
        }
    }
}
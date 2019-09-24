using System;
using System.Collections.Generic;
using System.IO;
using Capgemini.Inventory.Entities;
using Newtonsoft.Json;

namespace Capgemini.Inventory.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for DistributorAddressDAL class
    /// </summary>
    public abstract class DistributorAddressDALBase
    {
        //Collection of DistributorAddress
        protected static List<DistributorAddress> DistributorAddressList = new List<DistributorAddress>();
        private static string fileName = "DistributorAddresses.json";

        //Methods for CRUD operations
        public abstract bool AddDistributorAddressDAL(DistributorAddress newDistributorAddress);
        public abstract List<DistributorAddress> GetAllDistributorAddressesDAL();
        public abstract DistributorAddress GetDistributorAddressByDistributorAddressIDDAL(Guid searchAddressID);
        public abstract bool UpdateDistributorAddressDAL(DistributorAddress updateDistributorAddress);
        public abstract bool DeleteDistributorAddressDAL(Guid deleteDistributorAddressID);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(DistributorAddressList);
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
                var DistributorAddressListFromFile = JsonConvert.DeserializeObject<List<DistributorAddress>>(fileContent);
                if (DistributorAddressListFromFile != null)
                {
                    DistributorAddressList = DistributorAddressListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static DistributorAddressDALBase()
        {
            Deserialize();
        }
    }
}
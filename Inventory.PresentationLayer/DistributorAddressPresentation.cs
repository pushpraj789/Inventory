using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Contracts.BLContracts;

namespace Capgemini.Inventory.PresentationLayer
{
    public static class DistributorPresentation
    {
        /// <summary>
        /// Menu for SystemUser
        /// </summary>
        /// <returns></returns>
        public static async Task<int> DistributorMenu()
        {
            int choice = -2;

            do
            {
                //Menu
                WriteLine("\n***************DISTRIBUTOR***********");
                WriteLine("1. Add Address");
                WriteLine("2. Update Address");
                WriteLine("3. Delete Address");
                WriteLine("4. Veiw All Address");
                WriteLine("-----------------------");
                WriteLine("0. Logout");
                WriteLine("-1. Exit");
                Write("Choice: ");

                //Accept and check choice
                bool isValidChoice = int.TryParse(ReadLine(), out choice);
                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1: await AddDistributorAddress(); break;
                        case 2: await UpdateDistributorAddress(); break;
                        case 3: await DeleteDistributorAddress(); break;
                        case 4: await ViewDistributorAddress(); break;

                        case 0: break;
                        case -1: break;
                        default: WriteLine("Invalid Choice"); break;
                    }
                }
                else
                {
                    choice = -2;
                }
            } while (choice != 0 && choice != -1);
            return choice;
        }

        public static async Task ViewDistributorAddress()
        {
            try
            {
                using (IDistributorAddressBL distributorAddressBL = new DistributorAddressBL())
                {
                    //Get and display list of system users.
                    List<DistributorAddress> distributorsAddress = await distributorAddressBL.GetAllDistributorAddressesBL();
                    WriteLine("DISTRIBUTORS Address:");
                    if (distributorsAddress != null && distributorsAddress?.Count > 0)
                    {
                        WriteLine("#\tAddressLine1\tAddressLine2\tCity\tState\tPincode");
                        int serial = 0;
                        foreach (var distributorAddress in distributorsAddress)
                        {
                            serial++;
                            WriteLine($"{serial}\t{distributorAddress.AddressLine1}\t{distributorAddress.AddressLine2}\t{distributorAddress.City}\t{distributorAddress.State}\t{distributorAddress.PinCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        public static async Task AddDistributorAddress()
        {
            try
            {
                //Read inputs
                DistributorAddress distributorAddress = new DistributorAddress();
                Write("AddressLine1: ");
                distributorAddress.AddressLine1 = ReadLine();
                Write("AddressLine2: ");
                distributorAddress.AddressLine2 = ReadLine();
                Write("City: ");
                distributorAddress.City = ReadLine();
                Write("State: ");
                distributorAddress.State = ReadLine();
                Write("Pincode: ");
                distributorAddress.PinCode = ReadLine();

                //Invoke AddDistributorBL method to add
                using (IDistributorAddressBL distributorAddressBL = new DistributorAddressBL())
                {
                    bool isAdded = await distributorAddressBL.AddDistributorAddressBL(distributorAddress);
                    if (isAdded)
                    {
                        WriteLine("Distributor Address Added");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        public static async Task UpdateDistributorAddress()
        {
            try
            {
                using (IDistributorAddressBL distributorAddressBL = new DistributorAddressBL())
                {
                    //Read Sl.No
                    Write("Distributor Address #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<DistributorAddress> distributorsAddress = await distributorAddressBL.GetAllDistributorAddressesBL();
                        if (serial <= distributorsAddress.Count - 1)
                        {
                            //Read inputs
                            DistributorAddress distributorAddress = distributorsAddress[serial];
                            Write("AddressLine1: ");
                            distributorAddress.AddressLine1 = ReadLine();
                            Write("AddressLine2: ");
                            distributorAddress.AddressLine2 = ReadLine();
                            Write("City: ");
                            distributorAddress.City = ReadLine();
                            Write("State: ");
                            distributorAddress.State = ReadLine();
                            Write("Pincode: ");
                            distributorAddress.PinCode = ReadLine();

                            //Invoke UpdateDistributorAddressBL method to update
                            bool isUpdated = await distributorAddressBL.UpdateDistributorAddressBL(distributorAddress);
                            if (isUpdated)
                            {
                                WriteLine("Distributor Address Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Distributor #.\nPlease enter a number between 1 to {distributorsAddress.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        public static async Task DeleteDistributorAddress()
        {
            try
            {
                using (IDistributorAddressBL distributorAddressBL = new DistributorAddressBL())
                {
                    //Read Sl.No
                    Write("Distributor Address #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<DistributorAddress> distributorsAddress = await distributorAddressBL.GetAllDistributorAddressesBL();
                        if (serial <= distributorsAddress.Count - 1)
                        {
                            //Confirmation
                            DistributorAddress distributorAddress = distributorsAddress[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteDistributorAddressBL method to delete
                                bool isDeleted = await distributorAddressBL.DeleteDistributorAddressBL(distributorAddress.DistributorAddressID);
                                if (isDeleted)
                                {
                                    WriteLine("Distributor Address Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Distributor Address #.\nPlease enter a number between 1 to {distributorsAddress.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }
    }
}
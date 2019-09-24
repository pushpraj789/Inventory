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
    public static class SupplierPresentation
    {
        /// <summary>
        /// Menu for SystemUser
        /// </summary>
        /// <returns></returns>
        public static async Task<int> SupplierMenu()
        {
            int choice = -2;

            do
            {
                //Menu
                WriteLine("\n***************SUPPLIER***********");
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
                        case 1: await AddSupplierAddress(); break;
                        case 2: await UpdateSupplierAddress(); break;
                        case 3: await DeleteSupplierAddress(); break;
                        case 4: await ViewSupplierAddress(); break;

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

        public static async Task ViewSupplierAddress()
        {
            try
            {
                using (ISupplierAddressBL supplierAddressBL = new SupplierAddressBL())
                {
                    //Get and display list of system users.
                    List<SupplierAddress> suppliersAddress = await supplierAddressBL.GetAllSuppliersAddressesBL();
                    WriteLine("SUPPLIER Address:");
                    if (suppliersAddress != null && suppliersAddress?.Count > 0)
                    {
                        WriteLine("#\tAddressLine1\tAddressLine2\tCity\tState\tPincode");
                        int serial = 0;
                        foreach (var supplierAddress in suppliersAddress)
                        {
                            serial++;
                            WriteLine($"{serial}\t{supplierAddress.AddressLine1}\t{supplierAddress.AddressLine2}\t{supplierAddress.City}\t{supplierAddress.State}\t{supplierAddress.PinCode}");
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

        public static async Task AddSupplierAddress()
        {
            try
            {
                //Read inputs
                SupplierAddress supplierAddress = new SupplierAddress();
                Write("AddressLine1: ");
                supplierAddress.AddressLine1 = ReadLine();
                Write("AddressLine2: ");
                supplierAddress.AddressLine2 = ReadLine();
                Write("City: ");
                supplierAddress.City = ReadLine();
                Write("State: ");
                supplierAddress.State = ReadLine();
                Write("Pincode: ");
                supplierAddress.PinCode = ReadLine();

                //Invoke AddSupplierBL method to add
                using (ISupplierAddressBL supplierAddressBL = new SupplierAddressBL())
                {
                    bool isAdded = await supplierAddressBL.AddSupplierAddressBL(supplierAddress);
                    if (isAdded)
                    {
                        WriteLine("Supplier Address Added");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        public static async Task UpdateSupplierAddress()
        {
            try
            {
                using (ISupplierAddressBL supplierAddressBL = new SupplierAddressBL())
                {
                    //Read Sl.No
                    Write("Supplier Address #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SupplierAddress> suppliersAddress = await supplierAddressBL.GetAllSuppliersAddressesBL();
                        if (serial <= suppliersAddress.Count - 1)
                        {
                            //Read inputs
                            SupplierAddress supplierAddress = suppliersAddress[serial];
                            Write("AddressLine1: ");
                            supplierAddress.AddressLine1 = ReadLine();
                            Write("AddressLine2: ");
                            supplierAddress.AddressLine2 = ReadLine();
                            Write("City: ");
                            supplierAddress.City = ReadLine();
                            Write("State: ");
                            supplierAddress.State = ReadLine();
                            Write("Pincode: ");
                            supplierAddress.PinCode = ReadLine();

                            //Invoke UpdateDistributorAddressBL method to update
                            bool isUpdated = await supplierAddressBL.UpdateSupplierAddressBL(supplierAddress);
                            if (isUpdated)
                            {
                                WriteLine("Supplier Address Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Supplier #.\nPlease enter a number between 1 to {suppliersAddress.Count}");
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

        public static async Task DeleteSupplierAddress()
        {
            try
            {
                using (ISupplierAddressBL supplierAddressBL = new SupplierAddressBL())
                {
                    //Read Sl.No
                    Write("Supplier Address #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SupplierAddress> suppliersAddress = await supplierAddressBL.GetAllSuppliersAddressesBL();
                        if (serial <= suppliersAddress.Count - 1)
                        {
                            //Confirmation
                            SupplierAddress supplierAddress = suppliersAddress[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteDistributorAddressBL method to delete
                                bool isDeleted = await supplierAddressBL.DeleteSupplierAddressBL(supplierAddress.SupplierAddressID);
                                if (isDeleted)
                                {
                                    WriteLine("Supplier Address Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Supplier Address #.\nPlease enter a number between 1 to {suppliersAddress.Count}");
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBooksLib;


namespace QBookLib_Test
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}

		static void ItemInventoryTest()
		{
			//**************************************************************************
			//************************** Inventory Item Example  ***********************
			//**************************************************************************

			//Define the return object from methods
			QBError error = null;

			//Create ItemInventorys object
			QBItemInventorys ItemInventorys = new QBItemInventorys();

			//Replace "XXX" below with your ItemInventory Names or you can use  All = true (for the complete ItemInventory List)
			List<string> ItemNameList = new List<string>();
			ItemNameList.Add("XXX");
			ItemNameList.Add("XXX");
			ItemNameList.Add("XXX");

			//Read a list of ItemInventorys in the company file  of Quickbooks that is open.
			error = ItemInventorys.Read("", null, ItemNameList, false, null, true);

			if (error.Status)
				Console.WriteLine("ItemInventory Read Sucessfull");
			else
			{
				Console.WriteLine("Error Reading ItemInventory:" + "\n" + error.Message);   //Display Error Message
				return;
			}


			//Create ItemInventory object
			QBItemInventory ItemInventory = new QBItemInventory();

			//get the first ItemInventory from the list and create a new ItemInventory with the name and "A" in front.
			//Modifying the Name doesn't change the parent FullName
			ItemInventory.Name = "A" + ItemInventorys[0].Name;

			//You need also to provide EditSequence and ListID
			ItemInventory.EditSequence = ItemInventorys[0].EditSequence;
			ItemInventory.ListID = ItemInventorys[0].ListID;

			// Declare a new QBItemInventorys
			QBItemInventorys NewItemInventorys = new QBItemInventorys();

			//Add the previous ItemInventory to the empty NewItemInventorys
			NewItemInventorys.Add(ItemInventory);

			// Modify it using the UI of Quickbooks that is open.
			error = NewItemInventorys.Modify("", true);

			// Check return status
			if (error.Status)
				Console.WriteLine("ItemInventory Modified Sucessfull");
			else
				Console.WriteLine("Error Modifying ItemInventory:" + "\n" + error.Message);   //Display Error Message

		}
		static void ItemNonInventoryTest()
		{
			//**************************************************************************
			//************************** Non-Inventory Item Example  ***********************
			//**************************************************************************

			//Define the return object from methods
			QBError error = null;

			//Create ItemNonInventorys object
			QBItemNonInventorys ItemNonInventorys = new QBItemNonInventorys();

			//Replace "XXX" below with your ItemNonInventory Names or you can use  All = true (for thge complete ItemNonInventory List)
			List<string> ItemNameList = new List<string>();
			ItemNameList.Add("XXX");
			ItemNameList.Add("XXX");
			ItemNameList.Add("XXX");

			//Read a list of ItemNonInventorys in the company file  of Quickbooks that is open.
			error = ItemNonInventorys.Read("", null, ItemNameList, false, null, true);

			if (error.Status)
				Console.WriteLine("ItemNonInventory Read Sucessfull");
			else
			{
				Console.WriteLine("Error Reading ItemNonInventory:" + "\n" + error.Message);   //Display Error Message
				return;
			}


			//Create ItemNonInventory object
			QBItemNonInventory ItemNonInventory = new QBItemNonInventory();

			//get the first ItemNonInventory from the list and create a new ItemNonInventory with the name and "A" in front.
			//Modifying the Name doesn't change the parent FullName
			ItemNonInventory.Name = "A" + ItemNonInventorys[0].Name;

			//You need also to provide EditSequence and ListID
			ItemNonInventory.EditSequence = ItemNonInventorys[0].EditSequence;
			ItemNonInventory.ListID = ItemNonInventorys[0].ListID;

			// Declare a new QBItemNonInventorys
			QBItemNonInventorys NewItemNonInventorys = new QBItemNonInventorys();

			//Add the previous ItemNonInventory to the empty NewItemNonInventorys
			NewItemNonInventorys.Add(ItemNonInventory);

			// Modify it using the UI of Quickbooks that is open.
			error = NewItemNonInventorys.Modify("", true);

			// Check return status
			if (error.Status)
				Console.WriteLine("ItemNonInventory Modified Sucessfull");
			else
				Console.WriteLine("Error Modifying ItemNonInventory:" + "\n" + error.Message);   //Display Error Message

		}
		static void CustomerTest()
		{
			//Define the return object from methods
			QBError error;

			//**************************************************************************
			//************************** Customer Example ******************************
			//**************************************************************************

			//Create Customers object
			QBCustomers Customers = new QBCustomers();

			//Replace "XXX" below with your Customer Names or you can use  All = true (for the complete Customer List)
			List<string> FullNameList = new List<string>();
			FullNameList.Add("XXX");
			FullNameList.Add("XXX");
			FullNameList.Add("XXX");

			//Read complete list of Customers in the company file  of Quickbooks that is open.
			error = Customers.Read("", null, FullNameList, false, null, true);

			// Check return status
			if (error.Status)
				Console.WriteLine("Customer Read Sucessfull");
			else
			{
				Console.WriteLine("Error Reading Customer:" + "\n" + error.Message);   //Display Error Message
				return;
			}

			//Create Customer object
			QBCustomer Customer = new QBCustomer();

			//get the first Customer from the list and create a new Customer with the name and "A" in front.
			Customer.FullName = "A" + Customers[0].FullName;
			Customer.Name = Customer.FullName;

			// Create a new Customers object to use with the Add method
			QBCustomers NewCustomers = new QBCustomers();

			//Add the previous Customer to the empty NewCustomers
			NewCustomers.Add(Customer);

			// Save it in the UI of Quickbooks that is open.
			error = NewCustomers.Save("", true);

			// Check return status
			if (error.Status)
				Console.WriteLine("Customer Saved Sucessfull");
			else
				Console.WriteLine("Error Saving Customer:" + "\n" + error.Message);   //Display Error Message
		}
		static void InvoiceTest()
		{
			//**************************************************************************
			//****************************  Invoice Example ****************************
			//**************************************************************************

			//Define the return object from methods
			QBError error;

			//Create Invoices objects
			QBInvoices Invoices = new QBInvoices();

			//Read a list of Invoices from Today in the company file  of Quickbooks that is open.
			//Repalce "XXX" below with your Invoice numbers
			List<string> RefNumberList = new List<string>();
			RefNumberList.Add("XXX");
			RefNumberList.Add("XXX");
			RefNumberList.Add("XXX");

			error = Invoices.Read("", null, null, null, RefNumberList, null, false, true);


			// Check return status
			if (error.Status)
				Console.WriteLine("Invoices Read Sucessfull");
			else
			{
				Console.WriteLine("Error Reading Invoices:" + "\n" + error.Message);   //Display Error Message
				return;
			}

			//Create Invoice object
			QBInvoice Invoice;

			//get the first Invoice from the list.
			Invoice = Invoices[0];

			//Change the RefNumber to "XX3".
			Invoice.RefNumber = "XX3";

			// Create a new Invoices object to use with the Add method
			QBInvoices NewInvoices = new QBInvoices();

			//Add the previous Invoice to the empty NewInvoices
			NewInvoices.Add(Invoice);

			// Save it in the UI of Quickbooks that is open.
			error = NewInvoices.Save("", true);

			// Check return status
			if (error.Status)
				Console.WriteLine("Invoice Saved Sucessfull");
			else
				Console.WriteLine("Error Saving Invoice:" + "\n" + error.Message);   //Display Error Message

		}
	}
}
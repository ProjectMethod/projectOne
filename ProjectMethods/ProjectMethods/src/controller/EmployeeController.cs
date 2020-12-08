using System;
using System.Collections.Generic;
using System.Text;

using ProjectMethods.service;
using ProjectMethods.model;

namespace ProjectMethods.controller
{
    class EmployeeController
    {
		public InputService inputService = new InputServiceImpl();
		public EmployeeController(InputService inputService)
		{
			this.inputService = inputService;
		}

		public bool employeeLogin(bool logout)
        {
			try { 
				InventoryService inventoryService = new InventoryServiceImpl();
				string choice;
				while (!logout)
				{
					Console.WriteLine("Hello employee. These are requests you must process. \n");
					InventoryServiceImpl.printRequests();
					Console.WriteLine(" - Back to login [b]");
					choice = inputService.pickRequestsToProcessConsoleRead();
					if (choice.Equals("b"))
					{
						logout = true;
					}
					else
					{
						Request request = InventoryService.requests[Int16.Parse(choice)];
						inventoryService.updateRequest(request);
					}
				}
			}
			catch (Exception e)
			{
				return false;
			}
			return true;
		}
    }
}

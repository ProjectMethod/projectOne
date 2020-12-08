using ProjectMethods.model;
using ProjectMethods.service;
using ProjectMethods.service.Transaction;
using System;
using System.Collections.Generic;
using ProjectMethods.controller;

namespace ProjectMethods
{
	class Program
	{
		public static bool confirm = false;
		public static bool bookAgain = false;
		public static bool existingUser = false;
		public static bool logout = false;

		public static InventoryService inventoryService = new InventoryServiceImpl();
		public static TransactionService transactionService = new TransactionServiceImpl();
		public static NotificationService notificationService = new NotificationServiceImpl();

		static void Main(string[] args)
		{
			Program program = new Program(new InputServiceImpl());
			program.startInterface();
		}

		public InputService inputService = new InputServiceImpl();
		
		public Program(InputService inputService)
        {
			this.inputService = inputService;
        }

		UserController userController = new UserController(new InputServiceImpl());
		EmployeeController employeeController = new EmployeeController(new InputServiceImpl());
		public void startInterface()
        {
			UserData newUser = new UserData();
			UserData employee = new UserData();
			employee.Name = "Employee Person";
			employee.Age = 35;
			employee.Email = "employee@email.com";

			Ticket ticket = new Ticket();
			Route newRoute = new Route();

			string choice;

			while (true)
			{
				logout = false;
				bookAgain = false;

				choice = userController.userSelectInterface(newUser, existingUser);

				if (Int16.Parse(choice) == 1)
				{
					//------------------ USER LOGIN --------------------
					// Create New User
					userController.userLogin(existingUser, logout, bookAgain, confirm, employee,
											 inventoryService, transactionService, notificationService);

				}

				//------------------ EMPLOYEE LOGIN -----------------------
				if (Int16.Parse(choice) == 2)
				{
					employeeController.employeeLogin(logout);
				}
			}
		}
	}
}

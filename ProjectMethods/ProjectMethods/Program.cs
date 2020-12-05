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
		static bool confirm = false;
		static bool bookAgain = false;
		static bool existingUser = false;
		static bool logout = false;

		static InventoryService inventoryService = new InventoryServiceImpl();
		static TransactionService transactionService = new TransactionServiceImpl();
		static NotificationService notificationService = new NotificationServiceImpl();

		static void Main(string[] args)
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

				choice = UserController.userSelectInterface(newUser, existingUser);

				if (Int16.Parse(choice) == 1)
				{
					//------------------ USER LOGIN --------------------
					// Create New User
					UserController.userLogin(existingUser, logout, bookAgain, confirm, employee,
						                     inventoryService, transactionService, notificationService);
				
				}

				//------------------ EMPLOYEE LOGIN -----------------------
				if (Int16.Parse(choice) == 2)
				{
					EmployeeController.employeeLogin(logout);
				}
			}
		}
	}
}

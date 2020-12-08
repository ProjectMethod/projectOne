using System;
using System.Collections.Generic;
using System.Text;

using ProjectMethods.service;
using ProjectMethods.service.Transaction;
using ProjectMethods.model;

namespace ProjectMethods.controller
{
    class UserController
    {
		public InputService inputService = new InputServiceImpl();
		public UserController(InputService inputService)
		{
			this.inputService = inputService;
		}

		//static InputServiceImpl inputService = new InputServiceImpl();
		public string userSelectInterface(UserData newUser, Boolean existingUser)
        {
			Console.WriteLine("Welcome. Are you a user or employee of Theta Airlines?");
			if (newUser.Name == null)
			{
				Console.WriteLine(" - New User [1]");
			}
			else
			{
				Console.WriteLine(" - Existing User [1]");
				existingUser = true;
			}
			Console.WriteLine(" - Employee [2]");

			return inputService.pickUserConsoleRead();
		}

        public bool userLogin(Boolean existingUser, Boolean logout, Boolean bookAgain,
			                         Boolean confirm, UserData employee,
									 InventoryService inventoryService, 
									 TransactionService transactionService, NotificationService notificationService)
        {
			try
			{ 
				string choice = "";
				UserData newUser = new UserData();
				Ticket ticket = new Ticket();
				Route newRoute = new Route();
				if (!existingUser)
				{
					Console.WriteLine("Welcome to Theta Airlines. Guess you'd like to go on a plane ride, huh? Well where would you like to go? \n");
					Console.WriteLine("Firstly, we would like to ask some information about you.");
					Console.WriteLine("What is your name?: ");
					choice = inputService.pickNameConsoleRead();
					newUser.Name = choice;
					Console.WriteLine("Age?: ");
					choice = inputService.pickAgeConsoleRead();
					newUser.Age = Int16.Parse(choice);
					Console.WriteLine("Email?: ");
					choice = inputService.pickEmailConsoleRead();
					newUser.Email = choice;
					Console.WriteLine("Now you may choose a destination to go to. \n");
				}

				userCreatingReservationInterface(existingUser, logout, bookAgain, confirm, employee, inventoryService,
									  transactionService, notificationService, ticket, newRoute, newUser);
			} catch (Exception e)
			{
				return false;
			}
			return true;
		}

		public bool userCreatingReservationInterface(Boolean existingUser, Boolean logout, Boolean bookAgain,
									 Boolean confirm, UserData employee,
									 InventoryService inventoryService,
									 TransactionService transactionService, NotificationService notificationService,
									 Ticket ticket, Route newRoute, UserData newUser)
        {
			try
			{
				string choice = "";
				while (!logout)
				{
					confirm = false;
					bookAgain = false;

					if (existingUser)
					{
						Console.WriteLine("Would you like to go to current bookings or book a new flight?");
						Console.WriteLine(" - Current Bookings [1] ");
						Console.WriteLine(" - Book New Flight [2] \n");
						choice = inputService.pickNewBooking();
					}

					// If existing user and wants to book new Flight or new user
					TransactionController transaction = new TransactionController(new InputServiceImpl());
					transaction.transactionInterface(existingUser, logout, bookAgain, confirm, employee, inventoryService,
									  transactionService, notificationService, ticket, newRoute, newUser);

					// Make Notification, go to user existing flights
					logout = userBookingSelectInterface(existingUser, logout, bookAgain, confirm, employee, inventoryService,
									  transactionService, notificationService, ticket, newRoute, newUser);


				}
			} catch (Exception e)
            {
				return false;
            }

			return true;
		}

		public bool userBookingSelectInterface(Boolean existingUser, Boolean logout, Boolean bookAgain,
									 Boolean confirm, UserData employee,
									 InventoryService inventoryService,
									 TransactionService transactionService, NotificationService notificationService,
									 Ticket ticket, Route newRoute, UserData newUser)
        {
			try { 
				string choice = "";
				while (!bookAgain)
				{
					Console.WriteLine("Hello, " + newUser.Name + " you may edit your current bookings:" + " \n");
					// Print - Ticket Number , Source, Destination, Status
					InventoryServiceImpl.printAllTickets();
					Console.WriteLine("Update which ticket?: ");
					choice = inputService.pickTicketListConsoleRead();
					ticket = InventoryService.tickets[Int16.Parse(choice)];
					Console.WriteLine("Edit Ticket " + ticket.TicketNumber + "\n");
					Console.WriteLine(" - Change Seating [1]");
					Console.WriteLine(" - Cancel Ticket [2]");
					Console.WriteLine(" - Back to Login [3]");

					choice = inputService.pickRequestOptionConsoleRead();
					switch (Int16.Parse(choice))
					{
						case 1:
							// Create request to update the seating
							inventoryService.printAvaliableSeats(newRoute);
							choice = inputService.pickNewSeatingConsoleRead();
							string oldSeat = ticket.Seat;
							ticket.Seat = newRoute.seats[Int16.Parse(choice)];
							ticket.status = Ticket.Status.Pending;
							newRoute.seats.RemoveAt(Int16.Parse(choice));
							newRoute.seats.Add(oldSeat);
							inventoryService.createRequest(new Request(ticket));
							Console.WriteLine("Request to change seat created.");
							break;
						case 2:
							ticket.status = Ticket.Status.Canceled;
							inventoryService.createRequest(new Request(ticket));
							Console.WriteLine("Request to Cancel ticket created.");
							break;
						case 3:
							bookAgain = true;
							logout = true;
							break;
						default:
							break;
					}

				}
			} catch (Exception e)
				{
					return false;
				}
			return logout;
		}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using ProjectMethods.service;
using ProjectMethods.service.Transaction;
using ProjectMethods.model;

namespace ProjectMethods.controller
{
    class TransactionController
    {
		static int ticketNumber = 1;

		public InputService inputService = new InputServiceImpl();
		public TransactionController(InputService inputService)
		{
			this.inputService = inputService;
		}

		public bool transactionInterface(Boolean existingUser, Boolean logout, Boolean bookAgain,
									 Boolean confirm, UserData employee,
									 InventoryService inventoryService,
									 TransactionService transactionService, NotificationService notificationService,
									 Ticket ticket, Route newRoute, UserData newUser)
        {
			try { 
				string choice = "";
				if ((existingUser && Int16.Parse(choice) == 2) || !existingUser)
				{
					Console.WriteLine("\nYou can go to: \n");

					// Print avaliable locations and object that holds them
					InventoryServiceImpl.printAllAvaliableLocations();

					// Ask user for their address information
					Console.WriteLine("\nInput: \n");
					choice = inputService.pickDestinationConsoleRead();
					Location destination = InventoryServiceImpl.getAllAvaliableLocations()[Int16.Parse(choice)];
					InventoryServiceImpl.getAllAvaliableLocations().RemoveAt(Int16.Parse(choice));
					newRoute = new Route(destination);
					Console.WriteLine("Where are you coming from?");
					Console.WriteLine("State: ");
					choice = inputService.pickUserStateConsoleRead();
					Location source = new Location(choice);
					Console.WriteLine("City: ");
					choice = inputService.pickUserCityConsoleRead();
					source.City = choice;

					// Initialize Ticket
					newRoute.Source = source;
					ticket.User = newUser;
					ticket.Route = newRoute;
					ticket.TicketNumber = ticketNumber++;

					// Seat Information
					// Say avaliable seats
					inventoryService.printAvaliableSeats(newRoute);
					choice = inputService.integerConsoleRead();
					ticket.Seat = newRoute.seats[Int16.Parse(choice)];
					newRoute.seats.RemoveAt(Int16.Parse(choice));

					// Calculate Price given information
					ticket.Price = inventoryService.calculatePrice(ticket);

					// Tell user all Ticket information
					ticket.toString();

					Console.WriteLine("\nIs this information correct? \n");
					Console.WriteLine("- Confirm [1] ");
					Console.WriteLine("- Deny [2] \n");
					choice = inputService.pickConfirmDenyConsoleRead();

					switch (Int16.Parse(choice))
					{
						case 1:
							Console.WriteLine("A transaction will be created for you to purchase this flight. \n");
							confirm = true;
							break;
						case 2:
							break;
						default:
							Console.WriteLine("Neither are an option. \n");
							break;
					}

					// User can now view their ticket so that they may edit it.
					if (confirm)
					{
						// Payment 
						transactionService.createTransaction(ticket);
						inventoryService.addTicket(ticket);

						// Ask if want to book another flight
						notificationService.sendNotification(new Notification(ticket, "Ticket Needs Approval", employee));
						inventoryService.createRequest(new Request(ticket));

						Console.WriteLine("Would you like to book another flight? \n");
						Console.WriteLine(" - Yes [1]");
						Console.WriteLine(" - No [2] \n");
						choice = inputService.pickBookAnotherConsoleRead();

						if (Int16.Parse(choice) == 1)
						{
							bookAgain = true;
						}
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

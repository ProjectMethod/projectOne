using ProjectMethods.model;
using ProjectMethods.service;
using ProjectMethods.service.Transaction;
using System;
using System.Collections.Generic;

namespace ProjectMethods
{
	class Program
	{
		static void Main(string[] args)
		{
			InventoryService inventoryService = new InventoryServiceImpl();
			TransactionService transactionService = new TransactionServiceImpl();
			NotificationService notificationService = new NotificationServiceImpl();

			UserData newUser = new UserData();
			UserData employee = new UserData();
			employee.Name = "Employee Person";
			employee.Age = 35;
			employee.Email = "employee@email.com";

			Ticket ticket = new Ticket();
			Route newRoute = new Route();

			string choice;
			int ticketNumber = 1;
			bool confirm = false;
			bool bookAgain = false;
			bool existingUser = false;
			bool logout = false;

			while (true)
			{
				logout = false;
				bookAgain = false;

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
				choice = Console.ReadLine();

				if (Int16.Parse(choice) == 1)
				{
					//------------------ USER LOGIN --------------------
					// Create New User
					if (!existingUser)
					{
						Console.WriteLine("Welcome to Theta Airlines. Guess you'd like to go on a plane ride, huh? Well where would you like to go? \n");
						Console.WriteLine("Firstly, we would like to ask some information about you.");
						Console.WriteLine("What is your name?: ");
						choice = Console.ReadLine();
						newUser.Name = choice;
						Console.WriteLine("Age?: ");
						choice = Console.ReadLine();
						newUser.Age = Int16.Parse(choice);
						Console.WriteLine("Email?: ");
						choice = Console.ReadLine();
						newUser.Email = choice;
						Console.WriteLine("Now you may choose a destination to go to. \n");
					}

					while (!logout)
					{
						confirm = false;
						bookAgain = false;

						if (existingUser)
						{
							Console.WriteLine("Would you like to go to current bookings or book a new flight?");
							Console.WriteLine(" - Current Bookings [1] ");
							Console.WriteLine(" - Book New Flight [2] \n");
							choice = Console.ReadLine();
						}

						// If existing user and wants to book new Flight or new user
						if ((existingUser && Int16.Parse(choice) == 2 )|| !existingUser)
						{ 
							Console.WriteLine("\nYou can go to: \n");

							// Print avaliable locations and object that holds them
							InventoryServiceImpl.printAllAvaliableLocations();

							// Ask user for their addres information
							Console.WriteLine("\nInput: \n");
							choice = Console.ReadLine();
							Location destination = InventoryServiceImpl.getAllAvaliableLocations()[Int16.Parse(choice)];
							InventoryServiceImpl.getAllAvaliableLocations().RemoveAt(Int16.Parse(choice));
							newRoute = new Route(destination);
							Console.WriteLine("Where are you coming from?");
							Console.WriteLine("State: ");
							choice = Console.ReadLine();
							Location source = new Location(choice);
							Console.WriteLine("City: ");
							choice = Console.ReadLine();
							source.City = choice;

							// Initialize Ticket
							newRoute.Source = source;
							ticket.User = newUser;
							ticket.Route = newRoute;
							ticket.TicketNumber = ticketNumber++;

							// Seat Information
							// Say avaliable seats
							inventoryService.printAvaliableSeats(newRoute);
							choice = Console.ReadLine();
							ticket.Seat = newRoute.seats[Int16.Parse(choice)];
							newRoute.seats.RemoveAt(Int16.Parse(choice));

							// Calculate Price given information
							ticket.Price = inventoryService.calculatePrice(ticket);

							// Tell user all Ticket information
							ticket.toString();

							Console.WriteLine("\nIs this information correct? \n");
							Console.WriteLine("- Confirm [1] ");
							Console.WriteLine("- Deny [2] \n");
							choice = Console.ReadLine();

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

								// Switch to the User again
								Console.WriteLine("Would you like to book another flight? \n");
								Console.WriteLine(" - Yes [1]");
								Console.WriteLine(" - No [2] \n");
								choice = Console.ReadLine();

								if (Int16.Parse(choice) == 1)
								{
									bookAgain = true;
								}
							}
						}

						// Make Notification, go to user existing flights
						while (!bookAgain)
						{
							Console.WriteLine("Hello, " + newUser.Name + " you may edit your current bookings:" + " \n");
							// Print - Ticket Number , Source, Destination, Status
							InventoryServiceImpl.printAllTickets();
							Console.WriteLine("Update which ticket?: ");
							choice = Console.ReadLine();
							ticket = InventoryService.tickets[Int16.Parse(choice)];
							Console.WriteLine("Edit Ticket " + ticket.TicketNumber + "\n");
							Console.WriteLine(" - Change Seating [1]");
							Console.WriteLine(" - Cancel Ticket [2]");
							Console.WriteLine(" - Back to Login [3]");

							choice = Console.ReadLine();
							switch (Int16.Parse(choice))
							{
								case 1:
									// Create request to update the seating
									inventoryService.printAvaliableSeats(newRoute);
									choice = Console.ReadLine();
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
						
					}
				}

				//------------------ EMPLOYEE LOGIN -----------------------
				if (Int16.Parse(choice) == 2)
				{

					while (!logout)
					{
						Console.WriteLine("Hello employee. These are requests you must process. \n");
						inventoryService.printRequests();
						Console.WriteLine(" - Back to login [b]");
						choice = Console.ReadLine();
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

			}
		}
	}
}

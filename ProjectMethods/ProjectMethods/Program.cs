using ProjectMethods.models;
using ProjectMethods.service;
using System;

namespace ProjectMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            string choice;
            while (true)
            {
                Console.WriteLine("Welcome to Theta Airlines. Guess you'd like to go on a plane ride, huh? Well where would you like to go? \n");
                Console.WriteLine("You can go to: \n");
                // Should have a call that sees all available addresses
                // Then assumes city you're coming from? If new user ask for that?
                // Then pick avaliable route given destination.
                // Pick seat then payment information.
                InventoryServiceImpl.getAllAvaliableRoutes();
                Console.WriteLine("Input: ");
                choice = Console.ReadLine();
                Ticket ticket = new Ticket();
            }
        }
    }
}

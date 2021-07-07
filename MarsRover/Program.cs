using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Rover myRover = new Rover(20);
            //Console.WriteLine(myRover.ToString());

            //Rover newRover = new Rover(98382);
            //Command[] commands = { new Command("MOVE", 5000) };
            //Message newMessage = new Message("Test message with one command", commands);

            Rover newRover = new Rover(5000);
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("Test message with one command", commands);

            Console.WriteLine(newRover.ToString());

            newRover.ReceiveMessage(newMessage);
            Console.WriteLine(newRover.ToString());
        }
    }
}

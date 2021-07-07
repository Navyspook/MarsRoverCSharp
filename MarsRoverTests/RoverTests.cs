using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        Command[] commands;
        Message newMessage;
        Rover newRover;

        [TestInitialize]
        public void CreateCommandAndMessageObjects()
        {
            commands = new Command[] { new Command("MOVE", 5000) };
            newMessage = new Message("Test message with one command", commands);
            newRover = new Rover(98382);
        }

        //8
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Assert.AreEqual(newRover.Position, 98382);
        }

        //9
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Assert.AreEqual(newRover.Mode, "NORMAL");
        }

        //10
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Assert.AreEqual(newRover.GeneratorWatts, 110);
        }

        //11
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover newRover = new Rover(5000);
            commands = new Command[] { new Command("MODE_CHANGE", "LOW_POWER") };
            newMessage = new Message("Test message with one command", commands);
            newRover.ReceiveMessage(newMessage);

            Assert.AreEqual(newRover.Mode, "LOW_POWER");

        }

        //12
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { (new Command("MODE_CHANGE", "LOW_POWER")), (new Command("MOVE", 5000)) };
            Message newMessage = new Message("Test message with one command", commands);
            newRover.ReceiveMessage(newMessage);

            try
            {
                newRover.ReceiveMessage(newMessage);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Rover can't move while in LOW_POWER mode", ex.Message);
            }

        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 5000);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands;

        [TestInitialize]
        public void CreateCommandObject()
        {
            commands = new Command[] { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };

        }

        //5
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Message name required.")]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            new Message(null, null);
        }

        //6
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("Sending commands.", commands);
            Assert.AreEqual(newMessage.Name, "Sending commands.");
        }

        //7
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("Sending commands.", commands);
            Assert.AreEqual(newMessage.Commands, commands);
        }

    }
}

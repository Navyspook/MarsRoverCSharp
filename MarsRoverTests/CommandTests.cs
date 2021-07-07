using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;

namespace MarsRoverTests
{
    [TestClass]
    public class CommandTests
    {

        //1
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Command type required")]
        public void ArgumentNullExceptionThrownIfCommandTypeIsNullOrEmpty()
        {
                new Command(null);
        }

        //2
        [TestMethod]
        public void ConstructorSetsCommandType()
        {
            Command newCommand = new Command("MOVE", 0);
            Assert.AreEqual(newCommand.CommandType, "MOVE");
        }

        //3
        [TestMethod]
        public void ConstructorSetsInitialNewPositionValue()
        {
            Command newCommand = new Command("MOVE", 20);
            Assert.AreEqual(newCommand.NewPosition, 20);
        }

        //4
        [TestMethod]
        public void ConstructorSetsInitialNewModeValue()
        {
            Command newCommand = new Command("MODE_CHANGE", "LOW_POWER");
            Assert.AreEqual(newCommand.NewMode, "LOW_POWER");
        }

    }
}

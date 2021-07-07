using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPosition { get; set; }
        public string NewMode { get; set; }


        public Command() { }

        public Command(string commandType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else if ((commandType != "MOVE") || (commandType != "MODE_CHANGE"))
            {
                throw new ArgumentOutOfRangeException("Command Type can only accept MOVE or MODE_CHANGE.");
            }
 
        }

        public Command(string commandType, int value)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            NewPosition = value;
        }

        public Command(string commandType, string modeType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }

            if ((modeType == "LOW_POWER") || (modeType == "NORMAL"))
            {
                NewMode = modeType;
            }          
            else
            {
                throw new ArgumentOutOfRangeException("Mode can only be set to LOW_POWER or NORMAL.");
            }


        }

    }
}

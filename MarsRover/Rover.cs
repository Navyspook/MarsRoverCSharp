using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts;
        }



        public void ReceiveMessage(Message message)
        {
            Command[] cmdArray = message.Commands;

            try
            {
                foreach (Command cmd in cmdArray)
                {
                    if (cmd.CommandType == "MODE_CHANGE")
                    {
                        Mode = cmd.NewMode;
                    }

                    else
                    {
                        Position = cmd.NewPosition;
                    }
                }
            }
            catch
            {
                if ((Mode == "LOW_POWER") && (Position >= 0))
                {
                    throw new ArgumentOutOfRangeException("Rover can't move while in LOW_POWER mode");
                }
            }
            
        }




    }
}

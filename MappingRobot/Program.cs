using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            /*This seemed like it would normally come in a file, but since the input was specifically a line and not a file I just put it in a string 
            if we were going to have the input be outside of the Main method as an argument, I would also include a check for a null string and throw a NullReferenceException
            */
           // String input = "2017-01-02; Advertising Agency; R3, R3, R3, L2";
            String input = "2017-01-01; Coffee Shop; L2, L5, L5, R5, L2";
            //first split the date and location 
            String[] details = input.Split(';');
            String date = details[0];
            String location = details[1];
            //Then we split the directions into an array
            String[] directions = details[2].Split(',');

            /*instantiate a robot with the date, location, and directions.  I wasn't sure if the date and location would belong to the Robot, but decided to have those as Robot params
            as they are a part of the Robot output and actions */
            Robot mapBot = new Robot(date, location, directions);

            //only call made from the Program class because all other methods will be called by the Robot 
           mapBot.determineRobotMoves(directions);

        }
 
    }
}

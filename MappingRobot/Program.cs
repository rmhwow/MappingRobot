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
           //Other inputs with which to test.
            // String input = "2017-01-02; Advertising Agency; R3, R3, R3, L2";
            String input = "2017-01-01; Coffee Shop; L2, L5, L5, R5, L2";
            //String input = "";
            try
            {
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
            catch (NullReferenceException e)
            {
                Console.WriteLine("Input needs to be a string");
              
            }
            catch (Exception e) {
                Console.WriteLine("Something went wrong. Please make sure your input is a non-empty string.");
                
            }
        }
    }
}

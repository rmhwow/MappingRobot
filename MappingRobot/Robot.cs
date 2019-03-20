using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRobot
{
    //Necessary to create a Robot class for encapsulation and abstraction pruposes.  The Program shouldn't know all the robot actions or perform them
    class Robot
    {

        //Robot Constructor.  I made the assumption that in our input we would receive these elements and so there wouldn't be a need for another constructor
        public Robot(String date, String location, String[] directions)
        {
            this.directions = directions;
            this.date = date;
            this.location = location;
        }
        //Getter and Setter for array of directions 
        public String[] directions {
            get {
                return this.directions;
            }
            set {
                this.directions = directions;
            }
        }
        //Getter and Setter for the date
        public String date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = date;
            }
        }
        //Getter and Setter for the location
        public String location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = location;
            }
        }

        //Displays the Output as demonstrated in puzzle file
        public void printRoute(String date, String location, String[] shortRoute)
        {
            Console.WriteLine(date + "; " + location + "; " + shortRoute[0] + ", " + shortRoute[1]);    
        }

        //The first direction will be that "up or down" motion, change the negative numbers to be "L" and the positive numbers to be "R" and return the string with the direction and num
        public String determineFirstDirection(int up, int across)
        {
            String direction;
            if (up < 0)
            {
                //make the number positive to be displayed
                direction = "L" + (up * -1);
            }
            else if (up > 0)
            {
                direction = "R" + up;
            }
            else
            {
                if (across < 0)
                {
                    direction = "L" + up;
                }
                else
                {
                    direction = "R" + up;
                }
            }
            return direction;
        }
        //Determine how many paces across.  Also determined whether the negative or positive number is L or R based on the Up and Down direciton
        public String determineSecondDirection(int across, int up, String firstd)
        {
            String direction = null;

            if (across < 0 && firstd.Contains("L"))
            {
                //make the number positive to be displayed
                direction = "R" + (across * -1);
            }
            else if (across < 0 && firstd.Contains("R"))
            {    
                direction = "L" + (across * -1);
            }
            else if (across > 0 && firstd.Contains("R"))
            {
                direction = "R" + across;
            }
            else if (across < 0 && firstd.Contains("R"))
            {    
                direction = "L" + (across * -1);
            }
            return direction;
        }
        /*determine the shortest route based on the number of positive moves made by the robot originally*/
        public void shortestRoute(int[] coordinates)
        {
            int[] cord = coordinates;
            //determining if the first move is "L" or "R" and the num of spaces
            String firstDirection = determineFirstDirection(cord[0], cord[1]);

            //determining if the second move is "L" or "R" and the num of spaces
            String secondDirection = determineSecondDirection(cord[1], cord[0], firstDirection);
            
            String[] finaldirect = new String[] { firstDirection, secondDirection };
            
            //call printRoute to display results
            printRoute(this.date, this.location, finaldirect);
        }
        /* Determining the first coordinate to say how far "up and down" does the robot need to move to have the shortest route. 
        A lot of the inner logic in this method is repetitive, with more time,
        I'd love to separate these out to make "positive move and negative move" and less dependency on the "L" and "R"  */
        public int moveUpOrDown(String curr, String prev, int currnum)
        {
            int currentnum = currnum;
            //for the first move in general going Left will mean a negative number 
            if (curr.Contains("L") && prev == null)
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());

                //make this negative since we're moving down 
                d *= -1;
                currentnum = currentnum + d;
                return currentnum;
            }
            //for the first move in general going Right will mean a positive number 
            if (curr.Contains("R") && prev == null)
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }
            //moving positively
            if (curr.Contains("L") && prev.Contains("L"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }
            //moving positively
            else if (curr.Contains("L") && prev.Contains("R"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
               
                currentnum = currentnum + d;
                return currentnum;
            }
            //moving negatively (going down)
            else if (curr.Contains("R") && prev.Contains("R"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
               
                d *= -1;
                currentnum = currentnum + d;
                return currentnum;
            }
            // moving negatively (going down)
            else
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                d *= -1;
                currentnum = currentnum + d;
                return currentnum;
            }
        }

        /* Determining the second coordinate to say how far "left and rigth " does the robot need to move to have the shortest route. 
        A lot of the inner logic in this method is repetitive, with more time, I'd love to separate these out to make "positive move and negative move" and less dependency on the "L" and "R"  */
        public int moveAcross(String curr, String prev, int currnum)
        {
            //unlike moveUpAndDown we don't have to worry about the prev being null because the first action will always be an up or down 
            int currentnum = currnum;

            if (curr.Contains("L") && prev.Contains("L"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }
            else if (curr.Contains("L") && prev.Contains("R"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }
            else if (curr.Contains("R") && prev.Contains("R"))
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }
            else
            {
                String move = curr;
                int d = int.Parse(move[move.Length - 1].ToString());
                currentnum = currentnum + d;
                return currentnum;
            }


        }
        /* Robot moves are going up and down or left and right on a grid path (x/y radius). To solve the problem I decided to have coordinate 1 represent the "Up and Down" number AKA how many
        steps up and down the robot as moved.  Any initial "Left" motion is a negative num and "right" is positive. Up/Down movements are always the even number moves and Across movements are always the odd number moves.  Coordinate 2 represents the "Across" motion any initial left motion is negative and
        right is positive.  Once we have more than one motion, the system check what the previous move was and then determines if that up/down and across motion should either be a positive or negative number. 
        */
        public void determineRobotMoves(String[] moves)
        {
            int[] coordinates = new int[] { 0, 0 };
            string[] m = moves;
            
            for (int i = 0; i < m.Length; i++)
            {
                //to represent the move directly before the current move
                int j = i - 1;
                //first move total we sent the current string, null as the precendent, and 0 as the total spaces
                if (i == 0)
                {
                    coordinates[0] = moveUpOrDown(m[i], null, 0);
                }
                //even number move we sent the current string,  precendent string, and the current total spaces moved
                if (i % 2 == 0 && i > 0)
                {
                    coordinates[0] = moveUpOrDown(m[i], m[j], coordinates[0]);
                }
                //odd number means we're goig across, we send the current string, precedent string, and the total spaces moved
                else if (i % 2 != 0)
                {
                    coordinates[1] = moveAcross(m[i], m[j], coordinates[1]);

                }

            }
            //call the shortestRoute so we can determine from the total coordinates moved what is the shortest route to take
            shortestRoute(coordinates);
            
        }
    }
}

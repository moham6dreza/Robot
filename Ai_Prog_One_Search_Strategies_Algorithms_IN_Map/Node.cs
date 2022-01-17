using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public class Node
    {

        /* Node Data Structure
         * 
         * 				(Node)
         * 		 ____________________
         * 		| x,y |	g,h,f |	type |
         * 		|_____|_______|______|
         * 		|parent |	in path? |
         * 		|_______|____________|
         *		|	neighbors(8)	 |
         *		|____________________|
         *		| neighbors_g_cost(8)|
         *		|	(one step cost)  |
         * 		|____________________|
         * 
         * 
         */
        // G(n) the cost of the path from the initial to n
        private double g;
        // F(n) = H(n) + G(n) that estimates the cost of the cheapest path from n to
        // goal
        private double f;
        // H(n) the heuristic cost from n to goal
        private double h;
        // cost of each movement
        // public int gCost;

        // type of node if wall type=3 if goal type=2 if initial type=1 if open type=0
        private string type;
        // coordinates
        private int x;
        private int y;
        // Successors of current Node
        private ArrayList neighbors;
        // cost of each successors if basic move cost=1 or diagonal move cost=1.1
        private ArrayList neighbors_gCost;
        // parent node for path
        private Node parent = null;
        // the flag for check are we in the path?
        private bool inPath = false;

        // the match function checks type of node and its coordinates is equal with
        // current node
        public bool isMatch(Node n)
        {
            if (n != null)
                return (x == n.x && y == n.y && this.type == n.getType());
            else
                return false;
        }

        /*
         * Constructor of node Set all information of current node
         */
        public Node(int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            // this.gCost = gCost;
            this.type = type;
            this.parent = null;
            this.g = 0.00d;
            this.h = 0.00d;
            this.f = 0.00d;
            // this.gCost = 0;
            // max number of successors is 8 because :
            /*
             * 		|* |* |* |
             * 		|* |n |* | 
             * 		|* |* |* |
             */
            neighbors = new ArrayList(8);
            neighbors_gCost = new ArrayList(8);
        }

        public int getX()
        {
            return this.x;
        }

        public void setX(int n)
        {
            this.x = n;
        }

        public int getY()
        {
            return this.y;
        }

        public void setY(int n)
        {
            this.y = n;
        }

        public double getH()
        {
            return this.h;
        }

        public void setH(double n)
        {
            this.h = n;
        }

        public double getF()
        {
            return this.f;
        }

        public void setF(double n)
        {
            this.f = n;
        }

        public double getG()
        {
            return this.g;
        }

        public void setG(double n)
        {
            this.g = n;
        }

        public void setType(string n)
        {
            this.type = n;
        }

        public string getType()
        {
            return this.type;
        }

        public void Add_Neighbors_And_Those_Step_gCost(Node n, double cost)
        {
            if (!n.isObstacle())// check for not adding walls as neighbor
            {
                this.getNeighbors().Add(n);
                this.getNeighbors_gCost().Add(cost);
            }
        }

        public ArrayList getNeighbors_gCost()
        {
            return this.neighbors_gCost;
        }

        public ArrayList getNeighbors()
        {
            return this.neighbors;
        }

        public Node getParent()
        {
            return this.parent;
        }

        public void setParent(Node n)
        {
            this.parent = n;
        }

        public bool isPath()
        {
            return this.inPath;
        }

        public void setPath()
        {
            this.inPath = true;
        }
        public bool isObstacle()
        {
            return this.getType() == "W";
        }
    }
}

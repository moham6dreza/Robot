using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public class Strategy
    {
        SortedCostNodeList Fringe;
        SortedCostNodeList Visited;
        /**
         * basic properties
         * */
        private readonly Node initial;
        private readonly Node goal;
        private Node[,] Map;

        /**
         * Counters for counting searched and expanded nodes from initial to goal
         * */
        public int Searched_Nodes_for_AStar = 0;
        public int Expanded_Nodes_for_AStar = 0;
        //
        public int Searched_Nodes_for_BFS = 0;
        public int Expanded_Nodes_for_BFS = 0;
        //
        public int Searched_Nodes_for_DFS = 0;
        public int Expanded_Nodes_for_DFS = 0;

        /**
         * if this flag is true that means we have reached to the goal
         * */
        public bool pathFound = false;

        public bool Heuristic;

        public ArrayList Path_Route_List;

        public void Clear_PathRouteList()
        {
            this.Path_Route_List.Clear();
        }

        /**
         * Constructor of class
         * 			set all properties
         * 				set the cost of initial node to zero and set its heuristic
         * 					and set the heuristic of goal node to zero
         * */
        public Strategy(Node initial, Node goal, Node[,] map, int choice_search)
        {
            Visited = new SortedCostNodeList(choice_search);
            Fringe = new SortedCostNodeList(choice_search);
            Path_Route_List = new ArrayList();
            this.initial = initial;
            this.goal = goal;
            this.Map = map;
            //
            this.initial.setG(0.00d);
            this.Evaluate_Heuristic_Manhattan_Distance(this.initial);
            this.Evaluate_F(this.initial);
            //
            this.goal.setH(0.000);
            Heuristic = true;
        }

        public Strategy(Node initial, Node goal, Node[,] map)
        {
            Path_Route_List = new ArrayList();
            this.initial = initial;
            this.goal = goal;
            this.Map = map;
        }


        /**
         *	Heuristic Function from current node to goal
         * */

        private void Evaluate_Heuristic_Manhattan_Distance(Node current)
        {
            // if we are not at goal state calculate distance
            if (current.isMatch(this.goal) == false)
            {
                /**
                 * h = |x1 - x2| + |y1 - y2|
                 * */
                current.setH(
                        Math.Abs(current.getX() - this.goal.getX())
                                + Math.Abs(current.getY() - this.goal.getY())
                             );
            }
            else { current.setH(0.000); }
        }

        /**
         *	Heuristic Function from current node to goal
         * */

        private void Evaluate_Heuristic_Euclidean_Distance(Node current)
        {
            /** if we are not at goal state calculate distance */
            if (current.isMatch(this.goal) == false)
            {
                /**
                 * 		 _________________________
                 * h = ,/(x1 - x2)^2 + (y1 - y2)^2
                 * */
                current.setH(Math.Sqrt(Math.Pow((current.getX() - goal.getX()), 2)
                        + Math.Pow((current.getY() - goal.getY()), 2)));
            }
            else { current.setH(0.000); }
        }
        /**
         * 	calculate cost from initial to current node
         * */
        private void Evaluate_G(Node current, double gCost)
        {
            /*
            if(current.getParent() != null)
            {
                current.setG(current.getParent().getG() + current.neighbors_gCost.get(index));
            }
            else {
                current.setG(current.neighbors_gCost.get(index));
            }
            */
            //sum of the node's parent cost and node's current gCost
            if (current.getParent() != null)
                current.setG(current.getParent().getG() + gCost);
            else { current.setG(gCost); }
        }

        /**
         * Calculate the total cost of current node
         * 			F(n) = H(n) + G(n)
         * */
        private void Evaluate_F(Node current)
        {
            current.setF(current.getG() + current.getH());
        }

        /**
         * if goal test is true
         * then we are backtrack through parents to initial node
         * 		and enable the flag of every one of them
         * */
        private void getPath(Node n)
        {
            //receive a goal node
            Node current = n;
            //until node has not arrived to the initial
            while (current.getType() != "S") // node type 1 is initial
            {
                /** not initial
                 * backtrack through parents and use boolean marker
                 * to indicate path before reaching the initial node
                 * */
                current.setPath();
                this.Path_Route_List.Add(current);
                current = current.getParent();
            }
            this.Path_Route_List.Add(current);
            //Array.Reverse(this.Path_Route_List.ToArray());
        }

        public void FancyDisplay()
        {
            int xmap = this.Map.GetLength(0);
            int ymap = this.Map.GetLength(1);
            //Console.WriteLine("{0} {1} {2} {3} {4} {5}", xmap, ymap,imap.GetLength(0),imap.GetLength(1),imap.GetLowerBound(0),imap.GetLowerBound(1));
            //int path_len = 2;
            if (!pathFound)
            {
                Console.WriteLine("No path found");
                return;
            }
            Console.Write("\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    Console.Write("     ");
                }
                else
                {
                    Console.Write("|    |");
                }
            }
            Console.Write("\n\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    Console.Write("     ");
                }
                else
                {
                    Console.Write("|GOAL|");
                }
            }
            Console.Write("\n\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    Console.Write("     ");
                }
                else
                {
                    Console.Write("| ^^ |");
                }
            }
            //System.out.println("the search area");
            Console.Write("\n\t" + "+");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    Console.Write("----+");
                }
                else
                {
                    Console.Write("    +");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < xmap; i++)
            {
                if (i != 7)
                {
                    Console.Write("\t" + "|");
                }
                else
                {
                    Console.Write("   GO  >" + " ");
                }
                for (int j = 0; j < ymap; j++)
                {
                    if (Map[i, j].getType() == "R") // open route
                    {
                        if (Map[i, j].isPath())
                        {
                            //boolean tracker of what nodes are in the path
                            Console.Write("  * " + "|");
                            //path_len++;
                        }
                        else
                        {
                            Console.Write("    " + "|");
                        }
                    }
                    else if (Map[i, j].getType() == "S") //initial
                    {
                        Console.Write(" *  " + "|");
                    }
                    else if (Map[i, j].getType() == "G") //goal
                    {
                        Console.Write("  * " + "|");
                    }
                    else if (Map[i, j].getType() == "W") // wall
                    {
                        Console.Write("Wall" + "|");
                    }
                }
                Console.WriteLine();
                if (i == 6 || i == 7)
                {
                    Console.Write(" -------+");
                }
                else
                {
                    Console.Write("\t" + "+");
                }
                for (int k = 0; k < ymap; k++)
                {
                    Console.Write("----+");
                }
                Console.WriteLine();
            }
            //System.out.println("\nLength of this path is : " + path_len);

            Console.WriteLine();
            Console.WriteLine("Coordinates of path to Goal is : ");
            for (int i = this.Path_Route_List.Count - 1; i >= 0; i--)
            {
                //System.out.print("(" + this.Path_Route_List.get(i).getX() + ", " + this.Path_Route_List.get(i).getY() + ")");
                Console.Write("(" + (((Node)this.Path_Route_List[i]).getY() + 1) + ", " + (this.Map.GetLength(0) - ((Node)this.Path_Route_List[i]).getX()) + ")");
                if (i != 0)
                {
                    Console.Write(":");
                }
            }
            //System.out.println();
            Console.WriteLine("\nPath len :  " + this.Path_Route_List.Count);
            //this.Clear_PathRouteList();
        }
        /**
         * implement the A star algorithm
         * process nodes with total cost of each node
         * */
        public void AStar()
        {
            //List of Visited nodes
            //List<Node> Visited = new List<Node>();
            //Fringe is a Priority Queue
            //List<Node> Fringe = new List<Node>();
            //Add initial node to the fringe
            //Fringe.Add(this.initial);



            Fringe.push(this.initial);
            //Searching until fringe is not empty
            while (Fringe.Count != 0)
            {
                //Select
                Node current = Fringe.pop();
                //Add node to the visited list
                Visited.push(current);

                //increase counter of searching
                this.Searched_Nodes_for_AStar++;
                //Goal Test
                if (current.isMatch(this.goal))
                {
                    //Enable flag
                    pathFound = true;
                    //Get the path from goal to initial
                    getPath(current);
                    //Clear lists to stop searching
                    Fringe.clear();
                    //Visited.clear();
                }//Expand
                else
                {
                    for (int i = 0; i < current.getNeighbors().Count; i++)
                    {
                        //For all the neighbors
                        Node neighbor = (Node)(current.getNeighbors()[i]);
                        //if the nodes is not exist in the visited list and fringe
                        if (Fringe.contains(neighbor) == false && Visited.contains(neighbor) == false)
                        {
                            //set node's parent
                            neighbor.setParent(current);

                            //Calculate heuristic function Euclidaen distance or manhattan distance
                            if (Heuristic)
                            {
                                this.Evaluate_Heuristic_Euclidean_Distance(neighbor);
                            }
                            else { this.Evaluate_Heuristic_Manhattan_Distance(neighbor); }

                            //Calculate Cost from initial node
                            this.Evaluate_G(neighbor, Convert.ToDouble(current.getNeighbors_gCost()[i]));
                            //Calculate the total cost
                            this.Evaluate_F(neighbor);

                            //add node to the fringe
                            Fringe.push(neighbor);
                            //increase counter of expanding
                            this.Expanded_Nodes_for_AStar++;
                        }
                    }
                }
            }
        }

        public void DFS()
        {
            //Fringe is a LIFO stack
            Stack stack = new Stack();
            //List of Visited nodes
            ArrayList Visited = new ArrayList();

            //Add initial node to the fringe
            stack.Push(this.initial);

            //Searching nodes until fringe isn't empty
            while (stack.Count != 0)
            {
                //Select
                Node current = (Node)stack.Pop();
                //Add node to the visited list
                Visited.Add(current);

                //increase counter of searching
                this.Searched_Nodes_for_DFS++;
                //Goal Test
                if (current.isMatch(this.goal))
                {
                    //Enable flag
                    pathFound = true;
                    //Get the path from goal to initial
                    getPath(current);
                    //Clear lists to stop searching
                    stack.Clear();
                    //Visited.clear();
                }//Expand
                else
                {
                    //for (Node neighbor : n.getNeighbors())
                    for (int i = 0; i < current.getNeighbors().Count; i++)
                    {
                        //For all the neighbors
                        Node neighbor = (Node)current.getNeighbors()[i];
                        //if the nodes is not exist in the visited list and fringe
                        if (stack.Contains(neighbor) == false && Visited.Contains(neighbor) == false)
                        {
                            //add node to the fringe
                            stack.Push(neighbor);
                            //set node's parent
                            neighbor.setParent(current);
                            //increase counter of expanding
                            this.Expanded_Nodes_for_DFS++;
                        }
                    }
                }
            }
        }

        public void BFS()
        {

            //Fringe is a FIFO Queue
            Queue queue = new Queue();
            //List of visited nodes
            ArrayList Visited = new ArrayList();

            //add the initial node to the fringe
            queue.Enqueue(this.initial);

            //Searching nodes until fringe isn't empty
            while (queue.Count != 0)
            {
                //Select
                Node current = (Node)queue.Dequeue();
                //add node to the visited list
                Visited.Add(current);
                //increase counter of searching
                this.Searched_Nodes_for_BFS++;
                //Goal Test
                if (current.isMatch(this.goal))
                {
                    ///Enable flag
                    pathFound = true;
                    //Get the path from goal to initial
                    getPath(current);
                    //Clear lists to stop searching
                    queue.Clear();
                    //Visited.clear();
                }//Expand
                else
                {
                    //for (Node neighbor : n.getNeighbors())
                    for (int i = 0; i < current.getNeighbors().Count; i++)
                    {
                        //For all the neighbors
                        Node neighbor = (Node)current.getNeighbors()[i];
                        //if the nodes is not exist in the visited list and fringe
                        if (queue.Contains(neighbor) == false && Visited.Contains(neighbor) == false)
                        {
                            //add node to the fringe
                            queue.Enqueue(neighbor);
                            //set node's parent
                            neighbor.setParent(current);
                            //increase counter of expanding
                            this.Expanded_Nodes_for_BFS++;
                        }
                    }
                }
            }
        }
    }
}

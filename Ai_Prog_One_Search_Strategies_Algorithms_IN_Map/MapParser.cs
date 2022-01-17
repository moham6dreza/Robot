using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public class MapParser
    {
        public double BASIC_MOVEMENT_COST;
        public double DIAGONAL_MOVEMENT_COST;

        public Node initial, goal;
        private int xmap;
        private int ymap;
        public Node[,] Map;

        static int[,] imap =
            {
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3, 0, 0},
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0},
            {0 ,0 ,1 ,1 ,1 ,0 ,0 ,1 ,1 ,1, 0, 0},
            {0 ,0 ,1 ,1 ,1 ,0 ,0 ,1 ,1 ,1, 0, 0},
            {0 ,0 ,1 ,1 ,1 ,0 ,0 ,1 ,1 ,1, 0, 0},
            {0 ,0 ,1 ,1 ,1 ,0 ,0 ,1 ,1 ,1, 0, 0},
            {2 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,1 ,1, 0 ,0},
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0},
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0, 0 ,0}
        };

        public MapParser()
        {
            /*
            Random r = new Random(GetHashCode() * DateTime.Now.Millisecond);
            BASIC_MOVEMENT_COST = r.NextDouble();
            DIAGONAL_MOVEMENT_COST = r.NextDouble();
            */
            BASIC_MOVEMENT_COST = 1.10;
            DIAGONAL_MOVEMENT_COST = 1.00;
            this.xmap = imap.GetLength(0);
            this.ymap = imap.GetLength(1);
            this.Map = new Node[xmap, ymap];
        }

        public void Parse()
        {
            for (int i = 0; i < xmap; i++)
            {
                for (int j = 0; j < ymap; j++)
                {
                    if (imap[i, j] == 2) //initial
                    {
                        Node T = new Node(i, j, "S");
                        this.Map[i, j] = T;
                        this.initial = T;
                    }
                    if (imap[i, j] == 3)//goal
                    {
                        Node T = new Node(i, j, "G");
                        this.Map[i, j] = T;
                        this.goal = T;
                    }
                    if (imap[i, j] == 0)//open
                    {
                        this.Map[i, j] = new Node(i, j, "R");
                    }
                    if (imap[i, j] == 1)//wall
                    {
                        this.Map[i, j] = new Node(i, j, "W");
                    }
                }
            }

            for (int i = 0; i < xmap; i++)
            {
                for (int j = 0; j < ymap; j++)
                {
                    this.buildNeighbors(this.Map[i, j], i, j);
                }
            }
        }

        public void buildNeighbors(Node n, int row, int col)
        {
            int xMapSize = xmap;
            int yMapSize = ymap;
            /*
            * check the current node not to be the wall
            * **/
            if (n.getType() != "W")
            {
                if (row == 0)
                {//Check for edge cases where neighbor amount will vary
                    if (col == 0)
                    {
                        /*

                         0	1
                        +--+--+
                       0|n |* |			* :Position of each neighbors
                       1|* |* |			n :Position of parent

                        0	1
                        +---+---+
                       0| n |1.1|		: Cost of each neighbors
                       1|1.1| 1 |

                        */
                        // Horizontal - Vertical Movement

                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);   // Horizontal - Vertical Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);
                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col + 1], DIAGONAL_MOVEMENT_COST);    // Diagonal Cost
                    }
                    else if (col == yMapSize - 1)
                    {
                        /*

                         10 11
                        +--+--+
                        |* |n |0			* :Position of each neighbors
                        |* |* |1			n :Position of parent


                         10   11
                        +---+---+
                        |1.1| n |0			: Cost of each neighbors
                        | 1 |1.1|1

                         */
                        // Horizontal - Vertical Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);   // Horizontal - Vertical Cost 
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);

                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col - 1], DIAGONAL_MOVEMENT_COST); // Diagonal Cost 
                    }
                    else
                    {
                        /*

                          4	 5  6
                         +--+--+--+
                        0|* |n |* |				* :Position of each neighbors
                        1|* |* |* |				n :Position of parent

                           4   5   6
                         +---+---+---+
                        0|1.1| n |1.1|			: Cost of each neighbors
                        1| 1 |1.1| 1 |

                         */

                        // Horizontal - Vertical Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);  // Horizontal - Vertical Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);

                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col - 1], DIAGONAL_MOVEMENT_COST);    // Diagonal Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col + 1], DIAGONAL_MOVEMENT_COST);
                    }
                }
                else if (row == xMapSize - 1)
                {
                    if (col == yMapSize - 1)
                    {
                        /*

                        |* |* |7				* :Position of each neighbors
                        |* |n |8				n :Position of parent
                        +--+--+
                         10 11

                        | 1 |1.1|7			: Cost of each neighbors
                        |1.1| n |8
                        +---+---+
                         10  11

                         */

                        // Horizontal - Vertical Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);   // Horizontal - Vertical Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);

                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col - 1], DIAGONAL_MOVEMENT_COST);   // Diagonal Cost
                    }
                    else if (col == 0)
                    {
                        /*

                       7|* |* |				* :Position of each neighbors
                       8|n |* |				n :Position of parent
                        +--+--+
                         0  1


                        7|1.1| 1 |			: Cost of each neighbors
                        8| n |1.1|
                         +---+---+
                           0   1
                         */

                        // Horizontal - Vertical Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);    // Horizontal - Vertical Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);

                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col + 1], DIAGONAL_MOVEMENT_COST);    // Diagonal Cost
                    }
                    else
                    {
                        /*

                        |* |* |* |				* :Position of each neighbors
                        |* |n |* |				n :Position of parent
                        +--+--+--+
                         4  5  6


                        | 1 |1.1| 1 |			: Cost of each neighbors
                        |1.1| n |1.1|
                        +---+---+---+
                         4    5   6


                         */

                        // Horizontal - Vertical Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);   // Horizontal - Vertical Cost
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);

                        //Diagonal Movement
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col - 1], DIAGONAL_MOVEMENT_COST);   // Diagonal Cost 
                        n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col + 1], DIAGONAL_MOVEMENT_COST);
                    }
                }
                else if (col == 0)
                {
                    /*
                       0  1
                    4 |* |* |				* :Position of each neighbors
                    5 |n |* |				n :Position of parent
                    6 |* |* |


                       0    1
                    4 |1.1| 1 |
                    5 | n |1.1|				: Cost of each neighbors
                    6 |1.1| 1 |


                     */

                    // Horizontal - Vertical Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);   // Vertical Movement down
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);   // Vertical Movement up
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);   // Horizontal Movement right

                    //Diagonal Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col + 1], DIAGONAL_MOVEMENT_COST);   //Diagonal Movement left-up
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col + 1], DIAGONAL_MOVEMENT_COST);   //Diagonal Movement right-up
                }
                else if (col == yMapSize - 1)
                {
                    /*
                       10 11
                      |* |* | 4					* :Position of each neighbors
                      |* |n | 5					n :Position of parent
                      |* |* | 6


                       10  11
                      | 1 |1.1| 4
                      |1.1| n | 5			: Cost of each neighbors
                      | 1 |1.1| 6

                     */

                    // Horizontal - Vertical Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);

                    //Diagonal Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col - 1], DIAGONAL_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col - 1], DIAGONAL_MOVEMENT_COST);
                }
                else
                {
                    /*
                         4  5  6
                        |* |* |* | 4				* :Position of each neighbors
                        |* |n |* | 5				n :Position of parent
                        |* |* |* | 6


                          4   5   6
                        | 1 |1.1| 1 | 4
                        |1.1| n |1.1| 5				: Cost of each neighbors
                        | 1 |1.1| 1 | 6
                     */

                    // Horizontal - Vertical Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col], BASIC_MOVEMENT_COST);   // down
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col], BASIC_MOVEMENT_COST);   // up
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row, col - 1], BASIC_MOVEMENT_COST);   // left
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row, col + 1], BASIC_MOVEMENT_COST);   // right

                    //Diagonal Movement
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col + 1], DIAGONAL_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row + 1, col - 1], DIAGONAL_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col + 1], DIAGONAL_MOVEMENT_COST);
                    n.Add_Neighbors_And_Those_Step_gCost(Map[row - 1, col - 1], DIAGONAL_MOVEMENT_COST);
                }
            }
        }
    }
}

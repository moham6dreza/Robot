using System;

namespace Ai_Prog_Two_Genetic_Algorithm
{
    class Node
    {
        public int x;
        public int y;
        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Node() { }

        public static bool Equal(Node n1, Node n2)
        {
            return n1.x == n2.x && n1.y == n2.y;
        }
        /*
        public static bool operator ==(Node a, Node b)
        {
            if (a.x == b.x && a.y == b.y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Node a, Node b)
        {
            if (a.x == b.x && a.y == b.y)
                return false;
            else
                return true;
        }
        */
    }
    class Chromosome : ICloneable
    {
        public Node[] Chromo = new Node[GA.CSize];
        public double F = 0; //fitness
        public double L = 0; // path length
        private double a = 1000; //zaribe length
        public int T = 0; //number of obstacle intersection
        private double b = -1; //zaribe intersection



        public Chromosome()
        {
            Chromo[0] = new Node(GA.startx, GA.starty);           //Chromo[0] = (13,0)
            Chromo[GA.CLindex] = new Node(GA.finalx, GA.finaly);  //Chromo[24] = (0,9)
            int X, Y;
            for (int i = 1; i < GA.CLindex; i++)
            {
                Chromo[i] = new Node();        //Chromo[1...23] = (null,null)
                GA.getNewXY(out X, out Y);
                Chromo[i].x = X;    //Chromo[1...23].x = 0...16
                Chromo[i].y = Y;    //Chromo[1...23].y = 0...16
            }

        }
        public object this[int index]
        {
            get { return Chromo[index]; }
            set { /* set the specified index to value here */ }
        }

        private double pathLength(Node a, Node b)
        {
            return (Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2)));
        }
        /// <summary>
        /// check path intercetion with obstacles
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="OBS"></param>
        /// <returns></returns>
        private bool CheckIntercetion(Node A, Node B, Node[,] OBS)
        {
            for (int i = 0; i < OBS.GetLength(1); i++) // 0,1,...,7
            {
                if (LinesIntersect(A, B, OBS[0, i], OBS[1, i]))
                    return true;
            }
            return false;
        }

        static bool LinesIntersect(Node A, Node B, Node C, Node D)
        {
            Node CmP = new Node(C.x - A.x, C.y - A.y);
            Node r = new Node(B.x - A.x, B.y - A.y);
            Node s = new Node(D.x - C.x, D.y - C.y);

            float CmPxr = CmP.x * r.y - CmP.y * r.x;
            float CmPxs = CmP.x * s.y - CmP.y * s.x;
            float rxs = r.x * s.y - r.y * s.x;

            if (CmPxr == 0f)
            {
                // Lines are collinear, and so intersect if they have any overlap

                return ((C.x - A.x < 0f) != (C.x - B.x < 0f))
                    || ((C.y - A.y < 0f) != (C.y - B.y < 0f));
            }

            if (rxs == 0f)
                return false; // Lines are parallel.

            float rxsr = 1f / rxs;
            float t = CmPxs * rxsr;
            float u = CmPxr * rxsr;

            return (t >= 0f) && (t <= 1f) && (u >= 0f) && (u <= 1f);
        }

        public double FitnessCalc()
        {
            L = 0;
            T = 0;
            for (int i = 0; i < GA.CLindex; i++) //0,1,...,23
            {
                L += pathLength(Chromo[i], Chromo[i + 1]);
                if (CheckIntercetion(Chromo[i], Chromo[i + 1], GA.OBS))
                    T++;

            }
            F = Math.Round(a / L + b * T, 3); // (1000/path-len) + (-1*obs-intersections)
            // Console.WriteLine(T +"  "+ F);
            //F = ( a / L + b * T);
            return F;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
            // throw new NotImplementedException();
        }
    }
    class GA
    {
        //play options
        public static bool FancyDisplay = true; // show both result : best and current
        public static bool DoubleFancyDisplay = false;
        public static bool SimpleDisplay = false;
        public static bool WaitForKey = true;
        public static bool ClearOnEnd = true;
        public static bool NotIntersect = true;


        #region a
        //genetic configs
        public static Random r = new Random();
        public static int PSize = 100, CSize = 25; //population and Chromosome size
        public static int PLindex = 99, CLindex = 24; //population and Chromosome array last index
        public static int startx = 13, starty = 0, finalx = 0, finaly = 9;
        // x is row and y is column
        public static int[,] map =
        {
            {0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0},// 0
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},// 1
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 2
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 3
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 4
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 5
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 6
            {0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0},// 7
            {0,0,0,1,1,1,1,1,0,0,0,1,1,1,0,0},// 8
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},// 9
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},// 10
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},// 11
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},// 12
            {2,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},// 13
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},// 14
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},// 15
          // 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 
        };
        //obstacle lines
        public static Node[,] OBS =
        {
            {new Node(2,3),new Node(2,3),new Node(2,7),new Node(8,7),new Node(8,11),new Node(8,11),new Node(14,11),new Node(8,14) },
            {new Node(8,3),new Node(2,7),new Node(8,7),new Node(8,3),new Node(8,14),new Node(14,11),new Node(14,14),new Node(14,14) }
        };

        //functions
        public static bool isObstacle(Node a)
        {
            if (map[a.x, a.y] == 1)
                return true;
            return false;
        }
        public static bool isObstacle(int x, int y)
        {

            if (GA.NotIntersect && map[x, y] == 1)
                return true;
            return false;
        }
        public static void BubbleSort(Chromosome[] p)
        {
            bool swapped;
            // Chromosome temp = new Chromosome();
            Chromosome temp;
            for (int i = 0; i < p.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < p.Length - i - 1; j++)
                {
                    if (p[j].F < p[j + 1].F)
                    {
                        temp = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }
        private int getNewX(int y)
        {
            Random r = new Random(GetHashCode() * DateTime.Now.Millisecond);
            int newx = r.Next(0, 16);
            while (isObstacle(newx, y))//تا زمانی که باایکس جدید مانع باشد
            {
                newx = r.Next(0, 16);
            }
            return newx;
        }
        private int getNewY(int x)
        {
            Random r = new Random(GetHashCode() * DateTime.Now.Millisecond);
            int newy = r.Next(0, 16);

            while (isObstacle(x, newy))
            {
                newy = r.Next(0, 16);
            }
            return newy;
        }
        public static void getNewXY(out int x, out int y)
        {
            x = 1;
            // Random r = new Random(x.GetHashCode() * DateTime.Now.Millisecond);
            int newy = r.Next(0, 16);
            int newx = r.Next(0, 16);
            while (isObstacle(newx, newy))
            {
                newx = r.Next(0, 16);
                newy = r.Next(0, 16);
            }
            x = newx;
            y = newy;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">population</param>
        public void CrossOver(Chromosome[] p)
        {
            Random r = new Random(GetHashCode());
            int pc; //crossover point
            int pclow = Convert.ToInt32(CSize * 0.6);//25*0.6=15 int
            int pchigh = Convert.ToInt32(CSize * 0.9);//25*0.9=22 int

            int ph = PSize / 2;//100/2=50
            int child1, child2; //new childrens index

            for (int i = 0; i < ph; i += 2)//0,2,4,6...48 => 25 ta
            {
                pc = r.Next(pclow, pchigh);//15...22

                child1 = i + ph; //0+25, 2+25, 4+25, ...,48+25 => 25 ta
                child2 = i + ph + 1; //1+25, 3+25, 5+25, ...,49+25 => 25 ta

                p[child1] = new Chromosome();
                p[child2] = new Chromosome();
                //p[25...74] 
                for (int j = 0; j < CSize; j++)// 0...25
                {
                    if (j < pc)//0,1,2,...25 < 15...22
                    {
                        p[child1][j] = p[i][j];    //p[25,27...73][0,1...]=p[0,2...48][0,1...]
                        p[child2][j] = p[i + 1][j];//p[26,28...74][0,1...]=p[1,3...49][0,1...]
                    }
                    else
                    {
                        p[child1][j] = p[i + 1][j];//p[25,27...73][0,1...]=p[1,3...48][0,1...]
                        p[child2][j] = p[i][j];    //p[26,28...74][0,1...]=p[0,2...49][0,1...]
                    }

                }

            }
        }
        #endregion a
        public void Mutate(Chromosome[] p)
        {

            int pm; //mutation rate
            int pmlow = Convert.ToInt32((1.0 / PSize) * 100);// pmlow=1
            int pmhigh = Convert.ToInt32((1.0 / CSize) * 100);// pmhigh=4
            int m_point; //mutation point
            //int x, y;
            for (int i = 0; i < PSize; i++)//0,1,2,...,100
            {
                if (headOrTail())//headOrTail() if random num > 500 head and true go to this if
                {
                    pm = r.Next(0, pmhigh); //mutation rate = 0,1,2,3,4
                    while (pm > 0)
                    {
                        m_point = r.Next(1, GA.CLindex - 1); // mutation point = 1,2,...,23
                        if (headOrTail())
                        {
                            //this function give a population of 100 chromosoms
                            //Every Chromosomes makes from 25 number of Nodes that has x, y
                            p[i].Chromo[m_point].x = getNewX(p[i].Chromo[m_point].y);// p[0,1,...].Chromo[1,2,...,23].x = 0,1,...,16
                        }
                        else
                        {
                            p[i].Chromo[m_point].y = getNewY(p[i].Chromo[m_point].x);// p[0,1,...].Chromo[1,2,...,23].y = 0,1,...,16
                        }
                        //getNewXY(out x, out y);
                        //p[i].Chromo[m_point] = new Node(x, y);
                        pm--; //mutation rate --
                    }
                }
            }
        }
        private bool headOrTail()
        {
            //Random r = new Random(GetHashCode() * DateTime.Now.Millisecond);
            int t = r.Next(0, 1000);
            if (t > 500)
            {
                //  Console.WriteLine("head");
                return true;
            }
            //Console.WriteLine("tail");
            return false;
        }
    }

    class Program
    {
        static void FancyDisplay(string[,] dotmap, string title)
        {

            Console.WriteLine();
            Console.Write("           " + "+");
            for (int j = 0; j < 16; j++)
            {
                Console.Write("----+");
            }
            Console.WriteLine();
            for (int i = 0; i < 16; i++)
            {
                Console.Write("           " + "|");
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(dotmap[i, j] + "|");
                }
                Console.WriteLine();
                Console.Write("           " + "+");
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("----+");
                }
                Console.WriteLine();
            }
        }
        static void DoubleFancyDisplay(int generation, double last_improve, string[,] dotmap1, string title1, double F1, int T1
                                   , double L1, string[,] dotmap2, string title2, double F2, int T2, double L2)
        {
            last_improve = Math.Round(last_improve, 2);
            L1 = Math.Round(L1, 2);
            L2 = Math.Round(L2, 2);
            double F1percent = Math.Round(F1 * 100 / 63, 2);
            double F2percent = Math.Round(F2 * 100 / 63, 2);

            Console.WriteLine("Generation = " + generation + " End!" + "Fitness = " + F2 + " improvement = " + last_improve);
            // Console.WriteLine("Intersection = " + T1 + "  " + "  Length = " + L2);

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("           " + title1 + "                                            " + title2);
            Console.WriteLine();
            Console.Write("   Fitness = " + F1percent + "%   Intersection = " + T1 + "  Length = " + L1 +
                          "     Fitness = " + F2percent + "%  Intersection = " + T2 + "  " + "  Length = " + L2);
            Console.WriteLine();
            Console.Write("   +");
            for (int j = 0; j < 16; j++)
            {
                Console.Write("--+");
            }
            Console.Write("       +");
            for (int j = 0; j < 16; j++)
            {
                Console.Write("--+");
            }
            Console.WriteLine();


            for (int i = 0; i < 16; i++)
            {
                Console.Write("   |");
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(dotmap1[i, j] + "|");

                }
                Console.Write("       |");  // space in middle
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(dotmap2[i, j] + "|");

                }

                Console.WriteLine();
                Console.Write("   +");
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("--+");
                }
                Console.Write("       +");
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("--+");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {


            GA GA = new GA();
            Chromosome[] Population = new Chromosome[GA.PSize];
            for (int i = 0; i < Population.Length; i++)
            {
                Population[i] = new Chromosome();

            }
            Chromosome MostFittest = new Chromosome();
            MostFittest.FitnessCalc();

            /*
            Chromosome BestFittest = new Chromosome();
            int[] bestx = { 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
            int[] besty = { 1, 2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9};

            for (int i = 1; i < GA.CLindex; i++)
            {
                BestFittest.Chromo[i].x = bestx[i-1];
                BestFittest.Chromo[i].y = besty[i-1];
            }
            BestFittest.FitnessCalc();
            */

            double last_improve = 0, last_fittest = 0;
            int generation = 1;
            do
            {

                if (generation > 1)
                {
                    for (int i = 50; i < Population.Length; i += 2)
                    {
                        Population[i] = new Chromosome();
                    }
                    GA.CrossOver(Population);
                    GA.Mutate(Population);
                }

                for (int i = 0; i < Population.Length; i++)
                {

                    Population[i].FitnessCalc();
                    // Console.WriteLine(p[i].F);
                }
                GA.BubbleSort(Population);
                string[,] dotmapBest, dotmapCurrent = new string[16, 16];

                string[,] dotmap = new string[16, 16];
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (GA.map[i, j] == 1)
                        {
                            dotmapCurrent[i, j] = "WALL";
                            dotmap[i, j] = "BB";
                        }
                        else
                        {
                            dotmapCurrent[i, j] = "    ";
                            dotmap[i, j] = "  ";
                        }
                    }
                }

                dotmapBest = (string[,])dotmap.Clone();
                for (int i = 0; i < GA.CSize; i++)
                {
                    if (i < 10)
                    {
                        dotmapCurrent[Population[0].Chromo[i].x, Population[0].Chromo[i].y] = "   " + i.ToString();
                        dotmap[Population[0].Chromo[i].x, Population[0].Chromo[i].y] = " " + i.ToString();
                    }
                    else
                    {
                        dotmapCurrent[Population[0].Chromo[i].x, Population[0].Chromo[i].y] = "  " + i.ToString();
                        dotmap[Population[0].Chromo[i].x, Population[0].Chromo[i].y] = i.ToString();
                    }

                }
                last_improve = Population[0].F - last_fittest;
                last_fittest = Population[0].F;
                //max
                if (Population[0].F > MostFittest.F)
                    MostFittest = (Chromosome)Population[0].Clone();

                for (int i = 0; i < GA.CSize; i++)
                {
                    if (i < 10)
                        dotmapBest[MostFittest.Chromo[i].x, MostFittest.Chromo[i].y] = " " + i.ToString();
                    else
                        dotmapBest[MostFittest.Chromo[i].x, MostFittest.Chromo[i].y] = i.ToString();

                }

                if (GA.DoubleFancyDisplay)
                {
                    DoubleFancyDisplay
                                    (
                                      generation
                                    , last_improve
                                    , dotmapBest
                                    , "Fittest of all time"
                                    , MostFittest.F
                                    , MostFittest.T
                                    , MostFittest.L
                                    , dotmap
                                    , "Fittest of this gen"
                                    , Population[0].F
                                    , Population[0].T
                                    , Population[0].L
                                    );

                }
                else if (GA.FancyDisplay)
                {
                    Console.WriteLine("Generation = " + generation + " End!" + "Fitness = " + Population[0].F + " improvement = " + last_improve);
                    Console.WriteLine("Intersection = " + Population[0].T + "  " + "  Length = " + Population[0].L);

                    Console.WriteLine("Best Fitness of all generations = " + MostFittest.F);
                    FancyDisplay(dotmapCurrent, "fitness");
                }
                else if (GA.SimpleDisplay)
                {

                    //if (generation % 1000 == 0)
                    {
                        Console.WriteLine("Generation = " + generation + " End!" + "Fitness = " + Population[0].F + " improvement = " + last_improve);
                        Console.WriteLine("Intersection = " + Population[0].T + "  " + "  Length = " + Population[0].L);

                        Console.WriteLine("Best Fitness of all generations = " + MostFittest.F);

                        Console.WriteLine();
                        Console.WriteLine();

                        for (int i = 0; i < 16; i++)
                        {
                            Console.Write("           " + "|");
                            for (int j = 0; j < 16; j++)
                            {
                                Console.Write(dotmapCurrent[i, j] + "|");
                            }
                            Console.WriteLine();

                        }
                    }
                }

                //generation%1000==0 &&
                if (GA.WaitForKey)
                {
                    Console.WriteLine("press any key to continue...");
                    Console.ReadKey();
                }
                //System.Threading.Thread.Sleep(600);
                if (GA.ClearOnEnd)
                    Console.Clear();
                generation++;

            } while (true);

        }

    }
}
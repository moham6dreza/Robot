using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public partial class Mainform : Form
    {
        ArrayList comparison = new ArrayList(5);
        MapParser MAP;
        Strategy s;

        public Mainform()
        {
            InitializeComponent();
        }

        public void Display(Strategy s, MapParser MAP)
        {
            for (int i = s.Path_Route_List.Count - 1; i >= 0; i--)
            {
                int j = 0;
                listBox1.Items.Add("(" + (((Node)s.Path_Route_List[i]).getY() + 1) + ", " + (MAP.Map.GetLength(0) - ((Node)s.Path_Route_List[i]).getX()) + ")");
                j++;
            }
            int xmap = MAP.Map.GetLength(0);
            int ymap = MAP.Map.GetLength(1);
            StringBuilder builder = new StringBuilder();
            //Console.WriteLine("{0} {1} {2} {3} {4} {5}", xmap, ymap,imap.GetLength(0),imap.GetLength(1),imap.GetLowerBound(0),imap.GetLowerBound(1));
            //int path_len = 2;
            if (!s.pathFound)
            {
                MessageBox.Show("No path found");
                return;
            }
            listBox2.Items.Add("Processing ...");
            builder.Append("\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    builder.Append("     ");
                }
                else
                {
                    builder.Append("|    |");
                }
            }
            listBox2.Items.Add(builder.ToString());
            builder.Clear();
            builder.Append("\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    builder.Append("     ");
                }
                else
                {
                    builder.Append("|GOAL|");
                }
            }
            listBox2.Items.Add(builder.ToString());
            builder.Clear();
            builder.Append("\t");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    builder.Append("     ");
                }
                else
                {
                    builder.Append("| ^^ |");
                }
            }
            listBox2.Items.Add(builder.ToString());
            builder.Clear();
            builder.Append("\t+");
            for (int i = 0; i < ymap; i++)
            {
                if (i != 9)
                {
                    builder.Append("----+");
                }
                else
                {
                    builder.Append("    +");
                }
            }
            listBox2.Items.Add(builder.ToString());
            builder.Clear();
            for (int i = 0; i < xmap; i++)
            {
                if (i != 6)
                {
                    builder.Append("\t" + "|");
                }
                else
                {
                    builder.Append("  GO  >  ");
                }
                for (int j = 0; j < ymap; j++)
                {
                    if (MAP.Map[i, j].getType() == "R") // open route
                    {
                        if (MAP.Map[i, j].isPath())
                        {
                            //boolean tracker of what nodes are in the path
                            builder.Append("  * " + "|");
                            //path_len++;
                        }
                        else
                        {
                            builder.Append("    " + "|");
                        }
                    }
                    else if (MAP.Map[i, j].getType() == "S") //initial
                    {
                        builder.Append(" *  " + "|");
                    }
                    else if (MAP.Map[i, j].getType() == "G") //goal
                    {
                        builder.Append("  * " + "|");
                    }
                    else if (MAP.Map[i, j].getType() == "W") // wall
                    {
                        builder.Append("Wall" + "|");
                    }
                }
                listBox2.Items.Add(builder.ToString());
                builder.Clear();
                if (i == 5 || i == 6)
                {
                    builder.Append("--------+");
                }
                else
                {
                    builder.Append("\t" + "+");
                }
                for (int k = 0; k < ymap; k++)
                {
                    builder.Append("----+");
                }
                listBox2.Items.Add(builder.ToString());
                builder.Clear();
            }
        }

        private void ClearTextBoxes()
        {
            pathlentb.Text = "";
            goaltesttb.Text = "";
            expansiontb.Text = "";
            manhattanchb.Checked = false;
            euclideanchb.Checked = false;
            bmcosttb.Text = "";
            dmcosttb.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void Astarbt_Click(object sender, EventArgs e)
        {
            MAP = new MapParser();
            if (bmcosttb.Text != "" && dmcosttb.Text != "")
            {
                MAP.BASIC_MOVEMENT_COST = double.Parse(bmcosttb.Text);
                MAP.DIAGONAL_MOVEMENT_COST = double.Parse(dmcosttb.Text);
            }
            MAP.Parse();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map, 1);
            if (manhattanchb.Checked)
            {
                s.Heuristic = false;
            }
            else if (euclideanchb.Checked)
            {
                s.Heuristic = true;
            }

            s.AStar();
            this.Display(s, MAP);
            pathlentb.Text = s.Path_Route_List.Count.ToString();
            goaltesttb.Text = s.Searched_Nodes_for_AStar.ToString();
            expansiontb.Text = s.Expanded_Nodes_for_AStar.ToString();
            bmcosttb.Text = MAP.BASIC_MOVEMENT_COST.ToString();
            dmcosttb.Text = MAP.DIAGONAL_MOVEMENT_COST.ToString();
            if (!manhattanchb.Checked && !euclideanchb.Checked)
            {
                if (s.Heuristic) { euclideanchb.Checked = true; }
                else { manhattanchb.Checked = true; }
            }
            comparison.Add(s.Expanded_Nodes_for_AStar);
        }

        private void Greedybt_Click(object sender, EventArgs e)
        {
            MAP = new MapParser();
            MAP.Parse();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map, 2);
            s.Heuristic = false;
            if (manhattanchb.Checked)
            {
                s.Heuristic = false;
            }
            else if (euclideanchb.Checked)
            {
                s.Heuristic = true;
            }
            s.AStar();
            this.Display(s, MAP);
            pathlentb.Text = s.Path_Route_List.Count.ToString();
            goaltesttb.Text = s.Searched_Nodes_for_AStar.ToString();
            expansiontb.Text = s.Expanded_Nodes_for_AStar.ToString();
            if (!manhattanchb.Checked && !euclideanchb.Checked)
            {
                if (s.Heuristic) { euclideanchb.Checked = true; }
                else { manhattanchb.Checked = true; }
            }
            comparison.Add(s.Expanded_Nodes_for_AStar);
        }

        private void Ucsbt_Click(object sender, EventArgs e)
        {
            MAP = new MapParser();
            if (bmcosttb.Text != "" && dmcosttb.Text != "")
            {
                MAP.BASIC_MOVEMENT_COST = double.Parse(bmcosttb.Text);
                MAP.DIAGONAL_MOVEMENT_COST = double.Parse(dmcosttb.Text);
            }
            MAP.Parse();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map, 3);
            s.AStar();
            this.Display(s, MAP);
            pathlentb.Text = s.Path_Route_List.Count.ToString();
            goaltesttb.Text = s.Searched_Nodes_for_AStar.ToString();
            expansiontb.Text = s.Expanded_Nodes_for_AStar.ToString();
            bmcosttb.Text = MAP.BASIC_MOVEMENT_COST.ToString();
            dmcosttb.Text = MAP.DIAGONAL_MOVEMENT_COST.ToString();
            comparison.Add(s.Expanded_Nodes_for_AStar);
        }

        private void Bfsbt_Click(object sender, EventArgs e)
        {
            MAP = new MapParser();
            MAP.Parse();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map);
            s.BFS();
            this.Display(s, MAP);
            pathlentb.Text = s.Path_Route_List.Count.ToString();
            goaltesttb.Text = s.Searched_Nodes_for_BFS.ToString();
            expansiontb.Text = s.Expanded_Nodes_for_BFS.ToString();
            comparison.Add(s.Expanded_Nodes_for_BFS);
        }

        private void Dfsbt_Click(object sender, EventArgs e)
        {
            MAP = new MapParser();
            MAP.Parse();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map);
            s.DFS();
            this.Display(s, MAP);
            pathlentb.Text = s.Path_Route_List.Count.ToString();
            goaltesttb.Text = s.Searched_Nodes_for_DFS.ToString();
            expansiontb.Text = s.Expanded_Nodes_for_DFS.ToString();
            comparison.Add(s.Expanded_Nodes_for_DFS);
        }

        private void Cltb_Click(object sender, EventArgs e)
        {
            this.ClearTextBoxes();
            MAP = new MapParser();
            s = new Strategy(MAP.initial, MAP.goal, MAP.Map);
        }

        private void Closebt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

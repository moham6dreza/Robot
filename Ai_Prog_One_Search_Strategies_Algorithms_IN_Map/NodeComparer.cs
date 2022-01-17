using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public class NodeComparer : IComparer
    {
        private int select_search = 1;

        public NodeComparer(int sel)
        {
            this.select_search = sel;
        }

        public int Compare(object n1, object n2)
        {
            if (select_search == 1)
            {
                return Convert.ToInt32(((Node)n1).getF() - ((Node)n2).getF());
            }
            else if (select_search == 2)
            {
                return Convert.ToInt32(((Node)n1).getH() - ((Node)n2).getH());
            }
            else
            {
                return Convert.ToInt32(((Node)n1).getG() - ((Node)n2).getG());
            }
        }
    }
}

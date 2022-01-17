using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Prog_One_Search_Strategies_Algorithms_IN_Map
{
    public class SortedCostNodeList
    {
        ArrayList _list;
        NodeComparer _nodeComparer;

        public void clear()
        {
            this._list.Clear();
        }
        public bool contains(Node node)
        {
            return _list.Contains(node);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        /// <summary>
        /// ?? ???? ????? ?? ?? ???? ???? ??? ??? ???? ??? ??
        /// </summary>
        public SortedCostNodeList(int sel)
        {
            _list = new ArrayList();
            _nodeComparer = new NodeComparer(sel);
        }
        public Node NodeAt(int i)
        {
            return (Node)_list[i];
        }
        public void RemoveAt(int i)
        {
            _list.RemoveAt(i);
        }
        public int IndexOf(Node n)
        {
            //_list.IndexOf(n);
            for (int i = 0; i < _list.Count; i++)
            {
                Node nodeInTheList = (Node)_list[i];
                if (nodeInTheList.isMatch(n))
                    return i;
            }
            return -1;
        }
        public int push(Node n)
        {
            int k = _list.BinarySearch(n, _nodeComparer);
            if (k == -1) // no element
                _list.Insert(0, n);
            else if (k < 0) // find location by complement
            {
                k = ~k;
                _list.Insert(k, n);
            }
            else if (k >= 0)
                _list.Insert(k, n);
            return k;
        }
        public Node pop()
        {
            Node r = (Node)_list[0];
            _list.RemoveAt(0);
            return r;
        }
    }
}

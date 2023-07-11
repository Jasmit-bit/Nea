using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Djikstras_Work
{
    public class Node
    {
        public string name;
        public int DistanceFromStart;
        public List<Arc> ArcsConnectedTo = new List<Arc>();
        public Node PreviousNode;
        public Arc PreviousArc;
        public bool visited ;

        public Node(string inName)
        {
            name = inName;
           visited = false;
        }
        public void AddArcToList(Arc inArc)
        {
            ArcsConnectedTo.Add(inArc);
        }
        public void SortArcsByWeight()
        {
            List<int> weightOfArcs = new List<int>();
            foreach (Arc arc in ArcsConnectedTo)
            {
                weightOfArcs.Add(arc.Weight);
            }
            weightOfArcs.Sort();
            List<Arc> sortedArcs = new List<Arc>();
            foreach (int arcWeight in weightOfArcs)
            {
                foreach (Arc arc in ArcsConnectedTo)
                {
                    if (arcWeight == arc.Weight)
                    {
                        sortedArcs.Add(arc);
                    }
                }
            }
            ArcsConnectedTo = new List<Arc>(sortedArcs);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Djikstras_Work
{
    public static class Graph
    {
        public static List<Node> NodesInGraph = new List<Node>();

        public static void AddNode(Node node)
        {
            NodesInGraph.Add(node);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Make_Djikstras_Work
{
    public class Arc
    {
        public string name;
        public int Weight;

        public List<Node> nodesConnected;

        public Arc(string inName,int inWeight, Node Node1, Node Node2)
        {
            name= inName;
            Weight = inWeight;
            nodesConnected  = new List<Node> { Node1,Node2 };
            AddArcToNodeList();
        }
        private void AddArcToNodeList()
        {
            foreach(Node node in nodesConnected)
            {
                node.AddArcToList(this);
            }
        }

        public Node GetNodeOnOtherSide(Node CurNode)
        {
            Node otherNode = null;
            foreach (Node node in nodesConnected)
            {
                if(node!=CurNode)
                {
                    otherNode = node;
                }
            }
            return otherNode;
        }
        
    }
}

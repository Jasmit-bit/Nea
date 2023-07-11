using System.Collections.Generic;
using System;
using System.Dynamic;

namespace Make_Djikstras_Work
{
    internal class Program
    {
         static void FindShortestPath(Node StartingNode, Node FinishNode)

        {
            if (StartingNode == FinishNode)
            {
                Console.WriteLine("You are already at your finishing Node!");
                return;
            }
            foreach (Node node in Graph.NodesInGraph)
            {
                node.DistanceFromStart = int.MaxValue;
                node.PreviousNode = null;
                node.PreviousArc = null;
            }
            StartingNode.DistanceFromStart = 0;
            bool FoundBestPath = false;
            while (FoundBestPath == false)
            {
                Node currentNode = null;
                foreach (var node in Graph.NodesInGraph)
                {
                    if (node.visited == false && (currentNode == null || node.DistanceFromStart < currentNode.DistanceFromStart))
                    {
                        currentNode = node;
                    }
                }
                if (currentNode == null)
                {
                    FoundBestPath = true;
                    foreach (var node in Graph.NodesInGraph)
                    {
                        node.visited = false;
                    }
                    break;
                }
                currentNode.visited = true;

                foreach (Arc arc in currentNode.ArcsConnectedTo)
                {
                    var connectedNode = arc.GetNodeOnOtherSide(currentNode);
                    int potentialDistance = currentNode.DistanceFromStart + arc.Weight;
                    if (potentialDistance < connectedNode.DistanceFromStart)
                    {
                        connectedNode.DistanceFromStart = potentialDistance;
                        connectedNode.PreviousNode = currentNode;
                        connectedNode.PreviousArc = arc;
                    }
                }

            }
            List<Node> shortestPath = new List<Node>();
            List<Arc> arcsTaken = new List<Arc>();
            Node pathNode = FinishNode;
            int totalWeight = 0;
            while (pathNode != null)
            {
                shortestPath.Add(pathNode);
                if (pathNode.PreviousArc != null)
                {
                    arcsTaken.Add(pathNode.PreviousArc);
                    totalWeight += pathNode.PreviousArc.Weight;
                }
                pathNode = pathNode.PreviousNode;
            }
            shortestPath.Reverse();
            arcsTaken.Reverse();

            Console.WriteLine($"Shortest path from : {StartingNode.name} to {FinishNode.name}");
            for (int i = 0; i < shortestPath.Count - 1; i++)
            {
                Console.WriteLine($"From {shortestPath[i].name} to {shortestPath[i + 1].name}, take the {arcsTaken[i].name} (Distance: {arcsTaken[i].Weight} miles)");
            }

            Console.WriteLine($"Total Distance Covered: {totalWeight} miles");
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Would you like to create a random graph (y/n)");
            //string useroption = Console.ReadLine().ToLower();
            //if (useroption == "y")
            //{
            //    Random rnd = new Random();
            //    List<string> NamesOfCities = new List<string> { "Aberdeen", "Andover", "Leicester", "Southampton", "Eastleigh", "Portsmouth", "Romsey", "Nottingham", "West Bromwich" };
            //    for (int i = 0; i < 5; i++)
            //    {
            //        int index = rnd.Next(0, NamesOfCities.Count);
            //        Node node = new Node($"{NamesOfCities[index]}");
            //        Graph.AddNode(node);
            //        NamesOfCities.RemoveAt(index);
            //    }
            //    List<string> NamesOfRoads = new List<string> { "A41", "A52", "A73", "M3", "M9", "Junction 9", "Chesterfield Road", "Slip Road on A57", "M27", "A93" };
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Arc arc = new Arc($"{NamesOfRoads[rnd.Next(0, NamesOfRoads.Count)]}", rnd.Next(1, 1000), Graph.NodesInGraph[rnd.Next(0, Graph.NodesInGraph.Count)], Graph.NodesInGraph[rnd.Next(0, Graph.NodesInGraph.Count)]);
            //    }
            //    FindShortestPath(Graph.NodesInGraph[0], Graph.NodesInGraph[1]);
            //    Console.ReadKey();
            //}

            Node Southampton = new Node("Southampton");
            Node Portsmouth = new Node("Portsmouth");
            Node Eastleigh = new Node("Eastleigh");
            Node Romsey = new Node("Romsey");
            Node Winchester = new Node("Winchester");
            Arc M27 = new Arc("M27", 20, Eastleigh, Portsmouth);
            Arc A31 = new Arc("A31", 15, Romsey, Winchester);
            Arc A56 = new Arc("A56", 12, Romsey, Portsmouth);
            Arc M3 = new Arc("M3", 5, Eastleigh, Romsey);
            Arc RegRoad = new Arc("Reg Road", 5, Southampton, Eastleigh);
            Graph.AddNode(Southampton);
            Graph.AddNode(Portsmouth);
            Graph.AddNode(Eastleigh);
            Graph.AddNode(Romsey);
            Graph.AddNode(Winchester);
            foreach(Node node in Graph.NodesInGraph)
            {
                if(node!= Southampton)
                {
                    FindShortestPath(Portsmouth, node);
                }
                Console.ReadKey();
                Console.Clear();
            }


            Console.ReadKey();  
        }
    }
}

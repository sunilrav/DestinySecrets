using System.Collections.Generic;
using DestinySecrets.Corridors.Models;
using DestinySecrets.Helpers;

namespace DestinySecrets.Corridors
{
    public static class Mapper
    {
        public static void BuildTree(List<TreeNode<Hexagon>> treeNodes)
        {
            var startNode = treeNodes[0];
            foreach (var treeNode1 in treeNodes)
            { 
                foreach (var treeNode2 in treeNodes)
                {
                    if (treeNode1 == treeNode2)
                        continue;

                    var connected = IsConnected(treeNode1.Value, treeNode2.Value);
                    if (connected && !AlreadyConnected(treeNode1.Value, treeNode2.Value))
                    {
                        treeNode1.AddChild(treeNode2.Value);
                    }
                }
            }
        }

        private static bool AlreadyConnected(Hexagon hexagon1, Hexagon hexagon2)
        {
            if (hexagon2.ConnectedTo == null)
                return false;

            foreach (var hex1Connected in hexagon1.ConnectedTo)
            {
                if (hexagon2 == hex1Connected)
                    return true;
            }

            foreach (var hex2Connected in hexagon2.ConnectedTo)
            {
                if (hexagon1 == hex2Connected)
                    return true;
            }

            return false;
        }

        private static bool IsConnected(Hexagon headHexagon, Hexagon regularHexagon)
        {
            foreach (var headHexagonNode in headHexagon.Nodes)
            {
                foreach (var regularHexagonNode in regularHexagon.Nodes)
                {
                    if (headHexagonNode.Value != "BBBBBBB" && regularHexagonNode.Value != "BBBBBBB")
                    {
                        if ((headHexagonNode.Value == regularHexagonNode.Value)
                            && headHexagonNode.HasOpenWall
                            && regularHexagonNode.HasOpenWall)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}

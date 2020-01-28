using System.Collections.Generic;
using System.Linq;
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
                    if (connected && !AlreadyConnected(treeNode1, treeNode2))
                    {
                        treeNode1.AddChild(treeNode2.Value);
                    }
                }
            }
        }

        private static bool AlreadyConnected(TreeNode<Hexagon> treeNode1, TreeNode<Hexagon> treeNode2)
        {
            if (treeNode1.Children.FirstOrDefault(x => x.Value == treeNode2.Value) != null)
                return true;

            if (treeNode2.Children.FirstOrDefault(x => x.Value == treeNode1.Value) != null)
                return true;

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

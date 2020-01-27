using System;
using System.Collections.Generic;
using System.Linq;
using DestinySecrets.Corridors;
using DestinySecrets.Corridors.Models;
using Microsoft.AspNetCore.Mvc;

namespace DestinySecrets.Controllers
{
    public class CorridorsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var patterns = PatternJsons.Get();
            var treeNodes = Formatter.FormatTreeNodes(patterns);

            Mapper.BuildTree(treeNodes);

            return View(treeNodes);
        }

        public IActionResult Path()
        {
            var patterns = PatternJsons.Get();
            var treeNodes = Formatter.FormatTreeNodes(patterns);

            Mapper.BuildTree(treeNodes);

            var path = new List<Hexagon>();
            var edgeNode = treeNodes.First(x => x.Value.IsEdge);
            edgeNode.Traverse(x => path.Add(x));
            
            return View(path);
        }
    }
}

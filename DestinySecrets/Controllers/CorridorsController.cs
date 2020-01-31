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

            var output = string.Empty;
            var edgeNode = treeNodes.First(x => x.Value.IsEdge);
            edgeNode.Traverse(x => output += Draw(x.Value));

            return View("Index", output);
        }

        private string Draw(string value)
        {
            return $"<div>{value}</div>";
        }

        public IActionResult Path()
        {
            var patterns = PatternJsons.Get();
            var treeNodes = Formatter.FormatTreeNodes(patterns);

            Mapper.BuildTree(treeNodes);

            return View(treeNodes);
        }
    }
}

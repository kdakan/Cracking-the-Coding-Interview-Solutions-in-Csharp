using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_7_BuildOrder
    {
        public static List<Project> GetBuildOrderFor(Project project)
        {
            //using depth first traversal,
            //start with the start node,
            //visit children, then add parent node (node itself) to build order list for reverse ordering of dependencies
            var buildOrder = new List<Project>();
            var visitedSet = new HashSet<Project>();
            visit(project, visitedSet, buildOrder);
            return buildOrder;
        }

        private static void visit(Project project, HashSet<Project> visitedSet, List<Project> buildOrder)
        {
            if (visitedSet.Contains(project))
                return;

            visitedSet.Add(project);
            foreach (var dependency in project.Dependencies)
                visit(dependency, visitedSet, buildOrder);

            buildOrder.Add(project);
        }
    }

    public class Project
    {
        public string Name { get; set; }
        public List<Project> Dependencies { get; set; }

        public Project(string name)
        {
            Name = name;
            Dependencies = new List<Project>();
        }
    }
}

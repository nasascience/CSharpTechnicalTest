using System.Linq;
using System.Collections.Generic;

namespace GunvorRecruitment.Repository
{
    public class NodeManager
    {
        private readonly IRepository _nodeRepository;
        public static List<Node> LoadedNodes { get; set; } = new List<Node>();
        public NodeManager(IRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public Node GetNodeAndImmediateChildren(string name)
        {
           var nodeResponse = _nodeRepository.GetNodeAndImmediateChildren(name);

            if (!LoadedNodes.Any(x => x.Name == name))
                LoadedNodes.Add(nodeResponse);

            var nodeInstance = LoadedNodes.Where(x => x.Name == name).First();

            foreach (var nodeChild in LoadedNodes)
            {
                nodeChild.ImmediateChildren = nodeChild.ImmediateChildren.Select(x => {
                       try
                       {
                           return LoadedNodes.Any(y => y.Name == x.Name)? LoadedNodes.First(y => y.Name == x.Name):x;
                       }
                       catch
                       {
                           return x;
                       }

                       }).ToList();
            }
            return nodeInstance;
        }
    }
}

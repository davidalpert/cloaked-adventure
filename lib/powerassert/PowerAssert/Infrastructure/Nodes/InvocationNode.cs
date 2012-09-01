using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using System.Linq.Expressions;

namespace PowerAssert.Infrastructure.Nodes
{
    internal class InvocationNode : Node
    {
        [NotNull]
        public List<Node> ArgumentNodes { get; set; }

        [CanBeNull]
        public Node InvokedNode { get; set; }

        [CanBeNull]
        public string Type { get; set; }

        internal override void Walk(NodeWalker walker, int depth)
        {
            InvokedNode.Walk(walker, depth);
            walker("(");
            foreach (var node in ArgumentNodes.Take(1))
            {
                node.Walk(walker, depth);
            }
            foreach (var node in ArgumentNodes.Skip(1))
            {
                walker(", ");
                node.Walk(walker, depth);
            }
            walker(")");
        }
    }
}

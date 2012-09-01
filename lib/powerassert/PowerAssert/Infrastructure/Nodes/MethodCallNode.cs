using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace PowerAssert.Infrastructure.Nodes
{
    internal class MethodCallNode : MemberAccessNode
    {
        internal MethodCallNode()
        {
            Parameters = new List<Node>();
        }

        [NotNull]
        public List<Node> Parameters { get; set; }

        internal override void Walk(NodeWalker walker, int depth)
        {
            bool isCompiledExpression = base.MemberName.Equals("compile", System.StringComparison.InvariantCultureIgnoreCase);

            if (isCompiledExpression)
            {
                base.Container.Walk(walker, depth);
                walker("."+base.MemberName);
            }
            else
            {
                base.Walk(walker, depth);
            }
            walker("(");
            foreach (var parameter in Parameters.Take(1))
            {
                parameter.Walk(walker, depth);
            }
            foreach (var parameter in Parameters.Skip(1))
            {
                walker(", ");
                parameter.Walk(walker, depth);
            }
            walker(")");
        }
    }
}
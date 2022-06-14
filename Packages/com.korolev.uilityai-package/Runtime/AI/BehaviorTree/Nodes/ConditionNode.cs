using System.Collections.Generic;
using UnityEngine;

namespace AI.BehaviorTree.Nodes
{
    public abstract class ConditionNode : Node
    {
        [HideInInspector] public Node ChildNode;

        public abstract bool Condition();
        public override IEnumerable<Node> GetChildren()
        {
            yield return ChildNode;
        }
        public override Node Clone()
        {
            ConditionNode clone = Instantiate(this);
            clone.GUID = GUID;
            clone.Parent = null;
            clone.ChildNode = null;
            return clone;
        }
    }
}
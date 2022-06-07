/*******************************************
 * Created by Pavel Korolev
 * Last Modified 19.04.2022
 *******************************************/

using UnityEditor;
using UnityEngine;

namespace AI.BehaviorTree.Nodes.DecoratorNodes
{
    public class RepeatNode : DecoratorNode
    {
        [HideInInspector] public ConditionNode ConditionNode;
  
        public override State OnUpdate()
        {
            if (ConditionNode == null)
            {
                BehaviorTreeRef.SetCurrentNode(Child);
                return State.Running; 
            }
            
            //если заданное условие выполняется
            if (ConditionNode.Condition() == true)
            {
                BehaviorTreeRef.SetCurrentNode(Child);
                return State.Running; 
            }
            return State.Success;
        }
    }
}
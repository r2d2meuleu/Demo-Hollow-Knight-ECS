using System;
using System.Linq;
using AI.BehaviorTree.Nodes;
using AI.BehaviorTree.Nodes.ParameterNodes;
using UnityEngine;

namespace Examples.Example_1.FalseKnight.AI.Parameters
{
    public class DistanceToPlayer : FloatNode
    {
        [NonSerialized] private GameObject PlayerRef;
        private Transform _transform;

        protected override void OnStart()
        {
            _transform = BehaviorTreeRef.GameObjectRef.transform;
            PlayerRef = FindObjectsOfType<GameObject>().Where(i => i.layer == Constants.PlayerLayer).FirstOrDefault();
        }
        protected override State OnUpdate() 
        {               
            if (PlayerRef != null && _transform != null)
            {
                var distance = (_transform.position - PlayerRef.transform.position).magnitude;
                Value = distance;
            }
            return State.Success; 
        }
    }
}
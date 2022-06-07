using System;
using AI.BehaviorTree.Nodes;

namespace Examples.Example_1.FalseKnight.AI.Conditions
{
    public class ConditionLoop : ConditionNode
    {
        public float Count; 
        [NonSerialized] private float _currentCount = 0;

        public override void OnStart() { }
        public override void OnStop() { }
        public override State OnUpdate() 
        {
            return State.Success;
        }

        public override bool Condition()
        {
            if (_currentCount >= Count)
            {
                _currentCount = 0;
                return false;
            }

            _currentCount++;
            return true;
        }
    }
}
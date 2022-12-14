/*******************************************
 * Created by Pavel Korolev
 * Last Modified 19.04.2022
 *******************************************/

using UnityEngine;

namespace AI.BehaviorTree.Nodes.ActionNodes
{
    public class WaitNode : ActionNode
    {
        private float _currentTime = 0f;
        public float TimeWait;

        protected override State OnUpdate()
        {
            if (_currentTime >= TimeWait)
            {
                _currentTime = 0f;
                return State.Success;
            }
            _currentTime += Time.deltaTime;
            return State.Running;
        }        
        public override Node Clone()
        {
            WaitNode clone = base.Clone() as WaitNode;
            clone.TimeWait = TimeWait;
            return clone;
        }
    }
}
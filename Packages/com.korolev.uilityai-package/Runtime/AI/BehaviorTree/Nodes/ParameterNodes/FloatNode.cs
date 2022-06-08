/*******************************************
 * Created by Pavel Korolev
 * Last Modified 19.04.2022
 *******************************************/

namespace AI.BehaviorTree.Nodes.ParameterNodes
{
    public class FloatNode : ParameterNode
    { 
        public float Value = 0f;

        protected override void OnStart() { }
        protected override void OnStop() { }
        protected override State OnUpdate() 
        {
            return State.Success;
        }
    }
}
using AI.BehaviorTree.Nodes;
using UnityEngine;

namespace Examples.Example_1.FalseKnight.AI.Actions
{
    public class WatchRight: ActionNode
    {
        private SpriteRenderer _spriteRenderer;
        public override void OnStart()
        {
            _spriteRenderer = BehaviorTreeRef.GameObjectRef.GetComponent<SpriteRenderer>();
        }
        public override void OnStop() { }
        public override State OnUpdate()
        {
            _spriteRenderer.flipX = false;
            return State.Success;
        }
    }
}
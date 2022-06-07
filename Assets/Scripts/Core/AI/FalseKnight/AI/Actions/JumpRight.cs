using AI.BehaviorTree.Nodes;
using UnityEngine;

namespace Examples.Example_1.FalseKnight.AI.Actions
{
    public class JumpRight : ActionNode
    {
        private FalseKnight _falseKnight;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public override void OnStart()
        {
            _falseKnight = BehaviorTreeRef.GameObjectRef.GetComponent<FalseKnight>();
            _spriteRenderer = _falseKnight.GetComponent<SpriteRenderer>();
            _rigidbody = _falseKnight.GetComponent<Rigidbody2D>();
            _animator = _falseKnight.GetComponent<Animator>();
        }
        public override void OnStop() { }
        public override State OnUpdate()
        {
            if (!BehaviorTreeRef.GameObjectRef || !_falseKnight) return State.Failure;

            bool lookRight = !_spriteRenderer.flipX;

            if (_falseKnight.Grounded)
            {
                if (!lookRight) _spriteRenderer.flipX = false;

                _rigidbody.velocity = new Vector2(-3, 10);
                _animator.SetTrigger("Jump");

                return State.Success;
            }
            return State.Failure;
        }
    }
}
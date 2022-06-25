using Leopotam.Ecs;

namespace Core.ECS.Components.Player
{
    internal struct CanAttackComponent : IEcsIgnoreInFilter { }
    internal struct ClimbingComponent : IEcsIgnoreInFilter { }
    internal struct SwimmingComponent : IEcsIgnoreInFilter { }
    internal struct AttackCooldownComponent { public float Value; }
    internal struct EnergyComponent { public float Energy; public float MaxEnergy; }
}
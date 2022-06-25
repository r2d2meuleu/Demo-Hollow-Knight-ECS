﻿using Leopotam.Ecs;

namespace Core.ECS.Events.Player
{
    internal struct PlayerRecievedDamageEvent { public int Value;  }
    internal struct PlayerHealedEvent { public int Value; }
    internal struct EnergyReducedEvent { public float Value; }
    internal struct PlayerDiedEvent : IEcsIgnoreInFilter { }
}

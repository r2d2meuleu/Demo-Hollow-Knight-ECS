using UnityEngine;
using Core.Models;
using Leopotam.Ecs;
using Examples.Example_1.ECS.ComponentProviders;
using Examples.Example_1.ECS.Events;

namespace Examples.Example_1.ECS.Systems
{
    internal sealed class UnitSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<UnitCreateEventComponent> _filter = null;
        private readonly IUnitFactory _unitFactory;

        internal UnitSpawnSystem(IUnitFactory factory)
        {
            _unitFactory = factory;
        }

        private GameObject SpawnUnit(uint id, Vector2 point)
        {
            EcsEntity entity = _world.NewEntity();

            GameObject go = _unitFactory.GetRandomUnit();
            go.transform.position = point;
            var reference = go.GetComponent<EntityReference>();
            var animator = go.GetComponent<Animator>();
            var collider = go.GetComponent<Collider2D>();
            var rigidbody = go.GetComponent<Rigidbody2D>();
            reference.Entity = entity;

            entity.Get<UnitComponent>().Value = reference;
            entity.Get<HealthComponent>();
            entity.Get<AnimatorComponent>().Value = animator;
            entity.Get<ColliderComponent>().Value = collider;
            entity.Get<RigidbodyComponent>().Value = rigidbody;
            entity.Get<HittableComponent>();
            entity.Get<MovableComponent>();

            return go;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var component = ref entity.Get<UnitCreateEventComponent>();

                // Get data
                uint id = component.ID;
                Vector3 point = component.Point;

                // Spawn unit
                GameObject unit = SpawnUnit(id, point);

                // Delete component
                entity.Del<UnitCreateEventComponent>();
            }
        }
    }
}
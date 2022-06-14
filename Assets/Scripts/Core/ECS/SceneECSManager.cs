/*******************************************
 * Created by Pavel Korolev
 * Last Modified 19.04.2022
 *******************************************/

using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;
using Core.Input;
using Core.Models;
using Core.Units;
using AI.ECS.Systems;
using Examples.Example_1.ECS.Events;
using Examples.Example_1.ECS.Systems;
using Examples.Example_1.ECS.Systems.FalseKnight;
using Examples.Example_1.ECS.Systems.Player;

namespace Examples.Example_1.ECS
{
    public class SceneECSManager : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
          
        [Inject]
        private readonly UnitScript _player = null;
        [Inject]
        private readonly IInputSystem _inputSystem = null;
        [Inject]
        private readonly UnitsDefinitions _unitsDefinitions = null;

        [SerializeField] 
        private GameObject _prefabDustAnimation;

        private void Start ()
        {            
            _world = new EcsWorld();
            _systems = new EcsSystems(_world).ConvertScene(); // Этот метод сконвертирует GO в Entity;

            AddInitSystems();
            AddGeneralSystems();
            AddPlayerSystems();
            AddCameraSystems();
            AddOtherSystems();

            AddOneFrames();
            AddInjections();

            _systems?.Init();
        }

        private void FixedUpdate() 
        {
            _systems?.Run();
        }
        private void OnDestroy() 
        {
            _systems.Destroy();
            _world.Destroy();
        }

        private void AddInjections()
        {
            _systems.Inject(_player);
        }
        private void AddOneFrames()
        {
            _systems
                .OneFrame<UnitInitComponent>()
                .OneFrame<DamageEventComponent>()
                .OneFrame<UnitCreateEventComponent>()
                .OneFrame<DiedComponent>();
        }
        private void AddInitSystems()
        {
            _systems
                .Add(new FalseKnightInitSystem(_unitsDefinitions.FalseKnight))
                .Add(new PlayerInitSystem(_unitsDefinitions.PlayerModel))
                .Add(new UnitInitSystem());
        }
        private void AddGeneralSystems()
        {
            _systems
                .Add(new DamageSystem())
                .Add(new HealthSystem())
                .Add(new GroundSystem())
                .Add(new BehaviorTreeSystem())
                .Add(new DestroyEntitiesSystem());
        }
        private void AddPlayerSystems()
        {
            _systems
                .Add(new PlayerMoveSystem(_inputSystem))
                .Add(new PlayerJumpSystem(_inputSystem))
                .Add(new PlayerAttackSystem(_inputSystem, _unitsDefinitions.PlayerModel))
                .Add(new PlayerAttackCooldownSystem(_inputSystem, _unitsDefinitions.PlayerModel))
                .Add(new PlayerAnimationSystem(_inputSystem));
        }
        private void AddCameraSystems()
        {
            _systems
                .Add(new CameraShakeSystem(Camera.main))
                .Add(new CameraFadeSystem(Camera.main));
                //.Add(new CameraFollowSystem(Camera.main));
        }
        private void AddOtherSystems()
        {
            _systems
                .Add(new FalseKnightJumpAnimationSystem())
                .Add(new FalseKnightAttackAnimationSystem())
                .Add(new DustCloudAnimationSystem(_prefabDustAnimation))
                .Add(new DamageAnimationSystem())
                .Add(new EnemyDeathEffectSystem());
        }
    }
}
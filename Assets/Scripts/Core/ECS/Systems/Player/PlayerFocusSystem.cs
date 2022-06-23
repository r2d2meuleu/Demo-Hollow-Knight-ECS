﻿using UnityEngine;
using Leopotam.Ecs;
using Core.ECS.Events.Player;
using Core.ECS.Components;
using Core.ECS.Components.Units;
using Core.Input;

namespace Core.ECS.Systems.Player
{
    internal class PlayerFocusSystem : IEcsInitSystem, IEcsDestroySystem, IEcsRunSystem
    {
        private readonly EcsFilter<AnimatorComponent, HealthComponent, PlayerTagComponent>
          .Exclude<DiedComponent> _filter = null;
        private readonly IInputSystem _playerInput;

        private bool _focusing;
        private float _timer;
        private const float FocusHold = 1.5f;
        private const string FOCUS_KEY = "IsFocusing";

        internal PlayerFocusSystem(IInputSystem playerInput)
        {
            _playerInput = playerInput;
        }

        public void Init()
        {
            _playerInput.FocusStarted += OnFocusStarted;
            _playerInput.FocusCanceled += OnFocusCancelled;
        }
        public void Destroy()
        {
            _playerInput.FocusStarted -= OnFocusStarted;
            _playerInput.FocusCanceled -= OnFocusCancelled;
        }

        private void OnFocusStarted()
        {
            _focusing = true;
            foreach (var i in _filter)
            {
                var animator = _filter.Get1(i).Value;
                animator.SetBool(FOCUS_KEY, true);
            }
        }
        private void OnFocusCancelled()
        {
            foreach (var i in _filter)
            {
                Reset(ref _filter.GetEntity(i));
                var animator = _filter.Get1(i).Value;
                animator.SetBool(FOCUS_KEY, false);
            }
        }
        private void Reset(ref EcsEntity entity)
        {
            _focusing = false;
            _timer = 0f;
            if (entity.Has<ChannellingComponent>()) entity.Del<ChannellingComponent>();
        }
        public void Run()
        {
            if (!_focusing || _timer > FocusHold) return;

            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var health = ref _filter.Get2(i);

                // If full HP
                if (health.Health == health.MaxHealth) continue;

                if (!entity.Has<ChannellingComponent>()) entity.Get<ChannellingComponent>();

                _timer += Time.deltaTime;
                if (_timer >= FocusHold)
                {                    
                    Reset(ref entity);

                    // Heal
                    entity.Get<PlayerHealedEvent>().Value = 1;
                }
            }
        }
    }
}

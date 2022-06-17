using System;
using UnityEngine;

namespace Core.ECS.Events
{
    [Serializable]
    public struct AnimateDustEventComponent
    {
        //** ПААМЕТРЫ ДЛЯ ИЗМЕНЕНИЯ ИЗВНЕ** //
        public Vector3 Point;
        public Vector3 Scale;

        //** ПААМЕТРЫ ДЛЯ ИЗМЕНЕНИЯ ВНУТРИ СИСТЕМЫ DustCloudAnimationSystem** //
        public GameObject DustAnimation;
        public float TimeAlive;
    }
}
using _Project.Code.Runtime.Gameplay.AI.TargetSelector;
using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
using _Project.Code.Runtime.Utility.StateMachineCore;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.AI.States
{
    public class TeleportToTargetState : State, IUpdatableState
    {
        private readonly EntityLifeContext _entityLifeContext;
        private readonly ITargetSelector _targetSelector;
        private readonly float _cooldown;
        private readonly Transform _transform;
        private readonly ReactiveEvent<Vector3> _teleportEvent;
        private readonly ReactiveVariable<float> _teleportRadius;

        private float _time;

        public TeleportToTargetState(Entity entity, EntityLifeContext entityLifeContext, ITargetSelector targetSelector, float cooldown)
        {
            _entityLifeContext = entityLifeContext;
            _targetSelector = targetSelector;
            _cooldown = cooldown;

            _teleportEvent = entity.TeleportEvent;
            _teleportRadius = entity.TeleportRadius;
            _transform = entity.Transform;
        }

        public Entity Target => _targetSelector.Select(_entityLifeContext.Entities);

        public void Update(float deltaTime)
        {
            Debug.Log($"Я телепортируюсь");

            _time += deltaTime;;

            if (_time >= _cooldown)
            {
                _time = 0;

                Vector3 directionToTarget = (Target.Transform.position - _transform.position).normalized;

                float distanceToTarget = Vector3.Distance(Target.Transform.position, _transform.position);
                float clampedDistance = Mathf.Clamp(distanceToTarget, 0, _teleportRadius.Value);

                Vector3 teleportPosition = directionToTarget * clampedDistance + _transform.position;

                _teleportEvent?.Invoke(teleportPosition);
            }
        }
    }
}

using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.Components
{
    public class VelocityComponent : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveDirectionComponent : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeedComponent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}
using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport
{
    public class TeleportRequestComponent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class TeleportEvent : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }

    public class TeleportRadiusComponent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportSpendEnergyComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}
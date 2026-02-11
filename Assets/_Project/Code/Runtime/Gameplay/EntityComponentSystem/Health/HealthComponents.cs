using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components
{
    public class IsAliveComponent : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class HealthComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class MaxHealthComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}
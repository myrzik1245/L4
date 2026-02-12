using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Damage
{
    public class DamageComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class AttackRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}

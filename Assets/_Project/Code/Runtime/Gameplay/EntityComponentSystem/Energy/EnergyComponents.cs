using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;

namespace Assets._Project.Code.Runtime.Gameplay.Energy
{
    public class EnergyComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class MaxEnergyComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class EnergyRegenPercentComponent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class EnergyRegenCooldownComponent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}
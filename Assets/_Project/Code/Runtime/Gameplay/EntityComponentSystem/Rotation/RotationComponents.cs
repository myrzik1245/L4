using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components
{
    public class RotationSpeedComponent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}

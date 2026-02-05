using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Utility.InputService;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components
{
    public class InputComponent : IEntityComponent
    {
        public IInputService Value;
    }
}

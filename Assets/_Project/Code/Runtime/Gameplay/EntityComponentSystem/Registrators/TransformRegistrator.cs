using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Registrators
{
    public class TransformRegistrator : MonoRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new TransformComponent() { Value = transform });
        }
    }
}

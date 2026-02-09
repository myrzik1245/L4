using Assets._Project.Code.Runtime.Gameplay.Entities;

namespace Assets._Project.Code.Runtime.Gameplay.EntitySystems
{
    public interface IInitializableSystem
    {
        void Initialize(Entity entity);
    }
}
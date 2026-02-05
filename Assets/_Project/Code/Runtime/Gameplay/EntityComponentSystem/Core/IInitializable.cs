using Assets._Project.Code.Runtime.Gameplay.Entities;

namespace Assets._Project.Code.Runtime.Gameplay.EntitySystems
{
    public interface IInitializable
    {
        void Initialize(Entity entity);
    }
}
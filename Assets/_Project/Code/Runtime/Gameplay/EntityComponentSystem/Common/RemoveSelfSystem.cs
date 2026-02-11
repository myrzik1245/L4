using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Conditions;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems
{
    public class RemoveSelfSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private Entity _entity;
        private readonly ICondition _condition;
        private readonly EntityLifeContext _lifeContext;

        public RemoveSelfSystem(ICondition condition, EntityLifeContext lifeContext)
        {
            _condition = condition;
            _lifeContext = lifeContext;
        }

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void Update(float deltaTime)
        {
            if (_condition.IsCompleate())
                _lifeContext.Remove(_entity);
        }
    }
}
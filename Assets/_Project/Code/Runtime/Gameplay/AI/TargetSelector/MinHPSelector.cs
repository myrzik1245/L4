using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using System.Collections.Generic;

namespace _Project.Code.Runtime.Gameplay.AI.TargetSelector
{
    public class MinHpSelector : ITargetSelector
    {
        private readonly Entity _source;

        public MinHpSelector(Entity source)
        {
            _source = source;
        }

        public Entity Select(IEnumerable<Entity> entities)
        {
            int minHp = int.MaxValue;
            Entity minHpEntity = null;

            foreach (Entity entity in entities)
            {
                if (entity == _source)
                    continue;

                if (entity.HasComponent<HealthComponent>() == false)
                    continue;

                if (entity.HasComponent<DamageRequest>() == false )
                    continue;

                int currentHp = entity.Health.Value;

                if (currentHp < minHp)
                {
                    minHp = currentHp;
                    minHpEntity = entity;
                }
            }

            return minHpEntity;
        }
    }
}

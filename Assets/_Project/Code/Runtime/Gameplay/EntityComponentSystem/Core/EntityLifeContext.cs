using Assets._Project.Code.Runtime.Gameplay.Entities;
using System;
using System.Collections.Generic;

namespace Assets._Project.Code.Runtime.Gameplay.EntitiesCore
{
    public class EntityLifeContext
    {
        public event Action<Entity> Aded;
        public event Action<Entity> Removed;

        private readonly List<Entity> _entities = new List<Entity>();
        private readonly List<Entity> _toRemove = new List<Entity>();

        public void Add(Entity entity)
        {
            _entities.Add(entity);

            entity.Initialize();

            Aded?.Invoke(entity);
        }

        public void Remove(Entity entity)
        {
            _toRemove.Add(entity);
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
                _entities[i].Update(deltaTime);

            foreach (Entity removedEntity in _toRemove)
            {
                _entities.Remove(removedEntity);
                removedEntity.Dispose();
                Removed?.Invoke(removedEntity);
            }

            _toRemove.Clear();
        }

        public void Dispose()
        {
            foreach (Entity entity in _entities)
                entity.Dispose();

            _entities.Clear();
        }
    }
}

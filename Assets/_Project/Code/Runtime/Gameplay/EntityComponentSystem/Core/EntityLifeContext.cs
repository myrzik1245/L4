using _Project.Code.Runtime.Utility.Update;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using System;
using System.Collections.Generic;

namespace _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core
{
    public class EntityLifeContext : IUpdate
    {
        public event Action<Entity> Added;
        public event Action<Entity> Removed;

        private readonly List<Entity> _entities = new List<Entity>();
        private readonly List<Entity> _toRemove = new List<Entity>();

        public IReadOnlyList<Entity> Entities => _entities;

        public void Add(Entity entity)
        {
            _entities.Add(entity);

            entity.Initialize();

            Added?.Invoke(entity);
        }

        public void Remove(Entity entity)
        {
            _toRemove.Add(entity);
        }

        public void Update(float deltaTime)
        {
            foreach (Entity entity in _entities)
                entity.Update(deltaTime);

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

using Assets._Project.Code.Runtime.Gameplay.Entities;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using System.Linq;

namespace Assets._Project.Code.Runtime.Gameplay.Factories
{
    public class MonoEntitiesFactory : IDisposable
    {
        private readonly Dictionary<Entity, MonoEntity> _entitiesMap = new Dictionary<Entity, MonoEntity>();
        private readonly EntityLifeContext _lifeContext;

        public MonoEntitiesFactory(EntityLifeContext lifeContext)
        {
            _lifeContext = lifeContext;
            _lifeContext.Removed += OnRemove;
        }

        public MonoEntity Create(Entity entity, Vector3 position, MonoEntity prefab)
        {
            if (_entitiesMap.ContainsKey(entity))
                throw new InvalidOperationException();

            MonoEntity instance = GameObject.Instantiate(prefab, position, Quaternion.identity);
            instance.Setup(entity);

            _entitiesMap.Add(entity, instance);

            return instance;
        }

        public void Dispose()
        {
            _lifeContext.Removed -= OnRemove;

            foreach (Entity entity in _entitiesMap.Keys.ToList())
                OnRemove(entity);
        }

        private void OnRemove(Entity entity)
        {
            MonoEntity monoEntity = _entitiesMap[entity];
            monoEntity.Remove(entity);
            _entitiesMap.Remove(entity);
        }
    }
}

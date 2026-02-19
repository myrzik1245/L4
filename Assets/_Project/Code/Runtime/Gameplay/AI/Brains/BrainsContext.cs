using _Project.Code.Runtime.Utility.Update;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using System;
using System.Collections.Generic;

namespace _Project.Code.Runtime.Gameplay.AI.Brains
{
    public class BrainsContext : IUpdate, IDisposable
    {
        private readonly Dictionary<Entity, Brain> _entitiesMap =  new Dictionary<Entity, Brain>();
        private readonly List<Entity> _removeRequests = new List<Entity>();

        public void Add(Entity entity, Brain brain)
        {
            if (_entitiesMap.TryGetValue(entity, out Brain oldBrain))
            {
                RemoveBrain(oldBrain);
                _entitiesMap[entity] = brain;
                brain.Enable();

                return;
            }

            _entitiesMap.Add(entity, brain);
            brain.Enable();
        }

        public void Remove(Entity entity)
        {
            _removeRequests.Add(entity);
        }

        public void Update(float deltaTime)
        {
            foreach (Entity entity in _removeRequests)
            {
                Brain brain = _entitiesMap[entity];
                RemoveBrain(brain);
                _entitiesMap.Remove(entity);
            }

            _removeRequests.Clear();

            foreach (Entity entity in _entitiesMap.Keys)
            {
                if (entity.IsInit == false)
                    Remove(entity);

                _entitiesMap[entity].Update(deltaTime); 
            }
        }

        public void Dispose()
        {
            foreach (Entity entity in _entitiesMap.Keys)
                _entitiesMap[entity].Dispose();

            _entitiesMap.Clear();
        }

        private void RemoveBrain(Brain brain)
        {
            brain.Disable();
            brain.Dispose();
        }
    }
}

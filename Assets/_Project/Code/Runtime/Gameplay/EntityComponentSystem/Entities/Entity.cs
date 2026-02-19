using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using System;
using System.Collections.Generic;

namespace Assets._Project.Code.Runtime.Gameplay.Entities
{
    public partial class Entity : IDisposable
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new Dictionary<Type, IEntityComponent>();

        private readonly List<IEntitySystem> _systems = new List<IEntitySystem>();

        private readonly List<IInitializableSystem> _initializables = new List<IInitializableSystem>();
        private readonly List<IUpdatableSystem> _updatables = new List<IUpdatableSystem>();
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public bool IsInit { get; private set; } = false;

        public bool HasComponent<TComponent>() where TComponent : IEntityComponent
        {
            return _components.ContainsKey(typeof(TComponent));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : IEntityComponent
        {
            if (HasComponent<TComponent>())
            {
                component = GetComponent<TComponent>();
                return true;
            }

            component = default;
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : IEntityComponent
        {
            if (HasComponent<TComponent>())
                return (TComponent)_components[typeof(TComponent)];

            throw new InvalidOperationException($"{typeof(TComponent)} not found");
        }

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : IEntityComponent
        {
            if (HasComponent<TComponent>())
                throw new InvalidOperationException($"Attempt to add an already added component {typeof(TComponent)}");

            _components.Add(typeof(TComponent), component);

            return this;
        }

        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new InvalidOperationException(system.GetType().ToString());

            _systems.Add(system);

            if (system is IInitializableSystem initializable)
            {
                _initializables.Add(initializable);

                if (IsInit)
                    initializable.Initialize(this);
            }

            if (system is IUpdatableSystem updatable)
                _updatables.Add(updatable);

            if (system is IDisposable disposable)
                _disposables.Add(disposable);

            return this;
        }

        public void Initialize()
        {
            foreach (IInitializableSystem initializable in _initializables)
                initializable.Initialize(this);

            IsInit = true;
        }

        public void Update(float deltaTime)
        {
            if (IsInit == false)
                return;

            foreach (IUpdatableSystem updatable in _updatables)
                updatable.Update(deltaTime);
        }

        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }
    }
}
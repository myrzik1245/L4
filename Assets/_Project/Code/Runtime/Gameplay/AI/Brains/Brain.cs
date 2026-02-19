using System;

namespace _Project.Code.Runtime.Gameplay.AI.Brains
{
    public abstract class Brain : IDisposable
    {
        protected bool IsEnabled { get; private  set; } 

        public virtual void Enable()
        {
            IsEnabled = true;
        }

        public virtual void Disable()
        {
            IsEnabled = false;
        }

        public virtual void Dispose()
        {
        }

        public void Update(float deltaTime)
        {
            if (IsEnabled)
                UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}

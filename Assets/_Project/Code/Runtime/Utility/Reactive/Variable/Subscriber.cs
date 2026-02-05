using System;

namespace Assets._Project.Code.Utility.Reactive.Variable
{
    public class Subscriber<T> : IDisposable where T : IEquatable<T>
    {
        private readonly Action<T> _action;
        private readonly Action<Subscriber<T>> _onDispose;

        public Subscriber(Action<T> action, Action<Subscriber<T>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose?.Invoke(this);
        }

        public void Invoke(T value)
        {
            _action(value);
        }
    }
}
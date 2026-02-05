using System;
using System.Collections.Generic;

namespace Assets._Project.Code.Utility.Reactive.Variable
{
    public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T> where T : IEquatable<T>
    {
        private T _value;
        private List<Subscriber<T>> _subscribers = new List<Subscriber<T>>();
        private List<Subscriber<T>> _toAdd = new List<Subscriber<T>>();
        private List<Subscriber<T>> _toRemove = new List<Subscriber<T>>();

        public ReactiveVariable(T value = default)
        {
            _value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;

                Add();
                Remove();

                if (_value.Equals(oldValue) == false)
                    Invoke(_value);
            }
        }

        public IDisposable Subscribe(Action<T> action)
        {
            Subscriber<T> subscriber = new Subscriber<T>(action, subscriber => _toRemove.Add(subscriber));
            _toAdd.Add(subscriber);

            return subscriber;
        }

        private void Invoke(T value)
        {
            foreach (Subscriber<T> subscriber in _subscribers)
                subscriber.Invoke(value);
        }

        private void Add()
        {
            foreach (Subscriber<T> subscriber in _toAdd)
                _subscribers.Add(subscriber);

            _toAdd.Clear();
        }
        
        private void Remove()
        {
            foreach (Subscriber<T> subscriber in _toRemove)
                _subscribers.Remove(subscriber);

            _toRemove.Clear();
        }
    }
}
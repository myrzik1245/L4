using System;

namespace Assets._Project.Code.Runtime.Utility.Reactive.Variable
{
    public interface IReadOnlyReactiveVariable<T>
    {
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}
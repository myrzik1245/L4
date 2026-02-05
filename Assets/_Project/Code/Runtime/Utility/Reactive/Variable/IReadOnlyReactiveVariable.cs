using System;

namespace Assets._Project.Code.Utility.Reactive.Variable
{
    public interface IReadOnlyReactiveVariable<T> where T : IEquatable<T>
    {
        T Value { get; }
        IDisposable Subscribe(Action<T> action);
    }
}
namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}

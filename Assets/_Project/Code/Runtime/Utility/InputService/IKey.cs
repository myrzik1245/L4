namespace Assets._Project.Code.Utility.InputService
{
    public interface IKey
    {
        bool Down { get; }
        bool Up { get; }
        bool Pressing { get; }
    }
}

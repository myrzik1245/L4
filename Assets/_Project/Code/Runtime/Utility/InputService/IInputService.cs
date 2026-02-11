using UnityEngine;

namespace Assets._Project.Code.Utility.InputService
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        IKey TeleportButton { get; }
    }
}

using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportHandler
{
    public interface ITeleportHandler
    {
        void Execute(Vector3 position);
    }
}

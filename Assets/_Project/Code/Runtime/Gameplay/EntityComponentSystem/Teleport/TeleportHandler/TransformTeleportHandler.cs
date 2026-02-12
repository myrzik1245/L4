using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportHandler
{
    public class TransformTeleportHandler : ITeleportHandler
    {
        private readonly Transform _transform;

        public TransformTeleportHandler(Transform characterController)
        {
            _transform = characterController;
        }

        public void Execute(Vector3 offset)
        {
            _transform.position += offset;
        }
    }
}

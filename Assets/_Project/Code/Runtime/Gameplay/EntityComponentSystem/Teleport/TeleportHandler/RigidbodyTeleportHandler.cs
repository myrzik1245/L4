using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportHandler
{
    public class RigidbodyTeleportHandler : ITeleportHandler
    {
        private readonly Rigidbody _rigidbody;

        public RigidbodyTeleportHandler(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Execute(Vector3 position)
        {
            _rigidbody.position = position;
        }
    }
}

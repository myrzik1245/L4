using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.Components
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }

    public class CharacterControllerComponent : IEntityComponent
    {
        public CharacterController Value;
    }
}

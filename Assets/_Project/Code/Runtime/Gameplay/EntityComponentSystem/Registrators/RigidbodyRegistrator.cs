using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Registrators
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyRegistrator : MonoRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new RigidbodyComponent() { Value = GetComponent<Rigidbody>() });
        }
    }
}

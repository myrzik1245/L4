using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Registrators
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerRegistrator : MonoRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new CharacterControllerComponent() { Value = GetComponent<CharacterController>()});
        }
    }
}

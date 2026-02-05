using Assets._Project.Code.Runtime.Gameplay.Entities;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntitiesCore
{
    public abstract class MonoRegistrator : MonoBehaviour
    {
        public abstract void Register(Entity entity);
    }
}

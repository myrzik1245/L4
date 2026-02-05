using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.Entities
{
    public class MonoEntity : MonoBehaviour
    {
        public void Setup(Entity entity)
        {
            MonoRegistrator[] registrators = GetComponentsInChildren<MonoRegistrator>();

            if (registrators != null)
                foreach (MonoRegistrator registrator in registrators)
                    registrator.Register(entity);
        }

        public void Remove(Entity entity) 
        {
            Destroy(gameObject);
        }
    }
}

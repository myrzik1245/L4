using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser
{
    public interface IPositionRandomizer
    {
        Vector3 GetPosition();
    }
}

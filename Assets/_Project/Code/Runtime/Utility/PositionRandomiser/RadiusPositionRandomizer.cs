using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser
{
    public class RadiusPositionRandomizer : IPositionRandomizer
    {
        private readonly float _radius;

        public RadiusPositionRandomizer(float radius)
        {
            _radius = radius;
        }

        public Vector3 GetPosition(Vector3 offset = default)
        {
            Vector2 randomPoint = Random.insideUnitCircle * _radius;
            return new Vector3(randomPoint.x, 0, randomPoint.y) + offset;
       } 
    }
}

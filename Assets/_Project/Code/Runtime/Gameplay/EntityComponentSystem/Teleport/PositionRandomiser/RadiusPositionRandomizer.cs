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

        public Vector3 GetPosition()
        {
            Vector2 randomPoint = Random.insideUnitCircle;
            return new Vector3(randomPoint.x, 0, randomPoint.y) * Random.Range(0, _radius);
        }
    }
}

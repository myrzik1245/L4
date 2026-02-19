using Assets._Project.Code.Runtime.Gameplay.Entities;
using System.Collections.Generic;

namespace _Project.Code.Runtime.Gameplay.AI.TargetSelector
{
    public interface ITargetSelector
    {
        Entity Select(IEnumerable<Entity> entities);
    }
}

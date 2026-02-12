using UnityEngine;

namespace Assets._Project.Code.Runtime.Configs.Characters
{
    [CreateAssetMenu(fileName = "TargetCharacter", menuName = "Scriptable Objects/TargetCharacter")]
    public class TargetCharacter : ScriptableObject
    {
        [field: SerializeField] public int Health {  get; private set; }
    }
}
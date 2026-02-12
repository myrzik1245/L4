using UnityEngine;

namespace Assets._Project.Code.Runtime.Configs.Characters
{
    [CreateAssetMenu(fileName = "TeleportCharacter", menuName = "Scriptable Objects/TeleportCharacter")]
    public class TeleportCharacter : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int Energy { get; private set; }
        [field: SerializeField] public int MaxEnergy { get; private set; }
        [field: SerializeField] public int EnergyRegenPercent { get; private set; }
        [field: SerializeField] public int EnergyRegenCooldown { get; private set; }
        [field: SerializeField] public float TeleportRadius { get; private set; }
        [field: SerializeField] public int TeleportSpendEnergy { get; private set; }
        [field: SerializeField] public float AttackRadius { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}
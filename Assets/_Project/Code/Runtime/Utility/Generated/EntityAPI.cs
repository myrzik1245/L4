namespace Assets._Project.Code.Runtime.Gameplay.Entities
{
	public partial class Entity
	{
		public Assets._Project.Code.Runtime.Gameplay.Energy.EnergyComponent EnergyC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Energy.EnergyComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> Energy => EnergyC.Value;
		public Entity AddEnergy(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Energy.EnergyComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Energy.MaxEnergyComponent MaxEnergyC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Energy.MaxEnergyComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> MaxEnergy => MaxEnergyC.Value;
		public Entity AddMaxEnergy(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Energy.MaxEnergyComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenPercentComponent EnergyRegenPercentC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenPercentComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> EnergyRegenPercent => EnergyRegenPercentC.Value;
		public Entity AddEnergyRegenPercent(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenPercentComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenCooldownComponent EnergyRegenCooldownC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenCooldownComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> EnergyRegenCooldown => EnergyRegenCooldownC.Value;
		public Entity AddEnergyRegenCooldown(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Energy.EnergyRegenCooldownComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRequestComponent TeleportRequestC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRequestComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Event.ReactiveEvent TeleportRequest => TeleportRequestC.Value;
		public Entity AddTeleportRequest(Assets._Project.Code.Runtime.Utility.Reactive.Event.ReactiveEvent value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRequestComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportEvent TeleportEventC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportEvent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Event.ReactiveEvent<UnityEngine.Vector3> TeleportEvent => TeleportEventC.Value;
		public Entity AddTeleportEvent(Assets._Project.Code.Runtime.Utility.Reactive.Event.ReactiveEvent<UnityEngine.Vector3> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportEvent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRadiusComponent TeleportRadiusC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRadiusComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> TeleportRadius => TeleportRadiusC.Value;
		public Entity AddTeleportRadius(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportRadiusComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportSpendEnergyComponent TeleportSpendEnergyC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportSpendEnergyComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> TeleportSpendEnergy => TeleportSpendEnergyC.Value;
		public Entity AddTeleportSpendEnergy(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportSpendEnergyComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.IsAliveComponent IsAliveC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.IsAliveComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Boolean> IsAlive => IsAliveC.Value;
		public Entity AddIsAlive(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Boolean> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.IsAliveComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.HealthComponent HealthC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.HealthComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> Health => HealthC.Value;
		public Entity AddHealth(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.HealthComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.MaxHealthComponent MaxHealthC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.MaxHealthComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> MaxHealth => MaxHealthC.Value;
		public Entity AddMaxHealth(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Int32> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.MaxHealthComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.RotationSpeedComponent RotationSpeedC => GetComponent<Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.RotationSpeedComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;
		public Entity AddRotationSpeed(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components.RotationSpeedComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.RigidbodyComponent>();
		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;
		public Entity AddRigidbody(UnityEngine.Rigidbody value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.RigidbodyComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.CharacterControllerComponent>();
		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;
		public Entity AddCharacterController(UnityEngine.CharacterController value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.CharacterControllerComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.TransformComponent TransformC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.TransformComponent>();
		public UnityEngine.Transform Transform => TransformC.Value;
		public Entity AddTransform(UnityEngine.Transform value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.TransformComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.VelocityComponent VelocityC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.VelocityComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<UnityEngine.Vector3> Velocity => VelocityC.Value;
		public Entity AddVelocity(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<UnityEngine.Vector3> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.VelocityComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.MoveDirectionComponent MoveDirectionC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.MoveDirectionComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;
		public Entity AddMoveDirection(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<UnityEngine.Vector3> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.MoveDirectionComponent() { Value = value });

		public Assets._Project.Code.Runtime.Gameplay.Components.MoveSpeedComponent MoveSpeedC => GetComponent<Assets._Project.Code.Runtime.Gameplay.Components.MoveSpeedComponent>();
		public Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;
		public Entity AddMoveSpeed(Assets._Project.Code.Runtime.Utility.Reactive.Variable.ReactiveVariable<System.Single> value) => AddComponent(new Assets._Project.Code.Runtime.Gameplay.Components.MoveSpeedComponent() { Value = value });

	}
}

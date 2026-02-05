using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.Factories;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Code.Utility.InputService.Keyboard;
using UnityEngine;

namespace Assets._Project.Code.Infrastructure.EntryPoints
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoEntity _rigidbodyPrefab;
        [SerializeField] private MonoEntity _characterControllerPrefab;

        private EntitiesFactory _entitiesFactory;
        private MonoEntitiesFactory _monoEntitiesFactory;
        private EntityLifeContext _lifeContext;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new KeyboardInput();
            _entitiesFactory = new EntitiesFactory(_inputService);
            _lifeContext = new EntityLifeContext();
            _monoEntitiesFactory = new MonoEntitiesFactory(_lifeContext);

            Entity rigidbodyPlayer = _entitiesFactory.CreateRigidbodyPlayerEntity();
            MonoEntity monoRigidbodyPlayer 
                = _monoEntitiesFactory.Create(rigidbodyPlayer, Vector3.right, _rigidbodyPrefab);

            _lifeContext.Add(rigidbodyPlayer);

            Entity characterControllerPlayer = _entitiesFactory.CreateCharacterControllerEntity();
            MonoEntity monoCharacterControllerPlayer
                = _monoEntitiesFactory.Create(characterControllerPlayer, Vector3.left, _characterControllerPrefab);

            _lifeContext.Add(characterControllerPlayer);
        }

        private void Update()
        {
            _lifeContext.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _lifeContext.Dispose();
        }
    }
}
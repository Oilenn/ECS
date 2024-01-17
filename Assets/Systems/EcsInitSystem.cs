using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;
        private readonly EcsStartup _startup;

        public SceneData _sceneData;

        public void Init (IEcsSystems systems) {
            _sceneData = _startup.SceneData;

            ref var soldier1 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());
            ref var soldier2 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());

            Debug.Log(_sceneData.SoldiersList[0].gameObject);

            soldier1.GameObject = _sceneData.SoldiersList[0].gameObject;
            soldier2.GameObject = _sceneData.SoldiersList[1].gameObject;
        }
    }
}
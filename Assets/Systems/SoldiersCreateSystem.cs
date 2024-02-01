using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class SoldiersCreateSystem : IEcsRunSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;
        readonly EcsCustomInject<SceneData> _sceneData = default;

        private readonly EcsPoolInject<MapComponent> _poolMap = default;

        public void Run (IEcsSystems systems) {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ref var map = ref _poolMap.Value.Get(0);
                ref var soldier = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());

                soldier.GameObject = InstantiateSoldier();

                soldier.StandedTile = map.TileRows[3][3];
            }
        }

        public GameObject InstantiateSoldier()
        {
            return Object.Instantiate(_sceneData.Value.SoldierPrefab);
        }
    }
}
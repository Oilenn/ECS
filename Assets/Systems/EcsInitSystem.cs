using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;
        readonly EcsCustomInject<SceneData> _sceneData = default;

        public void Init (IEcsSystems systems) {
            var ecsWorld = systems.GetWorld();


            ref var soldier1 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());
            ref var soldier2 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());
            
            soldier1.GameObject = _sceneData.Value.SoldiersList[0].gameObject;
            soldier2.GameObject = _sceneData.Value.SoldiersList[1].gameObject;

            soldier1.NeedToMove = true;
            soldier2.NeedToMove = true;
        }
    }
}
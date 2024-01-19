using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;

        public void Init (IEcsSystems systems) {
            var ecsWorld = systems.GetWorld();
            
            SceneData sceneData = systems.GetShared<SceneData>();
            Debug.Log(sceneData);


            ref var soldier1 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());
            ref var soldier2 = ref _poolSoldiers.Value.Add(_world.Value.NewEntity());
            
            soldier1.GameObject = sceneData.SoldiersList[0].gameObject;
            soldier2.GameObject = sceneData.SoldiersList[1].gameObject;
        }
    }
}
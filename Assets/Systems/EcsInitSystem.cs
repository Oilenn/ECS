using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<EcsComponent> _ecsPool = default;

        public void Init (IEcsSystems systems) {
            Debug.Log("131231");
            ref var ecs = ref _ecsPool.Value.Add(_world.Value.NewEntity());
            ecs.x = 2;
        }
    }
}
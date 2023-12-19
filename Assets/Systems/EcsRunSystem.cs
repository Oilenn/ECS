using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class EcsRunSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<EcsComponent>> ecsFilterInject = default;

        public void Run (IEcsSystems systems) {
            foreach(var entity in ecsFilterInject.Value)
            {
                ecsFilterInject.Pools.Inc1.Del(entity);
            }
        }
    }
}
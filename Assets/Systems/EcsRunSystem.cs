using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Client {
    sealed class EcsRunSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<ButtonComponent>> ecsFilterInject = default;

        public void Run (IEcsSystems systems) {
            foreach(var entity in ecsFilterInject.Value)
            {
                Debug.Log("Running");
            }
        }
    }
}
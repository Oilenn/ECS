using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class ChangeUnitLocationSystem : IEcsRunSystem {
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;

        private readonly EcsPoolInject<MapComponent> _poolMap = default;


        public void Run (IEcsSystems systems) {
             
        }
    }
}
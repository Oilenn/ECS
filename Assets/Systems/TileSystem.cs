using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class TileSystem : IEcsRunSystem {
        private readonly EcsPoolInject<TileComponent> _poolTiles = default;
        private readonly EcsFilterInject<Inc<TileComponent>> _tilesInject = default;
        
        private readonly EcsPoolInject<TileUnit> _poolTileUnits = default;
        private readonly EcsFilterInject<Inc<TileUnit>> _tilesUnitInject = default;
        
        public void Run (IEcsSystems systems) {
            foreach (var entity in _tilesInject.Value)
            {
                ref var tile = ref _poolTiles.Value.Get(entity);

                if (tile.type == TileType.Water)
                {
                    
                }
            }
        }
    }
}
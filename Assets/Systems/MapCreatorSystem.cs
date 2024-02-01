using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Collections.Generic;
using UnityEngine;

namespace Client {
    sealed class MapCreatorSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsCustomInject<SceneData> _sceneData = default;
        private readonly EcsPoolInject<MapComponent> _poolMap = default;
        private readonly EcsPoolInject<TileComponent> _poolTiles = default;

        public void Init(IEcsSystems systems) {
            GenerateMap(2,2);
        }

        public void GenerateMap(int xLenght, int yLenght)
        {
            ref var map = ref _poolMap.Value.Add(_world.Value.NewEntity());
            map.TileRows = new List<List<TileComponent>>();

            for (float y = 0; y < yLenght; y += 0.2f)
            {
                map.TileRows.Add(new List<TileComponent>());

                for (float x = 0; x < xLenght; x += 0.2f)
                {
                    ref var tile = ref _poolTiles.Value.Add(_world.Value.NewEntity());
                    tile.Nodes = new List<TileComponent>();

                    map.TileRows[map.TileRows.Count - 1].Add(tile);

                    tile.TileGameObject = CreateTile();
                    tile.TileGameObject.transform.position = new Vector2(x, y);

                    GenerateNodes(ref map, ref tile);
                }
            }

            Debug.Log(map.TileRows[1][1].Nodes.Count);
            
        }

        public void GenerateNodes(ref MapComponent map, ref TileComponent tile)
        {
            int lastY = map.TileRows.Count - 1;
            int lastX = map.TileRows[lastY].Count - 1;

            if (lastY > 0)
            {
                tile.Nodes.Add(map.TileRows[lastY - 1][lastX]);
                map.TileRows[lastY - 1][lastX].Nodes.Add(tile);

                //Debug.Log(tile.Nodes.Count + " - Nodes Count\n" + $"{lastX};{lastY}");
            }

            if (lastX > 0)
            {
                tile.Nodes.Add(map.TileRows[lastY][lastX - 1]);
                map.TileRows[lastY][lastX - 1].Nodes.Add(tile);

                //Debug.Log(tile.Nodes.Count + " - Nodes Count\n" + $"{lastX};{lastY}");
            }
        }

        public GameObject CreateTile()
        {
            return Object.Instantiate(_sceneData.Value.TilePrefab);
        }
    }
}
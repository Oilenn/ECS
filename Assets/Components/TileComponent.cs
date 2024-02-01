using System.Collections.Generic;
using UnityEngine;

namespace Client {
    struct TileComponent
    {
        public GameObject TileGameObject;
        public TileType Type;
        public List<TileComponent> Nodes;
    }
}
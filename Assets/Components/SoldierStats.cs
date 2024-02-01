using UnityEngine;

namespace Client {
    struct SoldierStats {
        public float Speed;
        public GameObject GameObject;
        public bool NeedToMove;
        public TileComponent StandedTile;
    }
}
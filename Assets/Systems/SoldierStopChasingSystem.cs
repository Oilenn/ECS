using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.Scripting;

namespace Client
{
    sealed class SoldierStopChasingSystem : IEcsRunSystem
    {
        [Preserve] // Этот атрибут необходим для сохранения этого метода для il2cpp.
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;
        private readonly EcsFilterInject<Inc<SoldierStats>> _ecsFilterInject = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _ecsFilterInject.Value)
            {
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

                ref var soldier = ref _poolSoldiers.Value.Get(entity);
                    
                Debug.Log((Vector3.Distance(mousepos, soldier.GameObject.transform.position)) + " " + soldier.GameObject.name);

                if (Vector3.Distance(mousepos, soldier.GameObject.transform.position) < 0.15f)
                {
                    soldier.NeedToMove = false;
                }
                else
                {
                    soldier.NeedToMove = true;
                }
            }
        }
    }
}
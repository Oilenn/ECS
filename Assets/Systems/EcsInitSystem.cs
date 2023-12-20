using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<EcsComponent> _poolButtons = default;

        public ButtonsFolder buttons;

        public void Init (IEcsSystems systems) {
            Debug.Log("Init");


            ref var button1 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button2 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button3 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button4 = ref _poolButtons.Value.Add(_world.Value.NewEntity());

            button1.Button = buttons.GetButton(0);
            button1.Button = buttons.GetButton(1);
            button1.Button = buttons.GetButton(2);
            button1.Button = buttons.GetButton(3);

            
        }
    }
}
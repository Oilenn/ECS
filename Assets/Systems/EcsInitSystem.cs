using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<SoldierStats> _poolButtons = default;

        public ButtonsFolder buttons;

        public void Init (IEcsSystems systems) {
            ref var soldier1 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var soldier2 = ref _poolButtons.Value.Add(_world.Value.NewEntity());

        }

        public EcsInitSystem SetButtons(ButtonsFolder buttons)
        {
            this.buttons = buttons;
            return this;
        }


        public void OnClickButton()
        {
            Debug.Log("Button clicked");
        }
    }
}
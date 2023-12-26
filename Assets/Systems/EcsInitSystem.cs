using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<ButtonComponent> _poolButtons = default;

        public ButtonsFolder buttons;

        public void Init (IEcsSystems systems) {

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
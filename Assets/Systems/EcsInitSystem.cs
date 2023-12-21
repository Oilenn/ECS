using Leopotam.EcsLite;
using UnityEngine;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<ButtonComponent> _poolButtons = default;

        public ButtonsFolder buttons;

        public void Init (IEcsSystems systems) {
            Debug.Log("Init");

            ref var button1 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button2 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button3 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            ref var button4 = ref _poolButtons.Value.Add(_world.Value.NewEntity());
            
            button1.Button = buttons.GetButton(0);
            button2.Button = buttons.GetButton(1);
            button3.Button = buttons.GetButton(2);
            button4.Button = buttons.GetButton(3);
            button1.Button.onClick.AddListener(OnClickButton);
            button2.Button.onClick.AddListener(OnClickButton);
            button3.Button.onClick.AddListener(OnClickButton);
            button4.Button.onClick.AddListener(OnClickButton);

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
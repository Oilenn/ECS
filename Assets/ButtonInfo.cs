using System.Collections;
using UnityEngine;

namespace Client
{
    public class ButtonInfo : MonoBehaviour
    {
        public ButtonType buttonType;

        private void Start()
        {
            if (buttonType == ButtonType.SoundMaker)
            {
                gameObject.AddComponent<AudioSource>();
            }
        }
    }
    public enum ButtonType{
        ColorChanger,
        Writer,
        SoundMaker,
        Replacer
    }
}
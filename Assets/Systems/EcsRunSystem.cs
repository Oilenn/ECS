using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace Client {
    sealed class EcsRunSystem : EcsUguiCallbackSystem
    {
        [Preserve] // Этот атрибут необходим для сохранения этого метода для il2cpp.
        [EcsUguiClickEvent("TestButtons")]
        void OnAnyClick(in EcsUguiClickEvent evt)
        {
            var obj = evt.Sender.GetComponent<ButtonInfo>();
            switch (obj.buttonType)
            {
                case ButtonType.ColorChanger:
                    var colors = obj.gameObject.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    //colors.normalColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    //obj.gameObject.GetComponent<Button>().colors = colors;
                    break;
                case ButtonType.Writer:
                    Debug.Log("This is writer");
                    break;
                case ButtonType.Replacer:
                    obj.gameObject.transform.position = new Vector3(Random.Range(-10f, 500f), Random.Range(-10, 500), Random.Range(-10, 500));
                    break;
                case ButtonType.SoundMaker:
                    AudioSource a = obj.gameObject.GetComponent<AudioSource>();
                    a.clip = Resources.Load<AudioClip>("Sounds/Sound");
                    a.Play();
                    Debug.Log("This is soundmaker");
                    break;
            }
            Debug.Log("Im clicked!", evt.Sender);
        }
    }
}
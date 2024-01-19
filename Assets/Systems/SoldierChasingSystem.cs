using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using UnityEngine.Scripting;

namespace Client
{
    sealed class SoldierChasingSystem : IEcsRunSystem
    {
        [Preserve] // Этот атрибут необходим для сохранения этого метода для il2cpp.
        private readonly EcsPoolInject<SoldierStats> _poolSoldiers = default;
        private readonly EcsFilterInject<Inc<SoldierStats>> _ecsFilterInject = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _ecsFilterInject.Value)
            {
                ref var soldier = ref _poolSoldiers.Value.Get(entity);
                Move(soldier.GameObject);
            }
        }

        public void Move(GameObject gameObject)
        {
            Debug.Log("Move");
            gameObject.transform.position += new Vector3(0,0);
            
        }

        

        //void OnAnyClick(in EcsUguiClickEvent evt)
        //{
        //    var obj = evt.Sender.GetComponent<ButtonInfo>();
        //    switch (obj.buttonType)
        //    {
        //        case ButtonType.ColorChanger:
        //            var colors = obj.gameObject.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //            //colors.normalColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //            //obj.gameObject.GetComponent<Button>().colors = colors;
        //            break;
        //        case ButtonType.Writer:
        //            Debug.Log("This is writer");
        //            break;
        //        case ButtonType.Replacer:
        //            obj.gameObject.transform.position = new Vector3(Random.Range(-10f, 500f), Random.Range(-10, 500), Random.Range(-10, 500));
        //            break;
        //        case ButtonType.SoundMaker:
        //            AudioSource a = obj.gameObject.GetComponent<AudioSource>();
        //            a.clip = Resources.Load<AudioClip>("Sounds/Sound");
        //            a.Play();
        //            Debug.Log("This is soundmaker");
        //            break;
        //    }
        //    Debug.Log("Im clicked!", evt.Sender);
        //}
    }
}
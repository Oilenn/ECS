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

                

                if (soldier.NeedToMove)
                {
                    Move(soldier.GameObject);
                }
            }
        }

        public void Move(GameObject gameObject)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, mousepos, Time.deltaTime);
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
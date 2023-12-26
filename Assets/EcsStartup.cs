using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;
using UnityEngine;
using UnityEngine.UI;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        [SerializeField] EcsUguiEmitter _emmiter;

        EcsWorld _world;        
        IEcsSystems _systems;
        
        void Start () {
            GameObject _btnGo;
            Transform _btnTransform;
            Button _btn;


            // Получение ссылки на виджет-действие с именем "MyButton". 
            //_btnGo = _emmiter.GetNamedObject("Start");
            // Чтение Transform-компонента с него.
            //_btnTransform = _emmiter.GetNamedObject("Start").GetComponent<Transform>();
            // Чтение Button-компонента с него.
            //_btn = _emmiter.GetNamedObject("Start").GetComponent<Button>();

            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            

            _systems
                .Add(new EcsRunSystem())
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())

                // register additional worlds here, for example:
                // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
                // add debug systems for custom worlds here, for example:
                // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .InjectUgui(_emmiter)
                .Inject()
                .Init ();
        }

        void Update () {
            // process systems here.
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }

            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        [SerializeField] private EcsUguiEmitter _emmiter;
        public SceneData SceneData;
        private EcsWorld _world;
        private IEcsSystems _systems;

        void Start () {
            var data = new SceneData();
            data.SoldiersList = SceneData.SoldiersList;

            _world = new EcsWorld ();
            _systems = new EcsSystems (_world, data)
                .Add(new EcsInitSystem())


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

                .Inject(data);
                _systems.Init ();
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
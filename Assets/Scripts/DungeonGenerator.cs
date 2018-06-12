using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace EnergonSoftware.Generator
{
    // tilemaps - https://www.youtube.com/watch?v=ryISV_nH8qw

    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField]
        private bool _generateOnAwake;

        [SerializeField]
        private Tilemap _tilemap;

        [SerializeField]
        private Tilemap[] _tilesets;

        [SerializeField]
        private DungeonGeneratorMethod _method;

        private readonly List<DungeonRoom> _rooms = new List<DungeonRoom>();

#region Unity Lifecycle
        private void Awake()
        {
            if(_generateOnAwake) {
                Generate(new System.Random());
            }
        }
#endregion

        public void Clear()
        {
            Debug.Log("Clearing current dungeon...");

            _tilemap.ClearAllTiles();
        }

        public DungeonRoom Generate()
        {
            return Generate(new System.Random());
        }

        public DungeonRoom Generate(System.Random random)
        {
            if(_tilesets.Length < 1) {
                Debug.LogError("No tilesets!");
                return null;
            }

            if(null == _method) {
                Debug.LogError("No generator method!");
                return null;
            }

            Clear();

            Tilemap tileset = random.GetRandomEntry(_tilesets);

            Debug.Log($"Generating dungeon using method {_method.Name} and tileset {tileset.name}");
            _method.Generate(this, random, _tilemap, tileset);

            return _rooms[random.Next(_rooms.Count)];
        }

        public void AddRoom(DungeonRoom room)
        {
            _rooms.Add(room);
        }
    }
}

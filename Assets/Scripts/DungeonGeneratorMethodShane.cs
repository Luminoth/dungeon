using UnityEngine;
using UnityEngine.Tilemaps;

namespace EnergonSoftware.Generator
{
    public class DungeonGeneratorMethodShane : DungeonGeneratorMethod
    {
        public override string Name => name;

        [SerializeField]
        [Range(0, 50)]
        private int _dungeonWidth = 5;

        [SerializeField]
        [Range(0, 50)]
        private int _dungeonHeight = 10;

        [SerializeField]
        [Range(0, 20)]
        private int _roomWidth = 10;

        [SerializeField]
        [Range(0, 20)]
        private int _roomHeight = 10;

        public override void Generate(DungeonGenerator generator, System.Random random, Tilemap tilemap, Tilemap tileset)
        {
            Debug.Log($"Generating dungeon with {_dungeonWidth}x{_dungeonHeight} rooms...");
            for(int y=0; y<_dungeonHeight; ++y) {
                for(int x=0; x<_dungeonWidth; ++x) {
                    GenerateRoom(generator, random, tilemap, tileset, x, y);
                }
            }
        }

        private void GenerateRoom(DungeonGenerator generator, System.Random random, Tilemap tilemap, Tilemap tileset, int x, int y)
        {
            //Debug.Log($"Generating room at ({x}, {y})...");

            DungeonRoom room = new DungeonRoom(new Vector2Int(x * _roomWidth, y * _roomHeight), _roomWidth, _roomHeight);
            room.GenerateTilemap(tilemap, tileset);

            generator.AddRoom(room);
        }
    }
}

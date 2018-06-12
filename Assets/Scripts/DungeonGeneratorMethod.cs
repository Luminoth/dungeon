using UnityEngine;
using UnityEngine.Tilemaps;

namespace EnergonSoftware.Generator
{
    public abstract class DungeonGeneratorMethod : MonoBehaviour
    {
        public abstract string Name { get; }

        public abstract void Generate(DungeonGenerator generator, System.Random random, Tilemap tilemap, Tilemap tileset);
    }
}

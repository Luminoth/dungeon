using System;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace EnergonSoftware.Generator
{
    public class DungeonRoom
    {
        private static readonly Vector3Int CenterTilePosition = new Vector3Int(0, 1, 0);

        public Vector2Int RoomPosition { get; }

        public int Width { get; }

        public int Height { get; }

        public DungeonRoom(Vector2Int roomPosition, int width, int height)
        {
            RoomPosition = roomPosition;

            Width = width;
            Height = height;
        }

        public void GenerateTilemap(Tilemap tilemap, Tilemap tileset)
        {
            for(int y=0; y<Height; ++y) {
                for(int x=0; x<Width; ++x) {
                    Vector3Int tilePosition = new Vector3Int(RoomPosition.x + x, RoomPosition.y + y, 0);
                    tilemap.SetTile(tilePosition, tileset.GetTile(CenterTilePosition));
                }
            }
        }

        public Vector2Int RandomPositionInside(System.Random random)
        {
            Vector2Int randomPosition = new Vector2Int(
                random.Next(Width),
                random.Next(Height)
            );
            return RoomPosition + randomPosition;
        }
    }
}

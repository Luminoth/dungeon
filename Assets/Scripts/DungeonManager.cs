using System;

using UnityEngine;

namespace EnergonSoftware.Generator
{
    public sealed class DungeonManager : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private DungeonGenerator _generator;

        private readonly System.Random _random = new System.Random();

#region Unity Lifecycle
        private void Start()
        {
            DungeonRoom start = _generator.Generate(_random);
            Vector2 startPosition = start.RandomPositionInside(_random);
            Debug.Log($"Starting at position {startPosition}");

            _camera.transform.position = new Vector3(startPosition.x, startPosition.y, _camera.transform.position.z);
        }
#endregion
    }
}

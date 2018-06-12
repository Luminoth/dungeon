using UnityEditor;
using UnityEngine;

namespace EnergonSoftware.Generator.Editor
{
    [CustomEditor(typeof(DungeonGenerator))]
    public class DungeonGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DungeonGenerator generator = (DungeonGenerator)target;
            if(GUILayout.Button("Generate")) {
                generator.Generate();
            }

            if(GUILayout.Button("Clear")) {
                generator.Clear();
            }
        }
    }
}

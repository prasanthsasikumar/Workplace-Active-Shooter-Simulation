using UnityEditor;
#if !UNITY_2020_1_OR_NEWER
using UnityEditor.Experimental.AssetImporters;
#else
using UnityEditor.AssetImporters;
#endif
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ambiens.avro
{
#if !UNITY_2020_1_OR_NEWER
    [CustomEditor(typeof(AvroImporter2019))]
#else
    [CustomEditor(typeof(AvroImporter2020))]
#endif
    [CanEditMultipleObjects]
    public class AvroImporterCustomInspector : ScriptedImporterEditor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using ambiens.archtoolkit.atexplore.XNodeEditor;

namespace ambiens.archtoolkit.atexplore.actionSystem{
    [CustomNodeEditor(typeof(TriggerOnHandleClick))]
    public class TriggerOnHandleClickCustomEditor : CustomNodeEditorBase
    {
        private int handleIndex;
        private List<Sprite> spriteList = null;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            serializedObject.Update();

            EditorGUILayout.LabelField("Handles", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            if(spriteList==null)spriteList= GetAssetList<Sprite>("Ambiens/ArchToolkit/ATExplore/Resources/Handles/HandleTypes");

            var handlesNames = new List<string>();
            foreach (var h in spriteList) handlesNames.Add(h.name);

            this.handleIndex=EditorGUILayout.Popup("Handle", this.handleIndex, handlesNames.ToArray());

            if (GUILayout.Button(new GUIContent("+", "Add an handle to the scene")))
            {
                var go=GameObject.Instantiate(Resources.Load<GameObject>("Handles/GenericHandle"));
                go.transform.parent = references.transform;
                go.transform.position= ArchToolkit.Utils.ArchToolkitProgrammingUtils.FrontOfEditorCamera();
                go.GetComponent<SpriteRenderer>().sprite = spriteList[handleIndex];

                references.gameObjects.Add(go);
                EditorSceneManager.MarkAllScenesDirty();
            }
            EditorGUILayout.EndHorizontal();

            var sm = this.InitSceneReferences<TriggerOnHandleClick>();
            if (sm == null) return;


        }

        public static List<T> GetAssetList<T>(string path) where T : class
        {
            string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

            return fileEntries.Select(fileName =>
            {
                string assetPath = fileName.Substring(fileName.IndexOf("Assets"));
                assetPath = Path.ChangeExtension(assetPath, null);
                return UnityEditor.AssetDatabase.LoadAssetAtPath(assetPath, typeof(T));
            })
                .OfType<T>()
                .ToList();
        }
    }
}


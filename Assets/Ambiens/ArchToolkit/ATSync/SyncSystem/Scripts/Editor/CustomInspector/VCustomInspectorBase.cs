using UnityEngine;
using UnityEditor;

public class VCustomInspectrBase : Editor
{
    static bool ViewData = false;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ViewData = EditorGUILayout.Toggle("ViewData", ViewData);
        if (ViewData)
        {
            DrawDefaultInspector();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
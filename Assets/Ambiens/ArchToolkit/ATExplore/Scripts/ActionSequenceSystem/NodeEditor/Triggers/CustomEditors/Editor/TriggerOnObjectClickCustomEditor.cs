using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using ambiens.archtoolkit.atexplore.XNodeEditor;

namespace ambiens.archtoolkit.atexplore.actionSystem{
    [CustomNodeEditor(typeof(TriggerOnObjectClick))]
    public class TriggerOnClickCustomEditor : CustomNodeEditorBase
    {

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            serializedObject.Update();

            var sm = this.InitSceneReferences<TriggerOnObjectClick>();
            if (sm == null) return;


        }
    }
}


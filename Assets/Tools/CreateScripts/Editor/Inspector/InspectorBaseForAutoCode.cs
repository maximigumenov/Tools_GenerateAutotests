using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CreateScriptsSpace;

[CustomEditor(typeof(BaseForAutoCode))]
public class InspectorBaseForAutoCode : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BaseForAutoCode manager = (BaseForAutoCode)target;

        var style = new GUIStyle(GUI.skin.button);

        style.normal.textColor = Color.blue;

        if (GUILayout.Button("Generate base", style))
        {
            manager.Call();
        }

       
    }
}

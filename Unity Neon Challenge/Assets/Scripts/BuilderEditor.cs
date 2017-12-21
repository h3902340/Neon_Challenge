using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(procedural_mesh))]
[CanEditMultipleObjects]
public class BuilderEditor : Editor
{
    SerializedProperty width;
    SerializedProperty length;
    SerializedProperty height;
    SerializedProperty width_unit;
    SerializedProperty length_unit;
    SerializedProperty height_unit;
    private void OnEnable()
    {
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");
        length = serializedObject.FindProperty("length");
        width_unit = serializedObject.FindProperty("width_unit");
        length_unit = serializedObject.FindProperty("length_unit");
        height_unit = serializedObject.FindProperty("height_unit");
    }
    
    public override void OnInspectorGUI() {
        serializedObject.Update();
        procedural_mesh myScript = (procedural_mesh)target;
        if(GUILayout.Button("Place Props"))
        {
            myScript.PlaceProps();
        }
        if (GUILayout.Button("Remove Props"))
        {
            myScript.RemoveProps();
        }
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            // Block of code with controls
            // that may set GUI.changed to true
            
            EditorGUILayout.IntSlider(width, 1, 10, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            EditorGUILayout.IntSlider(height, 1, 10, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            EditorGUILayout.IntSlider(length, 1, 10, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            EditorGUILayout.Slider(width_unit, 1, 5, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            EditorGUILayout.Slider(length_unit, 1, 5, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            EditorGUILayout.Slider(height_unit, 1, 5, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
            if (check.changed)
            {
                myScript.BuildObject();
                // Code to execute if GUI.changed
                // was set to true inside the block of code above.
            }
            serializedObject.ApplyModifiedProperties();
        }
        DrawDefaultInspector();
    }
}

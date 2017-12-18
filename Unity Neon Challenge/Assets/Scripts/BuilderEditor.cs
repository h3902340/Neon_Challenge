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
    private void OnEnable()
    {
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");
        length = serializedObject.FindProperty("length");
    }
    
    public override void OnInspectorGUI() {
        serializedObject.Update();
        procedural_mesh myScript = (procedural_mesh)target;
        EditorGUILayout.IntSlider(width, 1, 10,new GUILayoutOption[] {GUILayout.Height(20), GUILayout.ExpandHeight(false) });
        if (!width.hasMultipleDifferentValues)
        {
            myScript.BuildObject();
        }
        EditorGUILayout.IntSlider(height, 1, 10, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
        if (!height.hasMultipleDifferentValues)
        {
            myScript.BuildObject();
        }
        EditorGUILayout.IntSlider(length, 1, 10, new GUILayoutOption[] { GUILayout.Height(20), GUILayout.ExpandHeight(false) });
        if (!length.hasMultipleDifferentValues)
        {
            myScript.BuildObject();
        }
        serializedObject.ApplyModifiedProperties();
    }
}

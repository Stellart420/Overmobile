using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScrollControl))]
public class ScrollEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ScrollControl myTarget = (ScrollControl)target;

        if (GUILayout.Button("Reset"))
        {
            myTarget.Reset();
        }
    }
}

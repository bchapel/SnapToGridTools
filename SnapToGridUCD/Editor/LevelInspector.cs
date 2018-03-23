using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelClass))]

public class LevelInspector : Editor {

    private LevelClass _myTarget;
    public int rows = 20;
    public int cols = 20;

    private void OnEnable()
    {
        _myTarget = (LevelClass)this.target;
    }


    public override void OnInspectorGUI()
    {


        GUILayout.Label("Columns: " + _myTarget.cols);
        GUILayout.Label("Rows: " + _myTarget.rows);

       
       rows = EditorGUILayout.IntField("Rows", rows);
       cols = EditorGUILayout.IntField("Columns", cols);


        bool resize = GUILayout.Button("Resize Level");
        if (resize)
        {
            _myTarget.rows = rows;
            _myTarget.cols = cols;
        }

        if (rows == _myTarget.rows && cols == _myTarget.cols)
            GUI.enabled = false;
        else
            GUI.enabled = true;

        bool reset = GUILayout.Button("Reset");
        if (reset)
        {
            rows = _myTarget.rows;
            cols = _myTarget.cols;
        }

        GUI.enabled = true;

        _myTarget.totalTime = EditorGUILayout.FloatField("Current level time", _myTarget.totalTime);
        _myTarget.gravity = EditorGUILayout.FloatField("Gravity Magnitude", _myTarget.gravity);

        _myTarget.bgm = (AudioClip)EditorGUILayout.ObjectField("Background Music", _myTarget.bgm, typeof(AudioClip), true);
        _myTarget.background = (Sprite)EditorGUILayout.ObjectField("Background Display", _myTarget.background, typeof(Sprite), false);
    }
}
using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FXData))]

public class FXDataDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 3*EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, new GUIContent("FXState:"));
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        var fXRect = new Rect(position.x, position.y, position.width / 2, position.height/3);
        var fX_positioRect = new Rect(position.x + position.width / 2, position.y, position.width / 2, position.height/3);
        var fX_delayRect = new Rect(position.x, position.y+ 2 * position.height / 5+3, position.width /4, position.height / 3);
        var fX_deleteRect = new Rect(position.x + position.width /4, position.y + 2 * position.height / 5+3, position.width /4, position.height / 3);
        var fX_linktypeRect = new Rect(position.x + position.width / 2, position.y + 2 * position.height / 5 + 3, position.width / 2,  position.height /3);
        //var weightRect = new Rect(position.x + 5 * position.width / 6, position.y, position.width / 6, position.height);
        EditorGUI.PropertyField(fXRect, property.FindPropertyRelative("fX"), GUIContent.none);
        EditorGUI.PropertyField(fX_positioRect, property.FindPropertyRelative("fX_position"), GUIContent.none);
        EditorGUI.PropertyField(fX_delayRect, property.FindPropertyRelative("fX_delay"), GUIContent.none);
        EditorGUI.PropertyField(fX_deleteRect, property.FindPropertyRelative("fX_delete"), GUIContent.none);
        EditorGUI.PropertyField(fX_linktypeRect, property.FindPropertyRelative("fX_linktype"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
	
}


/*
label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, new GUIContent("FXState:"));
        var indent = EditorGUI.indentLevel;
EditorGUI.indentLevel = 0;
        var fXRect = new Rect(position.x, position.y, position.width / 2, 2 * position.height / 5);
var fX_positioRect = new Rect(position.x + position.width / 2, position.y, position.width / 2, 2 * position.height / 5);
var fX_delayRect = new Rect(position.x, position.y + 2 * position.height / 5 + 3, position.width / 4, 2 * position.height / 5);
var fX_deleteRect = new Rect(position.x + position.width / 4, position.y + 2 * position.height / 5 + 3, position.width / 4, 2 * position.height / 5);
var fX_linktypeRect = new Rect(position.x + position.width / 2, position.y + 2 * position.height / 5 + 3, position.width / 2, 2 * position.height / 5);
//var weightRect = new Rect(position.x + 5 * position.width / 6, position.y, position.width / 6, position.height);
EditorGUI.PropertyField(fXRect, property.FindPropertyRelative("fX"), GUIContent.none);
        EditorGUI.PropertyField(fX_positioRect, property.FindPropertyRelative("fX_position"), GUIContent.none);
        EditorGUI.PropertyField(fX_delayRect, property.FindPropertyRelative("fX_delay"), GUIContent.none);
        EditorGUI.PropertyField(fX_deleteRect, property.FindPropertyRelative("fX_delete"), GUIContent.none);
        EditorGUI.PropertyField(fX_linktypeRect, property.FindPropertyRelative("fX_linktype"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
*/
using System.Collections;
using UnityEngine;
using UnityEditor;
using Fungus;


[CustomPropertyDrawer(typeof(FlowchartData))]

public class FlowchartDataDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 3 * EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, new GUIContent("Flowchart Block:"));
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        var CommentRect = new Rect(position.x, position.y +3, position.width , position.height / 3);
        var FlowchartRect = new Rect(position.x, position.y + position.height / 2, position.width / 2, position.height / 3);
        var BlockRect = new Rect(position.x + position.width / 2, position.y + position.height / 2 , position.width / 2, position.height / 3);
        EditorGUI.PropertyField(CommentRect, property.FindPropertyRelative("comment"), GUIContent.none);
        EditorGUI.PropertyField(FlowchartRect, property.FindPropertyRelative("flowchart"), GUIContent.none);
        EditorGUI.PropertyField(BlockRect, property.FindPropertyRelative("block"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

}
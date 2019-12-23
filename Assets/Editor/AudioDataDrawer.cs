using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AudioData))]

public class AudioDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, new GUIContent("SFXData:"));
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        var audioFXRect= new Rect(position.x, position.y, 2*position.width /3, position.height);
        var volumeRect = new Rect(position.x + 2*position.width /3, position.y, position.width / 3, position.height);
        EditorGUI.PropertyField(audioFXRect, property.FindPropertyRelative("audioFX"), GUIContent.none);
        EditorGUI.PropertyField(volumeRect, property.FindPropertyRelative("volume"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

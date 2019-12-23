//2017.10.26
//Used for DCI 3D Artist
//Create By YingCheng Su
//actcathorse@hotmail.com

using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TheControlLightData))]

public class TheControlLightDataDrawer : PropertyDrawer
{
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return EditorGUI.GetPropertyHeight(property);
        return 100f;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, new GUIContent("LightState:"));
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //////////////////////////////////////////////////////////////////////////////////////////////////        
        //EditorGUI.LabelField(new Rect(position.x, position.y, 150, 20), "燈光--變化時間");

        var controlLightRect = new Rect(position.x, position.y, 
                                        3*position.width / 4, 16);

        var durationRect = new Rect(position.x + 3*position.width / 4, position.y,
                                    position.width / 4, 16);
        //////////////////////////////////////////////////////////////////////////////////////////////////
        var enableLightColorRect = new Rect(position.x, position.y + 20 , 
                                            position.width /12, 16);
        var lightColorRect = new Rect(position.x + position.width /12, position.y + 20, 
                                        position.width /4, 16);
        var enableLightIntensityRect = new Rect(position.x+ position.width/3, position.y + 20, 
                                                position.width/12, 16);
        var lightIntensityRect = new Rect(position.x + 5*position.width/12, position.y + 20, 
                                            position.width / 4,16);
        var enableLightBounceIntensityRect = new Rect(position.x + 2*position.width/3, position.y + 20, 
                                                        position.width/12, 16);
        var lightBounceIntensityRect = new Rect(position.x + 3*position.width/4, position.y + 20, 
                                                position.width/4, 16);
        //////////////////////////////////////////////////////////////////////////////////////////////////
        var enableLightRangeRect = new Rect(position.x , position.y + 40,
                                            position.width / 12, 16);
        var lightRangeRect = new Rect(position.x +position.width / 12, position.y + 40, 
                                        position.width / 4, 16);
        var enableLightSpotAngleRect = new Rect(position.x + position.width / 3, position.y + 40, 
                                                position.width / 12, 16);
        var lightSpotAngleRect = new Rect(position.x + 5 * position.width / 12, position.y + 40, 
                                            position.width / 4, 16);
        var enableShadowStrengthRect = new Rect(position.x + 2 * position.width / 3, position.y + 40, 
                                                position.width / 12, 3 * position.height / 20);
        var shadowStrengthRect = new Rect(position.x + 3 * position.width / 4, position.y + 40, 
                                            position.width / 4, 3 * position.height / 20);
        //////////////////////////////////////////////////////////////////////////////////////////////////
        var enableLightPositionRect = new Rect(position.x, position.y + 60, 
                                                position.width / 12, 3 * position.height / 20);
        var lightPositionRect = new Rect(position.x + position.width / 12, position.y + 60, 
                                            11*position.width / 12, 3 * position.height / 20);

        var enableLightAngleRect = new Rect(position.x, position.y + 80, 
                                            position.width / 12, 3 * position.height / 20);
        var lightAngleRect = new Rect(position.x + position.width / 12, position.y + 80, 
                                        11 * position.width / 12, 3 * position.height / 20);
        //////////////////////////////////////////////////////////////////////////////////////////////////
        
        EditorGUI.PropertyField(controlLightRect, property.FindPropertyRelative("controlLight"), GUIContent.none);
        EditorGUI.PropertyField(durationRect, property.FindPropertyRelative("duration"), GUIContent.none);
        
        EditorGUI.PropertyField(enableLightColorRect, property.FindPropertyRelative("enableLightColor"), GUIContent.none);
        EditorGUI.PropertyField(lightColorRect, property.FindPropertyRelative("lightColor"), GUIContent.none);
        EditorGUI.PropertyField(enableLightIntensityRect, property.FindPropertyRelative("enableLightIntensity"), GUIContent.none);
        EditorGUI.PropertyField(lightIntensityRect, property.FindPropertyRelative("lightIntensity"), GUIContent.none);
        EditorGUI.PropertyField(enableLightBounceIntensityRect, property.FindPropertyRelative("enableLightBounceIntensity"), GUIContent.none);
        EditorGUI.PropertyField(lightBounceIntensityRect, property.FindPropertyRelative("lightBounceIntensity"), GUIContent.none);
        
        EditorGUI.PropertyField(enableLightRangeRect, property.FindPropertyRelative("enableLightRange"), GUIContent.none);
        EditorGUI.PropertyField(lightRangeRect, property.FindPropertyRelative("lightRange"), GUIContent.none);
        EditorGUI.PropertyField(enableLightSpotAngleRect, property.FindPropertyRelative("enableLightSpotAngle"), GUIContent.none);
        EditorGUI.PropertyField(lightSpotAngleRect, property.FindPropertyRelative("lightSpotAngle"), GUIContent.none);
        EditorGUI.PropertyField(enableShadowStrengthRect, property.FindPropertyRelative("enableShadowStrength"), GUIContent.none);
        EditorGUI.PropertyField(shadowStrengthRect, property.FindPropertyRelative("shadowStrength"), GUIContent.none);

        EditorGUI.PropertyField(enableLightPositionRect, property.FindPropertyRelative("enableLightPosition"), GUIContent.none);
        EditorGUI.PropertyField(lightPositionRect, property.FindPropertyRelative("lightPosition"), GUIContent.none);

        EditorGUI.PropertyField(enableLightAngleRect, property.FindPropertyRelative("enableLightAngle"), GUIContent.none);
        EditorGUI.PropertyField(lightAngleRect, property.FindPropertyRelative("lightAngle"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

}

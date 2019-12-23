using UnityEngine;
using System;

[Serializable]
public class TheControlLightData 
{
    public Light controlLight;
    public float duration = 1.0f;

    public bool enableLightColor = false;
    public Color lightColor = Color.white  ;
    public bool enableLightIntensity = false;
    public float lightIntensity = 1.0f ;
    public bool enableLightBounceIntensity = false;
    public float lightBounceIntensity = 1.0f;

    public bool enableLightRange = false;
    public float lightRange = 1.0f;
    public bool enableLightSpotAngle = false;
    public float lightSpotAngle = 1.0f;
    public bool enableShadowStrength = false;
    public float shadowStrength = 1.0f ;

    public bool enableLightPosition = false;
    public Vector3 lightPosition = Vector3.zero;

    public bool enableLightAngle = false;
    public Vector3 lightAngle = Vector3.zero ;

    [System.NonSerialized]
    public float blendVector = 0.0f;
    public Color currentColor;
    public float currentIntensity;
    public float currentBounceIntensity;
    public float currentRange;
    public float currentSpotAngle;
    public float currentShadowStrength;
    public Vector3 currentPosition;
    public Quaternion currentAngle;

}

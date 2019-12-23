using UnityEngine;
using System.Collections;

public class TheControlLightManager : MonoBehaviour
{
    [Header("LightData:  要控制的燈光--變化時間")]
    [Header("                   顏色--燈光強度--間接光強度")]
    [Header("                   範圍--聚光燈角度--影子強度")]
    [Header("                   燈光位置")]
    [Header("                   燈光角度")]
    public TheControlLightData[] lightData ;
   

    public void ChangeIndexLight (int id)
    {
        lightData[id].blendVector = 0.0f;
        if(lightData[id].enableLightColor)
        { lightData[id].currentColor = lightData[id].controlLight.color;}

        if(lightData[id].enableLightIntensity)
        { lightData[id].currentIntensity = lightData[id].controlLight.intensity;}

        if (lightData[id].enableLightBounceIntensity)
        { lightData[id].currentIntensity = lightData[id].controlLight.bounceIntensity; }

        if (lightData[id].enableLightPosition)
        { lightData[id].currentPosition = lightData[id].controlLight.transform.position; }

        if (lightData[id].enableLightAngle)
        { lightData[id].currentAngle = lightData[id].controlLight.transform.rotation;}

        if (lightData[id].enableLightRange)
        { lightData[id].currentRange = lightData[id].controlLight.range; }

        if (lightData[id].enableLightSpotAngle)
        { lightData[id].currentSpotAngle = lightData[id].controlLight.spotAngle; }

        if (lightData[id].enableShadowStrength )
        { lightData[id].currentShadowStrength = lightData[id].controlLight.shadowStrength; }

        StartCoroutine(ChangeLight(id)) ;
        
    }

    IEnumerator ChangeLight(int id)
    {
        while (lightData[id].blendVector <= 1.0f)
        {
            if (lightData[id]. enableLightColor)
            {
                lightData[id].controlLight.color = Color.Lerp(lightData[id].currentColor, lightData[id].lightColor, lightData[id].blendVector);
            }

            if (lightData[id].enableLightIntensity)
            {
                lightData[id].controlLight.intensity = Mathf.Lerp(lightData[id].currentIntensity, lightData[id].lightIntensity, lightData[id].blendVector);
            }
            
            if (lightData[id].enableLightBounceIntensity)
            {
                lightData[id].controlLight.bounceIntensity = Mathf.Lerp(lightData[id].currentBounceIntensity, lightData[id].lightBounceIntensity, lightData[id].blendVector);
            }
                      

            if (lightData[id].enableLightPosition)
            {
                lightData[id].controlLight.transform.position = Vector3.Lerp(lightData[id].currentPosition, lightData[id].lightPosition, lightData[id].blendVector);
            }


            if (lightData[id].enableLightAngle)
            {
                var targetRotation = Quaternion.Euler(lightData[id].lightAngle);
                lightData[id].controlLight.transform.rotation = Quaternion.Lerp(lightData[id].currentAngle, targetRotation, lightData[id].blendVector);
            }

            if (lightData[id].enableLightRange)
            {
                lightData[id].controlLight.range = Mathf.Lerp(lightData[id].currentRange, lightData[id].lightRange, lightData[id].blendVector);
            }

            if (lightData[id].enableLightSpotAngle)
            {
                lightData[id].controlLight.spotAngle = Mathf.Lerp(lightData[id].currentSpotAngle, lightData[id].lightSpotAngle, lightData[id].blendVector);
            }

            if (lightData[id].enableShadowStrength)
            {
                lightData[id].controlLight.shadowStrength = Mathf.Lerp(lightData[id].currentShadowStrength, lightData[id].shadowStrength, lightData[id].blendVector);
            }

            lightData[id].blendVector += Time.deltaTime / lightData[id].duration ;
            
            yield return null;
        }
        yield return true;
    }
}

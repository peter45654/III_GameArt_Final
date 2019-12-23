using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TriggerScript : MonoBehaviour
{
    [Header("震幅")]
    public float magnitude = 1.0f;
    [Header("頻率")]
    public float frequency = 10f;
    [Header("持續時間")]
    public float duration = 1.0f;
    [Header("幅度變化")]
    public float va = 0;
    [Header("相機物件")]
    public GameObject Camera;
    //public ShakeCamera s;
    ParticleSystem ps;
    public bool isShake = false;
    Quaternion OriCamPos;
    float OriSeedScale;
    float elapsed = 0;
    int cnt = 0;
    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();

    }
    private void Update()
    {
        if (isShake)
        {
            Debug.Log("SHAKEING!");
            va = 1;
            cnt += 1;
            elapsed = 0.0f;
            isShake = false;
        }
        if (va > 0)
        {
            elapsed += Time.deltaTime;
                va += -Time.deltaTime / duration;
            Camera.transform.localRotation = Quaternion.Euler (Mathf.Sin(frequency * -5 * elapsed) * magnitude *va , 0 , 0 );
        }
        if (va < 0)
        {
            va = 0;
            Camera.transform.localRotation = OriCamPos;
            Debug.Log("END SHAKE! Magnitude Scale" + magnitude + "*" + cnt);
            cnt = 0;
        }



    }
    void OnParticleTrigger()
    {
        //  Debug.Log("Trigger in");
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            enter[i] = p;
        }
        if (enter.Count > 0)
        {

            if (!isShake)
            {
                OriCamPos = Camera.transform.localRotation; ;
                isShake = true;
            }
        }

        // iterate through the particles which exited the trigger and make them green
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            exit[i] = p;
        }

        // re-assign the modified particles back into the particle system
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        //Debug.Log("Trigger Out");
        //Debug.Log(numEnter+ " :numEnter");
    }
}
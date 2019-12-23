using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TriggerScript_bak: MonoBehaviour
{
    [Header("強度")]
    public float magnitude = 1.0f;
    [Header("持續時間")]
    public float duration = 1.0f;
    [Header("幅度變化")]
    public float form = 1;
    public float elapsed = 0;
    [Header("相機物件")]
    public GameObject Camera;
    //public ShakeCamera s;
    ParticleSystem ps;
    public bool isShake = false;
    Vector3 OriCamPos;
    float OriSeedScale;
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
            if (elapsed < duration)
            {
                Vector3 newPos = Vector3.zero;
                int c = 0;
                float recSqr = 0.0f;
                form += -Time.deltaTime / duration;
                float y = Random.Range(-0.1f, 0.1f);
                newPos = Camera.transform.localPosition = new Vector3(0, y * magnitude * form, 0);
                c++;

               // SeedScale *= ScaleFallOff;
               // if (SeedScale < minSeedScale) { SeedScale = minSeedScale; }
               // Camera.transform.localPosition = newPos;
                 elapsed += Time.deltaTime;
            }
            else
            {
                form = 1;
                Camera.transform.localPosition = OriCamPos;
                isShake = false;
                elapsed = 0.0f;
                Debug.Log("END SHAKE! Magnitude Scale" + magnitude);
            }



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
                OriCamPos = Camera.transform.localPosition; ;
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
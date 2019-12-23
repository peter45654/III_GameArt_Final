using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCycleAnimation : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] private float firsttime = 0.0f;
    [SerializeField] private float repeattime = 2.0f;

    [SerializeField] private string[] triggerName;
        
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        InvokeRepeating("PlayRandomCycleAnimation", firsttime, repeattime);
    }

    public void PlayRandomCycleAnimation()
    {
        if (triggerName.Length != 0)
        {
            float rnd = Random.Range(0, (triggerName.Length ));
            int index = Mathf.FloorToInt(rnd);

            _animator.SetTrigger(triggerName[index]);

        }
    }
    
}

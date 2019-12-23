using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour
{

    public GameObject player;
    //Quaternion rotation = Quaternion.LookRotation(delta);

    private GameObject playerObject;
    // Use this for initialization
    void Awake()
    {
        if (player != null)
        {
            playerObject = player;
        }
        else
        { 
            playerObject = GameObject.FindWithTag("Player");
        }
    }
    
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnEnable()
    {
    }

    public void Fn_FacePlayer()
    {
        if (playerObject != null)
        {
            Vector3 direction = new Vector3(playerObject.transform.position.x - this.transform.position.x,
                                        0.0f,
                                        playerObject.transform.position.z - this.transform.position.z);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = targetRotation;
        }

    }


}

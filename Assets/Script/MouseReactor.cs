using UnityEngine;
using System.Collections;

public class MouseReactor : MonoBehaviour {

    [SerializeField]
    private bool isFacePlayer = true;
    [SerializeField]
    private GameObject player;
    private GameObject playerObject;

    [SerializeField]
    private bool isEnableObject = true;
    [SerializeField]
    private GameObject enableObject;

    [SerializeField]
    private bool isChangeColor = true;

    [SerializeField]
    private Color colorMouseEnter = Color.red;
    [SerializeField]
    private Color colorMouseDown = Color.green;

    private Color defaultColor;
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
        if (enableObject != null)
        {
            enableObject.active = false;
        }

        defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }
      

    void OnMouseEnter()
    {
        if (isEnableObject == true)
        {
            enableObject.active = true;
        }
        
        if (isChangeColor == true)
        {
            gameObject.GetComponent<Renderer>().material.color = colorMouseEnter;
        }

    }

    void OnMouseExit()
    {
        if (isEnableObject == true)
        {
            enableObject.active = false;
        }
        if (isChangeColor == true)
        {
            if (defaultColor != null)
            {
                gameObject.GetComponent<Renderer>().material.color = defaultColor;
            }
            
        }

    }

    void OnMouseDown()
    {
        if (isFacePlayer == true)
        {
            Fn_FacePlayer();
        }
        if (isChangeColor == true)
        {
            gameObject.GetComponent<Renderer>().material.color = colorMouseDown;
        }
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

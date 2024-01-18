using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickanim : MonoBehaviour
{

    GameObject stickattackleft;
    
    // Start is called before the first frame update
    void Start()
    {
        stickattackleft = GetComponent<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyUp(KeyCode.Space ))
        {
            stickattackleft.SetActive(true);

        } else
        {
            stickattackleft.SetActive(false);
        }
    }
}

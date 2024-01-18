using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickanim : MonoBehaviour
{

    GameObject stickattack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) )
        {
            stickattack.SetActive(true);

        } else
        {
            stickattack.SetActive(false);
        }
    }
}

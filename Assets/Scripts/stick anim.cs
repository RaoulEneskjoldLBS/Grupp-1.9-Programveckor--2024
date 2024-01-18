using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickanim : MonoBehaviour
{

    GameObject stickattack;
    
    // Start is called before the first frame update
    void Start()
    {
        stickattack = GetComponent<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyUp(KeyCode.Space ))
        {
            stickattack.SetActive(true);

        } else
        {
            stickattack.SetActive(false);
        }
    }
}

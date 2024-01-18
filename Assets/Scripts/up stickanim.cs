using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upstickanim : MonoBehaviour
{
    GameObject stickattackup;

    // Start is called before the first frame update
    void Start()
    {
        stickattackup = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyUp(KeyCode.Space))
        {
            stickattackup.SetActive(true);

        }
        else
        {
            stickattackup.SetActive(false);
        }
    }
}

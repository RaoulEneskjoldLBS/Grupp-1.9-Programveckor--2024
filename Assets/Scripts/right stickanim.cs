using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightstickanim : MonoBehaviour
{
    GameObject stickattackright;

    // Start is called before the first frame update
    void Start()
    {
        stickattackright = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyUp(KeyCode.Space))
        {
            stickattackright.SetActive(true);

        }
        else
        {
            stickattackright.SetActive(false);
        }
    }
}

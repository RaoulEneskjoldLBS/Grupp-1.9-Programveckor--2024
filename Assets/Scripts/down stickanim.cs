using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downstickanim : MonoBehaviour
{
    GameObject stickattackdown;

    // Start is called before the first frame update
    void Start()
    {
        stickattackdown = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyUp(KeyCode.Space))
        {
            stickattackdown.SetActive(true);

        }
        else
        {
            stickattackdown.SetActive(false);
        }
    }
}

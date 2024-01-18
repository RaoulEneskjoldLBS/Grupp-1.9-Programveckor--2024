using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickanim : MonoBehaviour
{





    public string sticklefttag = "stick left";
    GameObject stickattackleft = GameObject.FindGameObjectsWithTag(sticklefttag);
    GameObject stickattackup = GameObject.Find("stickattackup");
    GameObject stickattackdown = GameObject.Find("stickattackdown");
    GameObject stickattackright = GameObject.Find("stickattackright");

 

    // Start is called before the first frame update
    void Start()
    {
        stickattackleft = GetComponent<GameObject>();
        stickattackup = GetComponent<GameObject>();
        stickattackdown = GetComponent<GameObject>();
        stickattackright = GetComponent<GameObject>();
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

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyUp(KeyCode.Space))
        {
            stickattackup.SetActive(true);

        }
        else
        {
            stickattackup.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyUp(KeyCode.Space))
        {
            stickattackdown.SetActive(true);

        }
        else
        {
            stickattackdown.SetActive(false);
        }

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

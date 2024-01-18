using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickanim : MonoBehaviour
{





    public string stickattackleftTag = "stickattackleft";
    GameObject stickattackleft;
    GameObject stickattackup;
    GameObject stickattackdown;
    GameObject stickattackright;
   

 

    // Start is called before the first frame update
    public void Start()
    {
        GameObject stickattackleft = GameObject.FindGameObjectWithTag(stickattackleftTag);
        GameObject stickattackup = GameObject.Find("stickattackup");
        GameObject stickattackdown = GameObject.Find("stickattackdown");
        GameObject stickattackright = GameObject.Find("stickattackright");
    }

    // Update is called once per frame
    public void Update()

    {

        

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.Space ))
        {
            stickattackleft.SetActive(true);
            Debug.Log("left swing");

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

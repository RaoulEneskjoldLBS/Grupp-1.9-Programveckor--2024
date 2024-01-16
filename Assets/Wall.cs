using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public int requiredPickups = 3; 
    public int pickupsCollected = 0;

   
    private void Update()
    {
        if (pickupsCollected >= requiredPickups)
        {
            Destroy(gameObject);
        }
    }


}


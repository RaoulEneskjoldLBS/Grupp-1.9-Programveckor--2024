using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(Animator animator)
    {



        float horizontalmove = Input.GetAxisRaw("horizontal"); //* moveSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalmove));
        
    }
}

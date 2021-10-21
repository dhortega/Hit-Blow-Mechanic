using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonScript : MonoBehaviour
{
    //public Animator dragonAnim;
    //bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        //dragonAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //isWalking = true;
            //dragonAnim.SetBool("isWalking", true);
        }
        else if (Input.GetMouseButton(0))
        {
            //dragonAnim.SetBool("isFlying", true);
        }
        else
        {
            //dragonAnim.SetBool("isWalking", false);
            //dragonAnim.SetBool("isFlying", false);

        }
    }
}

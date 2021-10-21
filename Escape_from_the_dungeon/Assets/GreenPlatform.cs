using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    // Physics variables
    public float rotationSpeed;
    
    // State variables
    public bool bulletHit;
    public bool isFrozen;

    // Time variables
    public float freezeTime;
    public float unfreezeTime;

    // Start is called before the first frame update
    void Start()
    {
        isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("bulletHit: " + bulletHit);

        if (!bulletHit)
        {
            //Debug.Log("Entereing rotate here!");
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        }
        else if (bulletHit)
        {
            //if (!isFrozen)
            //{
            //Debug.Log("BUllet Hit" + bulletHit);
            //Stop rotation
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("freezeGameObject", freezeTime); // Initially 0f to instantly freeze the platform
            // Cannot use invoke if the function being called has parameters
            //    freezeGameObject();

            //return 0;
            //}
            //else
            //{
            //    unfreezeGameObject(); 
            Invoke("unfreezeGameObject", unfreezeTime); // Initially 5f to give players more time to jump off

            //}
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Bullet") // Refactor this code. This currently doesn't work
    //    {

    //        Debug.Log("Bullet Collision Detected!");

    //        Invoke("freezeGameObject", 0f); // Cannot use invoke if the function being called has parameters

    //        Invoke("unfreezeGameObject", 3f);
    //    }
    //}

    public void freezeGameObject()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //bulletHit = false;
        //bulletHit = true;
        //isFrozen = true;
    }

    public void unfreezeGameObject()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        //isFrozen = false;
        //transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        bulletHit = false;
    }
}

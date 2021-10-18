using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroy_timer = 1.0f;
    void Start()
    {
        // Destroys game object based on timer. Currently disabled.
        //Destroy(this.gameObject, destroy_timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy this game object when colliding with objects tagged as "Ground"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Rock")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag== "GreenPlatform")
        {
            Destroy(this.gameObject);
            collision.collider.GetComponent<GreenPlatform>().bulletHit = true;
        }
    }
}

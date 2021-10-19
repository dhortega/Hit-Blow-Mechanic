using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisappearReappear : MonoBehaviour
{
    // Outside script
    PlatformManager platManager;
    //public Renderer platRenderer;
    //public Rigidbody2D platRigidbody2D;
    //public Collider2D platCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        platManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
        //platRenderer = GetComponent<Renderer>();
        //platRigidbody2D = GetComponent<Rigidbody2D>();
        //platCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If this game object collides with the game object tagged Player
        if (collision.collider.tag == "Player")
        {
            Debug.Log(message: $"<color=blue><size=16>Entered blue platform collision</size></color>");
            // Delays the disappearing of the gameObject being collided with
            //StartCoroutine(platManager.delay(platManager.platformsArray, this.gameObject));
            platManager.delay(platManager.platformsArray, this.gameObject);
            //gameObject.SetActive(true);
        }
    }

    
}

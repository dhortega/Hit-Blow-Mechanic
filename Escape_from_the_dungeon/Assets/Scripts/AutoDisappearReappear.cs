using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisappearReappear : MonoBehaviour
{
    // Outside script
    PlatformManager platManager;
    GameObject rockSpawner;
    //public Renderer platRenderer;
    //public Rigidbody2D platRigidbody2D;
    //public Collider2D platCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        platManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
        rockSpawner = GameObject.Find("RockSpawner");
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
        if (collision.collider.tag == "Player" && gameObject.tag == "Ground")
        {
            Debug.Log(message: $"<color=blue><size=16>Entered blue platform collision</size></color>");
            // Delays the disappearing of the gameObject being collided with
            //StartCoroutine(platManager.delay(platManager.platformsArray, this.gameObject));
            platManager.delay(platManager.platformsArray, this.gameObject);
            //gameObject.SetActive(true);
        }
        else if (collision.collider.tag == "Bullet") // Refactor this code. This currently doesn't work
        {
            Invoke("deactivateGameObject", 2f); // Cannot use invoke if the function being called has parameters
                                               
            Invoke("reactivateGameObject", 5f);
        }
    }

    public void deactivateGameObject()
    {
        rockSpawner.SetActive(false); // Disables the searched game object
    }

    public void reactivateGameObject()
    {
        rockSpawner.SetActive(true);
    }
    //yield return new WaitForSeconds(0);
}

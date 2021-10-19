using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    //Sound
    AudioSource audioSource;
    public AudioClip rockClip;

    // Reference to RockSpawner that has sound
    //public GameObject localRockSpawner;
    //RockSpawner rockSpawnerSoundComp;
    

    // Start is called before the first frame update
    public float destroy_timer = 1.0f;
    void Start()
    {
        //Destroys game object based on timer. Currently disabled.
        //Destroy(this.gameObject, destroy_timer);
        //rockSpawnerSoundComp = localRockSpawner.GetComponent<RockSpawner>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy this game object when varying combinations of game objects collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy this game object when game object collides with Ground or Rock and attached game object is Bullet
        if ((collision.collider.tag == "Ground" || collision.collider.tag == "Rock") && gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        else // Destroy this game object when game object collides with Ground or Rock and attached game object is Bullet
        if ((collision.collider.tag == "Ground" || collision.collider.tag == "Rock") && gameObject.tag == "Rock")
        {
            // Attempt to play stone breaking
            //localRockSpawner.GetComponent<AudioSource>().PlayOneShot(localRockSpawner.GetComponent<RockSpawner>().rockBreakClip);
            //audioSource.PlayOneShot(rockClip);
            //Debug.Log("called PlayOneShot");
            //playSound(rockSpawnerSoundComp, rockSpawnerSoundComp.rockBreakClip);
            AudioSource.PlayClipAtPoint(rockClip, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            Destroy(this.gameObject);
        }
        // Destroy this game object when game object collides with any of the Target objects and attached game object is Bullet
        else if ((collision.collider.tag == "White" || collision.collider.tag == "Blue" 
            || collision.collider.tag == "Orange" || collision.collider.tag == "Red") && gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag == "GreenPlatform")
        {
            Destroy(this.gameObject);
            collision.collider.GetComponent<GreenPlatform>().bulletHit = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{

    // Outside scripts
    ScoreManager scoreManager;

    GameObject player;
    PlayerControl playerControlscript;
    AudioSource audSource;

    //public ParticleSystem particleWhite;
    //public ParticleSystem particleBlue;
    //public ParticleSystem particleYellow;
    //public ParticleSystem particleRed;


    // State variables
    //public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        player = GameObject.Find("AstroStay");
        playerControlscript = player.GetComponent<PlayerControl>();
        audSource = player.GetComponent<AudioSource>();
    }

    // FixedUpdate executes 50 times per second.
    void FixedUpdate()
    {
        
    }

    void giveScore(int score)
    {
        scoreManager.SetScore(scoreManager.GetScore() + score);
    }

    void disableTarget()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        //Destroy(gameObject.transform.parent.gameObject);
    }

    // Checks if bullet game object hits the respective game object with its tag
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Bullet" && gameObject.tag == "White")
        {
            giveScore(10);
            audSource.PlayOneShot(playerControlscript.l1);
            disableTarget();
        } 
        else if (collision.collider.tag == "Bullet" && gameObject.tag == "Blue")
        {
            giveScore(20);
            audSource.PlayOneShot(playerControlscript.l2);
            disableTarget();
        }
        else if (collision.collider.tag == "Bullet" && gameObject.tag == "Orange")
        {
            giveScore(30);
            audSource.PlayOneShot(playerControlscript.l3);
            disableTarget();
        } 
        else if ((collision.collider.tag == "Bullet" && gameObject.tag == "Red"))
        {
            giveScore(50);
            audSource.PlayOneShot(playerControlscript.l4);
            disableTarget();
        }
    }
}

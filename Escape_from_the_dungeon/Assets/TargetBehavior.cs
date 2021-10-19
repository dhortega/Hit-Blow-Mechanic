using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{

    // Outside scripts
    ScoreManager scoreManager;

    // State variables
    //public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); 
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
    }

    // Checks if bullet game object hits the respective game object with its tag
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Bullet" && gameObject.tag == "White")
        {
            giveScore(10);
            disableTarget();
        } 
        else if (collision.collider.tag == "Bullet" && gameObject.tag == "Blue")
        {
            giveScore(20);
            disableTarget();
        }
        else if (collision.collider.tag == "Bullet" && gameObject.tag == "Orange")
        {
            giveScore(30);
            disableTarget();
        } 
        else if ((collision.collider.tag == "Bullet" && gameObject.tag == "Red"))
        {
            giveScore(50);
            disableTarget();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisappearReappear : MonoBehaviour
{
    // Outside script
    PlatformManager platManager;

    // Start is called before the first frame update
    void Start()
    {
        platManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
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
            StartCoroutine(platManager.delay());
            //gameObject.SetActive(true);
        }
    }

    
}

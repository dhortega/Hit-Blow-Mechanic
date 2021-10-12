using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player.GameObject.Find("Player");
        Transform playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d"))
        {
            // playerTransform.Translate(10, 0, 0); // .x += 10;
            // player.Translate(10,0,0);
            player.transform.position = player.transform.position + new Vector3(10, 0, 0);
            
        }
    }
}

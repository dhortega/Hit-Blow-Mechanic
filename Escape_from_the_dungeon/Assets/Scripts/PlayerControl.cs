using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // GameObjects
    private GameObject player;
    private GameObject gun;
    private GameObject jetpack;

    // Characteristics
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        // player.GameObject.Find("Player");
        //Transform playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("d"))
        {
            // playerTransform.Translate(10, 0, 0); // .x += 10;
            // player.Translate(10,0,0);
            // player.transform.position = player.transform.position + new Vector3(3, 0, 0);
            //transform.Translate(speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved right.");
        } 
        else if (Input.GetKey("a"))
        {
            // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);
            //transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved left.");
        } 
        else  if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");

        } 
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("Pressed right click.");
        }
    }
}

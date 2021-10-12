using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // GameObjects
    private GameObject player;
    private GameObject gun;
    public GameObject jetpack;
    private Rigidbody2D jetpackRigidBody;
    private Rigidbody2D playerRigidBody;

    // Characteristics
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        jetpackRigidBody = jetpack.GetComponent<Rigidbody2D>();
        playerRigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // DEBUG:
        //Debug.Log(message:$"<color=green><size=16> mousePosition.x: {Input.mousePosition.x} </size> </color>");
        //Debug.Log(message:$"<color=green><size=16> mousePosition.y: {Input.mousePosition.y} </size> </color>");

        if(Input.GetKey("d"))
        {
            // Transforming position
            //player.transform.position = player.transform.position + new Vector3(3, 0, 0);
            
            // Translate speed of the object attached to
            transform.Translate(speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved right.");
        } 
        else if (Input.GetKey("a"))
        {
            // Transforming position
            // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);

            // Translate speed of the object attached to
            transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved left.");
        } 
        else  if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed left click.");

        } 
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("Pressed right click.");
            
            // Jetpack RidigBody
            //jetpackRigidBody.AddForce(new Vector3(-5, 0, 0), ForceMode2D.Force); //Input.mousePosition.x, Input.mousePosition.y, ForceMode2D.Acceleration
            
            // Player RigidBody
            playerRigidBody.AddForce(new Vector3(0, (Input.mousePosition.y % 2) + 1, 0), ForceMode2D.Force);
        }
    }
}

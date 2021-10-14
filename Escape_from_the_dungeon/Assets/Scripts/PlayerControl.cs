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
    public int flyspeed;
    public double airbar;
    public double airspeed;
    public GameObject bulletprefab;
    public GameObject bullethole;
    public float bulletspeed;
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
        Vector3 pos = bullethole.transform.position;
        
        if(Input.GetKey("d"))
        {
            // Transforming position
            //player.transform.position = player.transform.position + new Vector3(3, 0, 0);
            
            // Translate speed of the object attached to
            transform.Translate(speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved right.");
            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 50);
        } 
        else if (Input.GetKey("a"))
        {
            // Transforming position
            // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);

            // Translate speed of the object attached to
            transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved left.");
            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 50);
        } 
        else  if (Input.GetMouseButton(0))
        {
            if (airbar>0)
            {
                Debug.Log("Pressed left click.");
                transform.Translate(0f, flyspeed * Time.deltaTime, 0f);
                airbar -= Time.deltaTime * airspeed;
                Debug.Log("waterbar");
            }
            else
            {
                Debug.Log("There is no air in the airbag");
            }

        }
       
        else if (Input.GetMouseButtonDown(1))
        {

            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 50);
            Debug.Log("Pressed right click.");
            
            // Jetpack RidigBody
            //jetpackRigidBody.AddForce(new Vector3(-5, 0, 0), ForceMode2D.Force); //Input.mousePosition.x, Input.mousePosition.y, ForceMode2D.Acceleration
            
            // Player RigidBody
            playerRigidBody.AddForce(new Vector3(0, (Input.mousePosition.y % 2) + 1, 0), ForceMode2D.Force);

           GameObject bullet=GameObject.Instantiate(bulletprefab, pos, Quaternion.identity)as GameObject;
            Debug.Log(pos);
            Debug.Log(bullethole.transform.position);
            bullet.transform.Translate((jetpack.transform.position-bullethole.transform.position)*bulletspeed);
        }
        if (airbar < 100)
            airbar += Time.deltaTime * (airspeed - 50);

    }
}

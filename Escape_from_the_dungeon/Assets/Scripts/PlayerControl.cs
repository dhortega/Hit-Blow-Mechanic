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
    public double waterbar;
    public double waterspeed;
    public GameObject bulletprefab;
    public GameObject bullethole;
    public float bulletspeed;

    Vector3 myScreenPos;



    Vector2 target;
    Vector2 myPos;


    // Start is called before the first frame update
    void Start()
    {
        jetpackRigidBody = jetpack.GetComponent<Rigidbody2D>();
        playerRigidBody = this.GetComponent<Rigidbody2D>();

        myScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
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
            //transform.Translate(speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved right.");
            //if (waterbar < 200)
            // waterbar += Time.deltaTime * (waterspeed - 50);


            playerRigidBody.AddForce(Vector2.right * speed);

            print("Right" + Vector2.right);
        } 
        else if (Input.GetKey("a"))
        {
            // Transforming position
            // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);

            // Translate speed of the object attached to
            //transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            Debug.Log("Moved left.");
            //if (waterbar < 200)
            //waterbar += Time.deltaTime * (waterspeed - 50);

            playerRigidBody.AddForce(Vector2.left * speed);
        } 
        if (Input.GetMouseButton(0))
        {
            if (waterbar>0)
            {
                Debug.Log("Pressed left click.");
                //transform.Translate(0f, flyspeed * Time.deltaTime, 0f);
                playerRigidBody.AddForce(Vector2.up * flyspeed * Time.deltaTime);
                waterbar -= Time.deltaTime * waterspeed;
                Debug.Log("waterbar");
            }
            else
            {
                Debug.Log("There is no water in the waterbag");
            }

        }
       
        //else if (Input.GetMouseButtonDown(1))
        //{

        //    if (waterbar < 200)
        //        waterbar += Time.deltaTime * (waterspeed - 50);
        //    Debug.Log("Pressed right click.");
            
        //    // Jetpack RidigBody
        //    //jetpackRigidBody.AddForce(new Vector3(-5, 0, 0), ForceMode2D.Force); //Input.mousePosition.x, Input.mousePosition.y, ForceMode2D.Acceleration
            
        //    // Player RigidBody
        //    playerRigidBody.AddForce(new Vector3(0, (Input.mousePosition.y % 2) + 1, 0), ForceMode2D.Force);

        //   //GameObject bullet=GameObject.Instantiate(bulletprefab, pos, Quaternion.identity)as GameObject;
        //    //Debug.Log(pos);
        //    //Debug.Log(bullethole.transform.position);
        //    //bullet.transform.Translate((jetpack.transform.position-bullethole.transform.position)*bulletspeed);
        //}
        //if (waterbar < 200)
        // waterbar += Time.deltaTime * (waterspeed - 50);



        //else if (Input.GetMouseButtonDown(1))
        //{
        //    print("Are we shooting bullets?");
        //    GameObject bulletShoot = (GameObject)Instantiate(bulletprefab, transform.position, Quaternion.identity);
        //    Vector3 direction = (Input.mousePosition - myScreenPos).normalized;
        //    bulletShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * bulletspeed;
        //}




        else if(Input.GetMouseButtonDown(1))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bulletprefab, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (waterbar < 200)
                waterbar += Time.deltaTime * waterspeed;

            Debug.Log("Collision on");
        }
    }
}

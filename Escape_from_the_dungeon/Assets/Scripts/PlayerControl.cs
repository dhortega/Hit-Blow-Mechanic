using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;
=======
using UnityEngine.SceneManagement;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
    public float resettime = 1.0f;
    Vector3 myScreenPos;

    Vector2 target;
    Vector2 myPos;

    public Transform playerPosition;
    public Transform launchPoint;

    public Animator astronautAnim;


    public bool isFacingRight = true;

    // Sounds
    AudioSource audioSource;

    public AudioClip bulletClip;
    public AudioClip airClip;

>>>>>>> Stashed changes

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
            //Debug.Log("Moved right.");
            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 10);
        } 
        else if (Input.GetKey("a"))
        {
            // Transforming position
            // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);

            // Translate speed of the object attached to
            transform.Translate(-speed*Time.deltaTime, 0f, 0f);
            //Debug.Log("Moved left.");
            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 10);
        } 
        else  if (Input.GetMouseButton(0))
        {
            if (airbar>0)
            {
                
                transform.Translate(0f, flyspeed * Time.deltaTime, 0f);
                airbar -= Time.deltaTime * airspeed;
                
            }
            else
            {
                Debug.Log("There is no air in the airbag");
            }

        }
       
        else if (Input.GetMouseButtonDown(1))
        {

            if (airbar < 100)
                airbar += Time.deltaTime * (airspeed - 10);
            //Debug.Log("Pressed right click.");
            
            // Jetpack RidigBody
            //jetpackRigidBody.AddForce(new Vector3(-5, 0, 0), ForceMode2D.Force); //Input.mousePosition.x, Input.mousePosition.y, ForceMode2D.Acceleration
            
            // Player RigidBody
            playerRigidBody.AddForce(new Vector3(0, (Input.mousePosition.y % 2) + 1, 0), ForceMode2D.Force);

           GameObject bullet=GameObject.Instantiate(bulletprefab, pos, Quaternion.identity)as GameObject;
            //Debug.Log(pos);
            //Debug.Log(bullethole.transform.position);
            bullet.transform.Translate((jetpack.transform.position-bullethole.transform.position)*bulletspeed);
        }
        if (airbar < 100)
            airbar += Time.deltaTime * (airspeed - 10);

    }

    //void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.collider.tag.CompareTo("Posion") == 0)
    //    {
    //        Debug.Log(collision.gameObject.name);
    //        Destroy(this.gameObject);
    //    }

    //}
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag.CompareTo("Posion") == 0)

        {

            GameObject.Find("Canvas").GetComponent<UIManager>().Changedeadmessage();
            Destroy(this.gameObject);


        }

        if(collider.tag.CompareTo("Escapedoor") == 0)

        {
            GameObject.Find("Canvas").GetComponent<UIManager>().Changewinmessage();
        }
    }
<<<<<<< Updated upstream

    

=======
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.CompareTo("Posion")==0)
        {
            
            GameObject.Find("UICanvas").GetComponent<UIManager>().Changedeadmessage();
            //Destroy(this.gameObject);
            this.gameObject.GetComponent<Renderer>().enabled=false;
            //System.Threading.Thread.Sleep(2000);
            Invoke("Reset", resettime);
        }
        if (collision.tag.CompareTo("Escapedoor") == 0)
        {
            GameObject.Find("UICanvas").GetComponent<UIManager>().Changewinmessage();
            
        }
    }
     void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
>>>>>>> Stashed changes
}


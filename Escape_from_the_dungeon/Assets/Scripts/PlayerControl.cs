using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{

    // GameObjects
    private GameObject player;
    public GameObject gun;
    public GameObject jetpack;
    private Rigidbody2D jetpackRigidBody;
    private Rigidbody2D playerRigidBody;

    // Characteristics
    public int speed;
    public int flyspeed;
    public double waterbar;
    public double waterspeed;
    public PlayerShoot gunPlayerShoot;
    public GameObject bulletprefab;
    public GameObject bullethole;
    public float bulletspeed;
    public float resetspeed;
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

    public AudioClip l1;
    public AudioClip l2;
    public AudioClip l3;
    public AudioClip l4;

    public ParticleSystem particleSys;
    public ParticleSystem particleSys2;

    // Start is called before the first frame update
    void Start()
    {
        jetpackRigidBody = jetpack.GetComponent<Rigidbody2D>();
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        gunPlayerShoot = gun.GetComponent<PlayerShoot>();
        //gunPlayerShoot = FindObjectOfType<PlayerShoot>();
        myScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        astronautAnim = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (delta.x >= 0 && !isFacingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            isFacingRight = true;
        }
        else if (delta.x < 0 && isFacingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
            isFacingRight = false;
        }



        // DEBUG:
        //Debug.Log(message:$"<color=green><size=16> mousePosition.x: {Input.mousePosition.x} </size> </color>");
        //Debug.Log(message:$"<color=green><size=16> mousePosition.y: {Input.mousePosition.y} </size> </color>");
        Vector3 pos = bullethole.transform.position;
        
        //if(Input.GetKey("d"))
        //{
        //    // OLD Transforming position
        //    //player.transform.position = player.transform.position + new Vector3(3, 0, 0);
            
        //    // OLD Translate speed of the object attached to
        //    //transform.Translate(speed*Time.deltaTime, 0f, 0f);
        //    Debug.Log("Moved right.");
        //    //if (waterbar < 200)
        //    // waterbar += Time.deltaTime * (waterspeed - 50);

        //    // Move player by adding force and pushing to the right
        //    playerRigidBody.AddForce(Vector2.right * speed);

        //    print("Right" + Vector2.right);
        //} 
        //else if (Input.GetKey("a"))
        //{
        //    // OLD Transforming position
        //    // player.transform.position = player.transform.position + new Vector3(-3, 0, 0);

        //    // OLD Translate speed of the object attached to
        //    //transform.Translate(-speed*Time.deltaTime, 0f, 0f);
        //    Debug.Log("Moved left.");
        //    //if (waterbar < 200)
        //    //waterbar += Time.deltaTime * (waterspeed - 50);

        //    // Move player by adding force and pushing to the left
        //    playerRigidBody.AddForce(Vector2.left * speed);
        //} 
        if (Input.GetMouseButton(0))
        {
            if (waterbar>0)
            {
                //Debug.Log("Pressed left click.");
                //transform.Translate(0f, flyspeed * Time.deltaTime, 0f);

                // OLD Launch Direction
                //Vector2 launchDireciton = launchPoint.position - playerPosition.position;

                // Adding force based on two points: launch point and player position
                float transformX = launchPoint.position.x - playerPosition.position.x;
                float transformY = launchPoint.position.y - playerPosition.position.y;
                playerRigidBody.AddForce(new Vector2 (transformX,transformY) * flyspeed * Time.deltaTime); //Vector2.up* flyspeed *Time.deltaTime |jetpackBlow.LaunchDirection()

                astronautAnim.SetBool("isFlying", true);
                
                waterbar -= Time.deltaTime * waterspeed;
                //audioSource.clip = airClip;
                //Debug.Log("waterbar");
            }
            else
            {
                astronautAnim.SetBool("isFlying", false);
                //Debug.Log("There is no water in the waterbag");
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

        // Checking input on right mouse button
        else if(Input.GetMouseButtonDown(1))
        {
            audioSource.PlayOneShot(bulletClip);
            gunPlayerShoot.SpawnProjectile(bulletprefab, bulletspeed);
        }
        else
        astronautAnim.SetBool("isFlying", false);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" || collision.collider.tag == "Rock" || collision.collider.tag == "GreenPlatform")
        {
            if (waterbar < 100)
            {
                if(!particleSys.isPlaying)
                {
                    particleSys.Play();
                }
                waterbar += waterspeed;
                if(waterbar > 100)
                {
                    waterbar = 100;
                }
                
            }

            astronautAnim.SetBool("isFlying", false);

            //Debug.Log("Collision on");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "TargetParent")
        {
            if (waterbar < 100)
            {
                waterbar += 60;
                if (!particleSys.isPlaying)
                {
                    particleSys2.Play();
                }
                if (waterbar > 100)
                {
                    waterbar = 100;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.tag.CompareTo("Posion")==0)
        {
            GameObject.Find("UICanvas").GetComponent<UIManager>().Changedeadmessage();
            this.gameObject.GetComponent<Renderer>().enabled = false;
            Invoke("Reset",resetspeed);
        }
    if(collision.tag.CompareTo("Escapedoor") == 0)
        {
            GameObject.Find("UICanvas").GetComponent<UIManager>().Changewinmessage();
            Invoke("Reset", resetspeed);
        }
    }
    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

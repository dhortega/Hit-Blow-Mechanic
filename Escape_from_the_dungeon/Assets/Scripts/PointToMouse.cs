using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    public PlayerControl player;
    public float rotationSpeed;

    private Quaternion _lookRotation;
    private Vector2 _direction;

    private Vector2 playerPos;
    private float playerRot;

    private void Start()
    {
        player = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerPos= player.transform.position;
        //playerRot = player.transform.rotation.y;



        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = (Vector2) Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (player.isFacingRight)
        {
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
        else if(player.isFacingRight == false)
        {
            float angle = AngleBetweenTwoPointsReverse(positionOnScreen, mouseOnScreen);

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        //Debug.Log("Player pos" + playerPos.x);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    
    }
    float AngleBetweenTwoPointsReverse(Vector3 a, Vector3 b)
    {

        return Mathf.Atan2(a.y-b.y, a.x-b.x) * Mathf.Rad2Deg;

    }

    private void SwitchFace()
    {

    }

}

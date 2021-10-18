using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    public float rotationSpeed;
    public bool bulletHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!bulletHit)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        }
        else if (bulletHit)
        {
            Debug.Log("BUllet Hit" + bulletHit);
            //Stop rotation

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroy_timer = 1.0f;
    void Start()
    {
        Destroy(this.gameObject, destroy_timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

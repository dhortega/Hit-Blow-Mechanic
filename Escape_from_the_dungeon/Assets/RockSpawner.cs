using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockprefab;

    // Time variables
    private float InstantiationTimer = 2f;

    // Position variables
    private Vector2 myPos;

    // Start is called before the first frame update
    void Start()
    {
        myPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Vector2 rInt = new Vector2(Random.Range(-19, 19), 0);
            Instantiate(rockprefab, myPos + rInt, Quaternion.identity);
            InstantiationTimer = 2f;
        }   
    }
}

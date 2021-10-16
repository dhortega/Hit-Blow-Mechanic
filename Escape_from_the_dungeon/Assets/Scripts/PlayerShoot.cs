using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    // Spawns a bullet with a particular bullet at the transform where this script is attached
    public void SpawnProjectile(GameObject bulletprefab, float bulletspeed)
    {
        Debug.Log("Spawn Projectile");
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y); //+ 1
        Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(bulletprefab, myPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

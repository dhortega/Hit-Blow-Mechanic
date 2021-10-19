using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFreeze : MonoBehaviour
{
    // Sounds
    AudioSource audioSource;
    public AudioClip freezeClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.rigidbody.GetComponent("bulletMovement") != null)
        {
            audioSource.PlayOneShot(freezeClip);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}

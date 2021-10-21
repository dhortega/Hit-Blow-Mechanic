using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public Color[] randomColor;


    float red, green, blue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BGCoroutine");
        //randomColor1 = new 
    }

    // Update is called once per frame
    void Update()
    {
        //randomColor = new (red, green, blue);
        //this.GetComponent<SpriteRenderer>().color = randomColor;
    }

    IEnumerator BGCoroutine ()
    {
        while (true)
        {
            this.GetComponent<SpriteRenderer>().color = randomColor[0];
            yield return new WaitForSeconds(0.3f);
            this.GetComponent<SpriteRenderer>().color = randomColor[1];
            yield return new WaitForSeconds(0.3f);
            this.GetComponent<SpriteRenderer>().color = randomColor[2];
            yield return new WaitForSeconds(0.3f);
            this.GetComponent<SpriteRenderer>().color = randomColor[3];
            yield return new WaitForSeconds(0.3f);
            //this.GetComponent<SpriteRenderer>().color = randomColor[4];
            //yield return new WaitForSeconds(0.3f);

        }
        //yield return new WaitForSeconds(1f);
    }
}

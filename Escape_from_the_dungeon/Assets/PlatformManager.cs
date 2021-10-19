using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformsArray;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator delay()
    {
        Debug.Log(message: $"<color=blue><size=16>Entered Enumerator </size></color>");
        new WaitForSeconds(2);
        platformsArray.SetActive(false);
        new WaitForSeconds(5);
        platformsArray.SetActive(true);

        yield return new WaitForSeconds(0);
    }
}

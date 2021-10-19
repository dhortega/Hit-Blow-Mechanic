using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlatformManager : MonoBehaviour
{
    // Local variables
    public GameObject[] platformsArray;
    private GameObject platformTemporary;

    // Components
    //Attempt to disable all components to isable and reenable a GameObject
    //public Renderer platRenderer;
    //public Rigidbody2D platRigidbody2D;
    //public Collider2D platCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        platformTemporary = platformsArray[0];
        //Attempt to disable all components to isable and reenable a GameObject
        //platRenderer = GetComponent<Renderer>();
        //platRigidbody2D = GetComponent<Rigidbody2D>();
        //platCollider2D = GetComponent<Collider2D>();
    }

    public void delay(GameObject[] platformsArr, GameObject platformTemp)
    {
        //Debug.Log(message: $"<color=blue><size=16>Entered Enumerator </size></color>");
        //yield return new WaitForSeconds(2);

        //platformTemporary = platformsArr[indexOfSearchedGameObject]; // Retrieves the respective Game Object in the editor
        //platformTemporary = platformTemp;
        //Debug.Log(message: $"<color=blue><size=16>platformsArray[indexOfSearchedGameObject].name: {platformsArray[indexOfSearchedGameObject].name} </size></color>");

        int indexOfSearchedGameObject = ArrayUtility.IndexOf(platformsArr, platformTemp); // gets the index of a specific object in an array
        platformTemporary = platformsArr[indexOfSearchedGameObject]; // Stored a reference of the gameObject disabled and reenabled
        Invoke("deactivateGameObject", 2f); // Cannot use invoke if the function being called has parameters
        //platRenderer.enabled = false;
        //platRigidbody2D.enabled = false;
        //yield return new WaitForSeconds(5);
        //platformsArray.SetActive(true);
        //platformTemporary.SetActive(true);
        //platformTemp.SetActive(true);
        //platformsArray[indexOfSearchedGameObject].SetActive(true);
        //Debug.Log(message: $"<color=blue><size=16> At the end of delay </size></color>");
        Invoke("reactivateGameObject", 5f);
        //yield return new WaitForSeconds(0);
    }

    public void deactivateGameObject()
    {
        platformTemporary.SetActive(false); // Disables the searched game object
    }

    //public void deactivateGameObject(GameObject[] pArr, GameObject gObj)
    //{
    //    int indexOfSearchedGameObject = ArrayUtility.IndexOf(pArr, gObj); // gets the index of a specific object in an array
    //    pArr[indexOfSearchedGameObject].SetActive(false); // Disables the searched game object
    //}

    //public void reactivateGameObject(GameObject gObj)
    //{
    //    gObj.SetActive(true);
    //}

    public void reactivateGameObject()
    {
        platformTemporary.SetActive(true);
    }
}

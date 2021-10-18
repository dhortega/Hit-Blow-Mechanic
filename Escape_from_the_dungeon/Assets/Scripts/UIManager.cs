using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dead_message;
    public Text win_message;
    public Transform maincanvas;
    void Start()
    {
        win_message = maincanvas.transform.Find("Win").GetComponent<Text>();
        dead_message = maincanvas.transform.Find("Dead").GetComponent<Text>();
        win_message.enabled = false;
        dead_message.enabled = false;
    }

    // Update is called once per frame
    public void Changewinmessage()
    {
        win_message.enabled = !win_message.enabled;
    }
    public void Changedeadmessage()
    {
        dead_message.enabled = !dead_message.enabled;
    }
}

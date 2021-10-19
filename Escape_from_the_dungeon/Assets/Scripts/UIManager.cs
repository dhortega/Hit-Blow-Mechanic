using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dead_message;
    public Text win_message;
    public Transform maincanvas;
    public Text score;
    public Text Timebar;
    public int timelimit=180;
    void Start()
    {
        win_message = maincanvas.transform.Find("Win").GetComponent<Text>();
        dead_message = maincanvas.transform.Find("Dead").GetComponent<Text>();
        score = maincanvas.transform.Find("Score").GetComponent<Text>();
        win_message.enabled = false;
        dead_message.enabled = false;
        score.text = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().GetScore().ToString();
        StartCoroutine(Time());
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
     void Update()
    {
        score.text = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().GetScore().ToString();
        if(timelimit<=0)
        {
            Changedeadmessage();
            Invoke("Reloadscen",1f);
        }    
    }
    IEnumerator Time()
    {
        while (timelimit >= 0)
        {
            Timebar.GetComponent<Text>().text = timelimit.ToString();
            yield return new WaitForSeconds(1);
            timelimit--;
        }
    }
    void Reloadscen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

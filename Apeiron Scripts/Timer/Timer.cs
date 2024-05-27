using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    // private float elapsed;
    public GameObject transitionPanel;
    public TextMeshProUGUI timerContent;
    public bool gameEnded;

    private void Awake(){
        timer = 15f;
        gameEnded = false;
        // DontDestroyOnLoad(this.GameObject);
    }

    private void Update()
    {
        if(!gameEnded){
            // elapsed = Time.realtimeSinceStartup;
            timer -= Time.deltaTime;
            timerContent.text = "" + timer.ToString("f2");
            
            if(timer < 0){
                if(!transitionPanel.activeSelf){
                    transitionPanel.SetActive(true);
                    timer = 1;
                } else if(transitionPanel.activeSelf){
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}

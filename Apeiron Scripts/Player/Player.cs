using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> player;
    private Animator animator;
    private int index;
    public GameObject timer;
    private Timer boolTimer;
    public GameObject endingScreen;

    private void InitialPlayerSpawning(){
        GameObject notAuto = Instantiate(player[index], new Vector3(0, 0, 0), Quaternion.identity);
        notAuto.gameObject.tag = "Player";
        notAuto.transform.parent = this.transform;
    }

    private void Awake(){
        index = 0;
        boolTimer = timer.GetComponent<Timer>();
        InitialPlayerSpawning();
    }

    private void Update(){
        IsEmpty();
    }
    
    private void IsEmpty(){
        if(GetComponentInChildren<Animator>() == null){
            if(index == 12){
                boolTimer.gameEnded = true;
                endingScreen.SetActive(true);
            } else {
                index ++;
                GameObject notAuto = Instantiate(player[index], new Vector3(0, 0, 0), Quaternion.identity);
                notAuto.gameObject.tag = "Player";
                notAuto.transform.parent = this.transform;
            }
        }
    }
}

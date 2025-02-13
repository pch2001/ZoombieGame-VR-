using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject play;
    PlayerCtrl player;
    public Text state;
    public GameObject t;

    public Text lastmoney;
    bool charge = false;

    public GameObject da;
    public data datas;


    void Start()
    {
        play = GameObject.Find("Player");
        player = play.GetComponent<PlayerCtrl>(); 

    }

    // Update is called once per frame
    void Update()
    {
        lastmoney.text = "MONEY : " + player.money;
    }

    public void PlusHP(){
        StartCoroutine(Say());
        if(charge){
            data.Plus_HP +=1;

        }
    }
    public void Delayminus(){
        StartCoroutine(Say());
        if(charge){
            data.Minus_delay-=0.05f;
        }
    }
    public void DemagePlus(){
        StartCoroutine(Say());
        if(charge){   
            data.Plus_Demage+=0.5f;
        }
    }
    public void exit(){
        data.stageNumber= 3;
        SceneManager.LoadScene(1);
    }

    IEnumerator Say(){
        t.SetActive(true);
        if(player.money>=100){
            state.text = "구매 완료되었습니다.";
            player.money -=100;
            charge = true;
        }else{
            state.text = "돈이 부족합니다.";  
            charge = false;  
        }
        yield return new WaitForSeconds(1.0f);
        t.SetActive(false);
    }


}

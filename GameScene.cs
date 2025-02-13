using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScene : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[5];

    public GameObject zombie;

    private float spawnTime;

    public float stageTime;
    public Text Timer;
    public Text command;

    public GameObject button;
    public GameObject button2;
    public GameObject goStore;
    public GameObject finish;
    public GameObject tullet;
    GameObject play;
    PlayerCtrl player;

    bool spawTiming = true;

    public Text lasttext;
    bool first_TREE = true;
    bool st2=true;
    float bestScore;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 3.0f;
        play = GameObject.Find("Player");
        player = play.GetComponent<PlayerCtrl>();
        //data.stageNumber = 1;
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (data.stageNumber){   
            case 1:
                //Debug.Log("스테이지 1");
                lastTime();
                StageOne();
                break;

            case 2:
                // 스테이지 2에 해당하는 동작
                //Debug.Log("스테이지 2");
                if(st2)
                    StartCoroutine(StageTwo());
                break;

            case 3:
                // 스테이지 3에 해당하는 동작
                //Debug.Log("스테이지 3");
                lastTime();
                StartCoroutine(StageTREE());
                break;
            case 4:
                //Debug.Log("스테이지 4");
                StartCoroutine(StageFour());
                break;
            case 5:
                //Debug.Log("마지막 스테이지");
                player.mode= true;
                command.text = "Game Clear!!";
                if (data.Time_data > bestScore)
                {
                    PlayerPrefs.SetFloat("BestScore", data.Time_data);
                }

                lasttext.text = "최고기록 : " + bestScore + "\n 현재 기록 : "+data.Time_data;
                break;
            default:
                //Debug.Log("알 수 없는 스테이지입니다.");
                break;
            }   

    }

    public void StageOne(){
        player.mode = true;
        if(stageTime<60&&spawTiming){
            StartCoroutine(Spawn());
        }else if(stageTime>60){
            data.stageNumber = 2;
        }
    }

    IEnumerator StageTwo(){
        st2 = false;
        Timer.text = "";
        command.text ="남은 적들을 처치한 뒤 이동 버튼을 누르세요!";
        button.SetActive(true);
        lasttext.text = "모닥불 앞으로가면 상점으로 이동됩니다.";
        yield return new WaitForSeconds(2f);
        lasttext.text = "";
    }

    IEnumerator StageTREE(){
        if(first_TREE){
            player.transform.position = new Vector3(1.5f, 8f, 58f); 
            first_TREE=false;
            Debug.Log("실행");
            goStore.SetActive(false);
            lasttext.text = "팀원이 터렛을 발견하였습니다.";
            yield return new WaitForSeconds(1.5f);

            lasttext.text = "팀원이 터렛을 가져 올때까지.";
            yield return new WaitForSeconds(1.5f);

            lasttext.text = "좀비들의 공격을 막으세요!!";
            yield return new WaitForSeconds(1.5f);
            lasttext.text = "";       
        }
        player.mode = true;
        if(stageTime<60&&spawTiming){
            StartCoroutine(Spawn2());
        }else if(stageTime>60){
            data.stageNumber = 4;
            first_TREE=true;
        }
    }

    IEnumerator StageFour(){
        if(first_TREE){
            tullet.SetActive(true);
            button2.SetActive(true);
            first_TREE = false;
            command.text = "Move로 움직이세요";
            lasttext.text = "터렛을 가져왔습니다.";
            yield return new WaitForSeconds(1.5f);
            lasttext.text = "적을 모두 처리한 뒤 ";
            yield return new WaitForSeconds(1.5f);
            lasttext.text = "처음 있던 곳으로 돌아가세요!";
            yield return new WaitForSeconds(1.5f);
            lasttext.text = "";  
            Timer.text= "";
            finish.SetActive(true);     
        }
        

    }


    public void StageStore(){
        player.mode = true;
        
    }
    public void MoveMode(){
        player.mode = !player.mode;
        button.SetActive(false);
    }


    public void lastTime(){
        stageTime += Time.deltaTime;
        Timer.text = "시간 :" + (65-stageTime).ToString("F1");
    }



    IEnumerator Spawn(){
        spawTiming = false;
        int point = Random.Range(0,3);
        Instantiate(zombie, spawnPoint[point].position, spawnPoint[point].rotation);
        yield return new WaitForSeconds(spawnTime);
        spawTiming = true;
        spawnTime -= 0.01f;

    }
    IEnumerator Spawn2(){
        spawTiming = false;
        int point = Random.Range(0,5);
        Instantiate(zombie, spawnPoint[point].position, spawnPoint[point].rotation);
        yield return new WaitForSeconds(spawnTime-1f);
        spawTiming = true;
        spawnTime -= 0.02f;

    }
}

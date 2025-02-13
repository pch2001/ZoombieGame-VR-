using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerCtrl : MonoBehaviour
{

    public Transform firePos;
    public Transform mainCam;
    public GameObject Bullet;

    public bool mode = true;

    public int money = 1000;

    GameObject GameManager;
    GameScene game;

    public Text Hp_text;

    public bool goshoot = true;

    public AudioClip shotSound;
    public AudioClip dieSound;
    public AudioSource audio;
    public GameObject DIeEffect;

    // Start is called before the first frame update
    void Start()
    {
        Hp_text.text = "HP : " + data.Plus_HP;
        audio = GetComponent<AudioSource>();
        GameManager = GameObject.Find("GameManager");
        game = GameManager.GetComponent<GameScene>();

    }

    // Update is called once per frame
    void Update()
    {
        if(mode){
            if(Input.GetMouseButton(0)&&goshoot){
                firePos.rotation = mainCam.rotation;
                if(Input.GetMouseButtonDown(0)){    
                    goshoot = false;
                    StartCoroutine(Fire());
                }
            }
        }
        else if(!mode){
            if(Input.GetMouseButton(0)){
                Vector3 forwardDirection = mainCam.rotation * Vector3.forward;
                forwardDirection.y = 0f;
                transform.position += forwardDirection*5*Time.deltaTime;
            }
        }

        if(data.Plus_HP<=0){
            audio.PlayOneShot(dieSound);    
            //Debug.Log("사망");
            DIeEffect.SetActive(true);
            StartCoroutine(Restart());
            data.Plus_HP = 40;
            data.Minus_delay=0.4f;
            data.Plus_Demage=9;
        }



    }
    IEnumerator Restart(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    IEnumerator Fire(){
        //Debug.Log("발사준비");
        audio.PlayOneShot(shotSound);
        Instantiate(Bullet, firePos.position, firePos.rotation);
        //Debug.Log("발사");
        yield return new WaitForSeconds(data.Minus_delay);
        goshoot = true;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Store"))
        {
            //Debug.Log("상점 입장합니다.");
            SceneManager.LoadScene(2);

        }
        if(collision.gameObject.CompareTag("Finish")){
            //Debug.Log("미션 성공");
            data.stageNumber = 5;
        }
    }

   

}

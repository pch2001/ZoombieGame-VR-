using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCtrl : MonoBehaviour
{
    public Animation animationComponent;

    private UnityEngine.AI.NavMeshAgent navMesh;
    private GameObject player;
    private PlayerCtrl playerctrl;

    public bool change = false;
    public float HP;
    public bool diying = true;
    
    public GameObject hitEffect;

    public AudioClip bite;
    public AudioClip dieSound;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        HP=10;
        player = GameObject.Find("Player");
        playerctrl = player.GetComponent<PlayerCtrl>();
        animationComponent = GetComponent<Animation>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.destination = player.transform.position;


    }

    void Update()
    {
       float distance = Vector3.Distance(player.transform.position,this.transform.position);
        if(distance<= 4.0f&&diying){
            Debug.Log("공격준비");
            navMesh.Stop();
            if(change == false){
                animationComponent.Play("Attack2");
                Debug.Log("공격");
                StartCoroutine(Attack());
            }
        }
    }    
    IEnumerator Attack(){
        while(true){
            audio.PlayOneShot(bite);
            change= true;
            data.Plus_HP--;
            playerctrl.Hp_text.text = "HP : " + data.Plus_HP;
            yield return new WaitForSeconds(2.0f);
            change = false;
        }
        yield return null;
    }


    void OnTriggerEnter(Collider other){

            if(other.gameObject.CompareTag("Bullet")){
                GameObject effect = Instantiate(hitEffect, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(effect, 2.0f);
                HP -= data.Plus_Demage;
                if(HP<=0f){
                    StartCoroutine(Die());
                }
            }
        }


    

    IEnumerator Die(){
        navMesh.Stop();
        diying = false;
        audio.PlayOneShot(dieSound);
        animationComponent.Play("Death");
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);

    }

}

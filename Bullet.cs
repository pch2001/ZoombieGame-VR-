using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    
    public GameManager manager_Atrribute;
    public GameObject manager;


    public float bulletSpeed = 30.0f;
    void Start()
    {   

        manager = GameObject.Find("GameManager");
        manager_Atrribute = manager.GetComponent<GameManager>();
        /*if (manager == null)
        {
            Debug.LogError("GameManager 컴포넌트를 찾을 수 없습니다.");
        }*/
        Destroy(this.gameObject, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * bulletSpeed * Time.deltaTime;

    }
   



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            //  Debug.Log("총알과 버튼이 충돌했습니다."); 

            manager_Atrribute.Story_Start();
        }
        else if( other.CompareTag("Button2")){

            other.transform.GetComponent<Button>().onClick.Invoke();
        }
        
    }

    



}

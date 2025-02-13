using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text story_text;
    string[] str_arr = {
        "지금 이 세상은 좀비들로 지배되어 있는 세상입니다.",
        "좀비들은 지금 앞에 보시는 이 차원문에서 생성됩니다.",
        "맵 가운데에 모닥불에 가면 상점이 있어 무기를 강화 할 수 있습니다.",
        "터렛을 찾은 뒤 상점으로 돌아 오면 게임은 종료 됩니다.",
        "터렛의 모양은 뒤를 보시면 확인하실수 있습니다.",
        "그럼 이제 게임 시작하겠습니다.",
        "5초 뒤 자동으로 텔레포트 됩니다."



    };
    public GameObject One;
    public GameObject Two;
    public GameObject TREE;
    private int index=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Story_Start(){
        StartCoroutine(go());
    }
    IEnumerator go()
    {

        //Debug.Log("다음 대화");

        if (index >= 0 && index < str_arr.Length){
            if (index == 1){
                One.SetActive(true);
            }
            else if (index == 2){
                Two.SetActive(true);
            }else if(index ==4){
                TREE.SetActive(true);
            }
            else{
                if (index == str_arr.Length - 1){
                    story_text.text = str_arr[index];
                    yield return new WaitForSeconds(5f);
                    data.stageNumber = 1;
                    SceneManager.LoadScene(1);
            }
        }
        story_text.text = str_arr[index];
        index++; 
    }
        yield return new WaitForSeconds(0.5f);
    }

}

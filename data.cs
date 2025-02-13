using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    // Start is called before the first frame update
    public static float Plus_HP=40;
    public static float Minus_delay=0.4f;
    public static float Plus_Demage=9;
    public static int stageNumber =3;

    public static float Time_data = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Time_data += Time.deltaTime;
    }
}

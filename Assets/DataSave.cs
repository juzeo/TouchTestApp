using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Touch Test Record", menuName = "Record Data", order = 2)]


public class DataSave : ScriptableObject
{
    [SerializeField]

    float[] highscore;


    [SerializeField]

    float aver;

    [SerializeField]

    float touch;

    [SerializeField]

    float touchtemp;



    public float[] high => highscore;

    public float averscore => aver;

    public float touchcount => touch;
    public float touchTemp => touchtemp;

    public void touchcountup()
    {
        touch++;
    }
    public void touchtempget(float temp)
    {
        touchtemp = temp;
    }
    public void avermake()
    {
        aver = ((aver * touch) + touchtemp) / (touch + 1);
        aver = Mathf.Round(aver * 1000) / 1000;
    }
}

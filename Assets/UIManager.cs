using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider[] hpBars;

    //keeps track of who is in line for next health bar
    private int curIndex;

    private List<Stats> charStats;

    private void Awake()
    {
       charStats = new List<Stats>();
    }

    public void AssignBars(GameObject[] incTeam)
    {
       
        for(int i = 0; i < incTeam.Length; i++)
        {
            charStats.Add(incTeam[i].GetComponent<Stats>());
            curIndex++;
        }
        
    }


    public void UpdateBars()
    {
        for(int i = 0; i < hpBars.Length; i++)
        {
            //sliders value between 0.0f and 1.0f. so we need to make a float
            float percent = charStats[i].health / 100f;
            hpBars[i].value = percent;
        }
    }

}

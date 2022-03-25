using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] spawnlocs;
    public int teamSize = 3;
    public UIManager uiM;
    private GameObject[] teamA;
    private GameObject[] teamB;
    private int spawnTracker;

    private void Awake()
    {
        teamA = SetupTeam();
        teamB = SetupTeam();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiM = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if(uiM != null)
        {
            uiM.AssignBars(teamA);
            uiM.AssignBars(teamB);
            uiM.UpdateBars();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject randA = teamA[Random.Range(0, teamA.Length)];
            GameObject randB = teamB[Random.Range(0, teamB.Length)];
            randA.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
            randB.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
            if(uiM != null)
            {
                uiM.UpdateBars();
            }
        }
    }

    public GameObject[] SetupTeam()
    {
        GameObject[] newTeam = new GameObject[teamSize];
        for(int i = 0; i < teamSize; i++)
        {
            newTeam[i] = Instantiate(prefab, spawnlocs[spawnTracker].transform.position, transform.rotation);
            spawnTracker++;
        }
        return newTeam;
    }

    public void ButtonPressed()
    {
        
        if(Random.Range(0,7) >= 3)
        {
            teamB[Random.Range(0, 3)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
        }
        else 
        {
            teamA[Random.Range(0, 3)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
        }
        if(uiM != null)
        {
            uiM.UpdateBars();
        }
        //hint for brief, for when a characters are dead
        for(int i = 0; i < teamSize; i++)
        {
            int killed = 0;
            if(teamA[i].GetComponent<Stats>().health <= 0)
            {
                killed++;
            }
            if(killed >= teamSize)
            {
                Debug.Log("teamA as is defeated!");
                Application.Quit();
            }
        }
        for(int x = 0; x < teamSize; x++)
        {
            int killed = 0;
            if (teamB[x].GetComponent<Stats>().health <= 0)
            {
                //character is dead
                killed++;
            }
            else
            {
                //pick this character to fight
            }
            if(killed >= teamSize)
            {
                Debug.Log("Team B is defeated!");
                Application.Quit();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance=null;

    void Awake()
    {
        if(_instance==null){
            _instance=this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    public Text obtainCountText;
    public GameObject deathPanel;
    public GameObject victoryPanel;
    public GameObject[] keyInstances;
    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        deathPanelOff();
        victoryPanelOff();
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCountText(int count)
    {
        obtainCountText.text="obtained: "+count;
    }

    public void deathPanelOff()
    {
        deathPanel.SetActive(false);
    }

    public void deathPanelOn()
    {
        deathPanel.SetActive(true);
    }

    public void victoryPanelOff()
    {
        victoryPanel.SetActive(false);
    }

    public void victoryPanelOn()
    {
        victoryPanel.SetActive(true);
    }

    public void onRestartClick(){
        if(deathPanel.activeSelf){
            deathPanelOff();
        }
        if(victoryPanel.activeSelf){
            victoryPanelOff();
        }
        player.reset();

        foreach(GameObject key in keyInstances)
        {
            key.SetActive(true);
        }
    }

    public void onMenuClick(){
        if(deathPanel.activeSelf){
            SceneManager.LoadScene("MainMenu");
        }
    }

}

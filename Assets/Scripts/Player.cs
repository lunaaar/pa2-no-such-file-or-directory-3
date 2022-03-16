using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int collectableCount;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance().updateCountText(collectableCount);
        GameManager.instance().deathPanelOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseCollectableCount() {
        collectableCount+=1;
        GameManager.instance().updateCountText(collectableCount);
    }

    public void reset()
    {
        health = 1;
        collectableCount = 0;
        Vector3 pos = new Vector3(0f, 0f, 0f);
        this.transform.position = pos;
        GameManager.instance().updateCountText(collectableCount);
        this.gameObject.SetActive(true);
    }

    public void setHeath(int num)
    {
        health = num;
    }

}

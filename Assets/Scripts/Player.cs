using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    public LayerMask mask;

    public int health;
    public int collectableCount;
    private float input;
    private RaycastHit2D ground;
    private bool airborne;
    private RaycastHit2D wall;
    public GameObject wallFX;
    public GameObject landingFX;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance().updateCountText(collectableCount);
        //GameManager.instance().deathPanelOff();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(input > 0) {
            wall = Physics2D.Raycast(this.transform.position, Vector3.right, 2f, mask);
        } else if (input < 0) {
            wall = Physics2D.Raycast(this.transform.position, Vector3.left, 2f, mask);
        }

        ground = Physics2D.Raycast(this.transform.position, Vector3.down, 3.3f, mask);
        if(wall.collider != null) { 
            Instantiate(wallFX, new Vector3(transform.position.x + .8f, transform.position.y + 3f, 0f), Quaternion.identity);
        }
        if (ground.collider == null)
        {
            airborne = true;
        }
        else
        {
            if (airborne) {
                Instantiate(landingFX, new Vector3(transform.position.x + 0f, transform.position.y - 2f, 0f), Quaternion.identity);
                airborne = false;
            }
        }
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

    public void loseHealth()
    {
        health -= 1;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            Instantiate(deathEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            GameManager.instance().deathPanelOn();
        }
    }

    public int getCollectableCount()
    {
        return collectableCount;
    }

    public void victory()
    {
        this.gameObject.SetActive(false);
        GameManager.instance().victoryPanelOn();

    }

}

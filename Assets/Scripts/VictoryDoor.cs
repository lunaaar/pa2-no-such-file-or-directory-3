using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDoor : MonoBehaviour
{
    public int requiredKeys;
    public GameObject victoryEffect;
    Player p;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag == "Player")
        {
            if(p.getCollectableCount() == requiredKeys)
            {
                p.victory();
                Instantiate(victoryEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            }
        }
    }

}

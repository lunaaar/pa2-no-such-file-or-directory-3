using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject obtainEffect;
    public Player p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag == "Player")
        {
            p.increaseCollectableCount();
            Instantiate(obtainEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, -0.3f), Quaternion.identity);
            this.gameObject.SetActive(false);

        }
    }
}

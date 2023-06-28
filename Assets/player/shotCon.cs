using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotCon : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = 10f;
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}

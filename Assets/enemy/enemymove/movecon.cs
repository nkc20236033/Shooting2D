using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class movecon : MonoBehaviour
{ float speed = 5f;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.left;
      //左に見切れたら右からでてくる
        //if(transform.position .x <-9f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = 9f;
        //    transform.position = pos;
        //}
        ////yほうこうへのいどう
        //dir.y = Mathf.Sin(Time.time * 5f);

     dir = player.position  = transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
     
    
    
    }
}

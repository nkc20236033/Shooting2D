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
      //ç∂Ç…å©êÿÇÍÇΩÇÁâEÇ©ÇÁÇ≈ÇƒÇ≠ÇÈ
        //if(transform.position .x <-9f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = 9f;
        //    transform.position = pos;
        //}
        ////yÇŸÇ§Ç±Ç§Ç÷ÇÃÇ¢Ç«Ç§
        //dir.y = Mathf.Sin(Time.time * 5f);

     dir = player.position  = transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
     
    
    
    }
}

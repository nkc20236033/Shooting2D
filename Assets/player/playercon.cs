using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playercon : MonoBehaviour
{Vector3 dir = Vector3.zero;//ˆÚ“®•ûŒü‚ğ•Û‘¶
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized  *  speed * Time.deltaTime;
        //‰æ–Ê“àˆÚ“®§ŒÀ
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

    }
}

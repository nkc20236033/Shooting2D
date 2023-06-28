using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshot : MonoBehaviour
{
    Vector3 dir;        // 移動方向
    float speed;        // 移動速度
    gamedirec gd;    // GameDirectorコンポーネント保存
    Transform player;   // プレーヤーのトランスフォームコンポーネントを保存

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("tomato").transform;

        speed = 12f;

        dir = player.position - transform.position;
       
        gd = GameObject.Find("gamedirec").GetComponent<gamedirec>();

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag == "player")
        {
            gamedirec.kyori -= 500;
            Destroy(gameObject);
        }
    }
}

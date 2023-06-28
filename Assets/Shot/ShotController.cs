using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 10f;             // 弾速度
        Destroy(gameObject, 2f); // 寿命２秒
    }

    void Update()
    {
        // 移動
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // 重なり判定
    void OnTriggerEnter2D(Collider2D c)
    {
        
            // 当たってきたオブジェクトのTagが「bullet」だったら
            if (c.tag == "enemy")
            {
                Destroy(c.gameObject);  // 当たってきたオブジェクトを削除
                Destroy(gameObject);    // 自分自身を削除
            }
        
    }
}


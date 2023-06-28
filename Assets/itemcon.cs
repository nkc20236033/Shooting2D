using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemcon : MonoBehaviour
{
    SpriteRenderer spRender;    // レンダラーコンポーネント取得
    Vector3 pos;                // 出現位置
    int itemType;               // アイテムの種類
    float speed;                // 落下速度
    // Start is called before the first frame update
    void Start()
    {
        itemType = Random.Range(0, 3);
        speed = 5;

        Color[]col = { Color.red, Color.green, Color.blue };
        
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType];

        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "player")
        {
            playercon pCon = c.gameObject.GetComponent<playercon>();
            if(itemType == 0)
            {
                pCon.ShotLevel += 1;
            }
            else if(itemType == 1)
            {
                pCon.Speed += 5;
            }
            else if (itemType == 2)
            {
                pCon.Speed = 5;
                pCon.ShotLevel = 0;
            }
        }
        Destroy(gameObject);

    }
}

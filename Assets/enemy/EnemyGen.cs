using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    public GameObject enemyPre;
    float delta = 0;

    float span = 1f;
    
    void Update()
    {
        //経過時間を加算
        delta += Time.deltaTime;


        //敵を生成
        if (delta>span)
        {//時間経過を保存している変数を０にする
            delta = 0;
            //敵の出現間隔を短くする
            span -= (span > 0.5f) ? 0.01f : 0f;
            GameObject go = Instantiate(enemyPre);
            float ey = Random.Range(-5f, 5f);
            go.transform.position = new Vector3(10, ey, 0);
            
        }
    }
}

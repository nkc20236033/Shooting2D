using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycon : MonoBehaviour
{ 
    public GameObject ExploPre; // 爆発のプレハブを保存
    public GameObject ShotPre;  // 弾のプレハブを保存
    // speed 3~7                // 移動速度を保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 2f;    // 弾の発射間隔
    AudioClip seClip;
    Vector3 sepos;
    AudioSource audioSouce; //オーディオソースコンポーネントを保存
    AudioClip audioClip;　　//オーディオクリップを保存
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,6);
        enemyType = Random .Range(0,3);
        
        dir = Vector3.left;
        rad = Time.time;
        shotTime = 0;

        seClip = audioClip = Resources.Load<AudioClip>("bomb");
        sepos = new Vector3(0, 0, -10);


    }

    // Update is called once per frame
    void Update()
    {
       if(enemyType == 0)
        {
            
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }
        //移動処理
        transform.position += dir.normalized *  Random.Range(3, 7) * Time.deltaTime;

        //敵弾生成
        shotTime += Time.deltaTime;
        if(shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }
        void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "player")
        {
            gamedirec.kyori -= 1000;

            AudioSource.PlayClipAtPoint(seClip, sepos);
            Instantiate(ExploPre, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (c.tag == "shot")
        {
            // 距離を増やす
            gamedirec.kyori += 200;

            // 重なった相手が衝突爆発を生成
            AudioSource.PlayClipAtPoint(seClip, sepos);
            Instantiate(ExploPre, transform.position, transform.rotation);
            // 自分（敵）削除
            Destroy(gameObject);
        }
    }
}

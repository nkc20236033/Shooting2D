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
        //Œo‰ßŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;


        //“G‚ð¶¬
        if (delta>span)
        {//ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚O‚É‚·‚é
            delta = 0;
            //“G‚ÌoŒ»ŠÔŠu‚ð’Z‚­‚·‚é
            span -= (span > 0.5f) ? 0.01f : 0f;
            GameObject go = Instantiate(enemyPre);
            float ey = Random.Range(-5f, 5f);
            go.transform.position = new Vector3(10, ey, 0);
            
        }
    }
}

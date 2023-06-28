using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    AudioSource audioSouce; //オーディオソースコンポーネントを保存
    AudioClip audioClip;　　//オーディオクリップを保存
    // Start is called before the first frame update
    void Start()
    {



        //オーディオソースコンポーネントの情報を取得
        audioSouce = GetComponent<AudioSource>();

        audioSouce.clip = audioClip;
        //オーディオソースに登録されているオーディオクリップを再生する
        audioSouce.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

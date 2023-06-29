using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamedirec : MonoBehaviour
{
    public Text kyoriLabel;//距離を表示するUI-Textオブジェクト
    public static int kyori;             // 距離を保存
    public static float LastTime;　　　　//残り時間を保存
    public Image timegauge;//タイムゲージを表示
    // Start is called before the first frame update

    public Text shotLabel;  // 弾の強さ表示テキストオブジェクト保存

    public GameObject itemPre; // アイテムプレハブ保存

    // プレーヤーコントローラーコンポーネント保存
    playercon PC;

    // 残り時間を他のスクリプトから変更するための宣言 public static
    public static float lastTime;
    


    void Start()
    {
        kyori = 0;
        LastTime = 100f;//残り時間10０秒
        PC = GameObject.Find("tomato").GetComponent<playercon>();
    }

    // Update is called once per frame
    void Update()
    {
        int s = PC.ShotLevel;
        shotLabel.text = "ShotLv" + s;
        kyori++;
        if(kyori<0)kyori = 0;
        kyoriLabel.text = "獲得点" + kyori.ToString("D6") + "Pt";
        //残り時間を減らす処理
        LastTime -= Time.deltaTime;
        timegauge.fillAmount = LastTime/100f;
        //残り時間が0になったらEndingScenceへ
        if (LastTime < 0)
        {
            SceneManager.LoadScene(2);
        }
        // 距離が600kmで割り切れるときにアイテム出現
        if (kyori % 600.0f == 0)
        {
            Instantiate(itemPre);
        }

       
    }
    
}

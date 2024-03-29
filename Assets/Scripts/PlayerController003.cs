//--------------------------------------------------------------------
// 科目：ゲームアルゴリズム1年
// 内容：向いている方向に移動
// 日時：2023.05.25 Ken.D.Ohishi
//--------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController003 : MonoBehaviour
{
    public Text speedText;  // UI-TEXTオブジェクトを保存する

    Vector3 dir;            // 移動方向を保存する変数
    float speed;            // 移動量を保存する変数
    float axel;             // 加速度を保存する変数
    int bdash;              // Bダッシュ係数を保存する変数
    float rad;              // 回転角度を保存する変数
    float rotSpeed;         // 回転速度を保存する変数

    const float MAX_SPEED = 5; // スピードの上限値を指定する定数

    void Start()
    {
        // 各変数初期化
        dir      = Vector3.zero;
        speed    = 0;
        axel     = 0.02f;
        bdash    = 1;
        rad      = 0;
        rotSpeed = 3;
    }

    void Update()
    {
        // 左右キーで回転
        rad = Input.GetAxisRaw("Horizontal") * rotSpeed;
        transform.Rotate(Vector3.up, rad);

        // ↑キーで前進、↓キーで後退
        float z = Input.GetAxisRaw("Vertical");

        // 上下キーが押されているとき
        if(z != 0)
        {
            // 加速度を増やす
            speed += axel;

            // スピードを増やす（上限設定あり）
            speed = (speed <= MAX_SPEED)? speed : MAX_SPEED;

            // 進行方向をセット
            dir = transform.forward * z;  
        }
        else
        {
            // 減速処理
            speed *= 0.9f;
        }

        // クリックでリスタート
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0); // シーンをリスタート           
        }

        // Bdash処理
        bdash = (Input.GetKey(KeyCode.B)) ? 2 : 1;

        // 移動量を現在値に加算
        transform.position += dir.normalized * speed * bdash * Time.deltaTime;

        // 速度表示
        float sokudo = speed * bdash;
        speedText.text = "速度 " + sokudo.ToString("F2") + " m/s";
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// シーン遷移時のフェードイン・アウトを制御するためのクラス .
public class FadeManager : MonoBehaviour
{
    // リージョンディレクティブ　折りたたみ可能範囲指定
    #region Singleton

    // FadeManagerインスタンス保存用変数
    private static FadeManager instance;

    // Instanceプロパティの定義
    public static FadeManager Instance
    {
        // getアクセサー（ゲッター）
        get
        {
            // インスタンスが一度も生成されてなければ生成する
			if (instance == null)
            {
                // ヒエラルキーにいる FadeManager を探してインスタンスを生成
                instance = (FadeManager)FindObjectOfType(typeof(FadeManager));

                // ヒエラルキーに FadeManager がいない場合はエラー出力 
                if (instance == null)
                {
					Debug.LogError (typeof(FadeManager) + "is nothing");
				}
			}

            // FadeManager のインスタンスを返す
            return instance;
		}
	}

    // リージョンディレクティブ終了（ここまで折りたためる）
    #endregion Singleton

    Image image;                  // Imageコンポーネント保存
    Color fadeColor;              // フェード用カラー変数
    float fadeAlpha = 0;          // フェード中の透明度
    bool isFading = false;        // フェード中かどうか

    // Startメソッドよりも先に呼び出されるgameObject作成時に一度だけ呼び出されるメソッド
    public void Awake ()
	{
        // 親オブジェクトCanvasのReferenceResolutionサイズとImageサイズを同じにする
        CanvasScaler canvasScaler = transform.parent.gameObject.GetComponent<CanvasScaler>();
        GetComponent<RectTransform>().sizeDelta = canvasScaler.referenceResolution;

        // imageコンポーネントを取得
        image = GetComponent<Image>();

        // イメージコンポーネントのカラーをフェード用カラー変数にセット
        fadeColor = image.color;

        // 既存のFadeManagerインスタンスと別物であれば破棄
        if (this != Instance)
        {
			Destroy(gameObject);
			return;
        }

        // Scene切替時でもFadeManagerは破棄せずに保持しておく
        // DontDestroyOnLoad(gameObject);

        // フェード用のFadeCanvasを破棄せず保持しておく
        DontDestroyOnLoad(transform.root.gameObject);

    }

    // 更新処理
    private void Update()
    {
        if (!isFading) return;      // フェード中でなければ以下の処理を実行しない

        fadeColor.a = fadeAlpha;    // アルファ値をセット(fadeAlphaはコルーチンで変更)
        image.color = fadeColor;    // Imageコンポーネントに色をセット
    }

    // 画面遷移 
    // 引数：シーン名 , 暗転にかかる時間(秒)
    public void LoadScene (string scene, float interval)
	{
        // フェード中はコルーチンをスタートさせない
        if (isFading == false)
        {
            // コルーチンをスタート
            StartCoroutine(TransScene(scene, interval));
        }
	}

	// シーン遷移用コルーチン .
    // 引数：シーン名 , 暗転にかかる時間(秒)
	private IEnumerator TransScene (string scene, float interval)
	{
        isFading = true;                // フェードフラグON

        // フェードアウト（だんだん暗く）
        float time = 0;
		while (time <= interval)
        {
			fadeAlpha = Mathf.Lerp (0f, 1f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//シーン切替
		SceneManager.LoadScene(scene);

		// フェードイン（だんだん明るく）
		time = 0;
		while (time <= interval)
        {
			fadeAlpha = Mathf.Lerp (1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

        isFading = false;               // フェードフラグ OFF
	}
}

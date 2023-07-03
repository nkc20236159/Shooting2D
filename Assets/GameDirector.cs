using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //距離を表示するUI-Textオブジェクト
    public static int kyori; //距離を保存する変数
    public GameObject Boss;
    public GameObject itemPre; // アイテムプレハブ保存
    public Image TimeGauge; //タイムゲージを表示するUI
    PlayerController playerCon;
    public static float lastTime; //  残り時間を保存する変数
    public Text MeteostacLabel;
    public  int Meteostac;
    public int Kyori
    {
        set
        {
            kyori = value;
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }
    void Start()
    {
        kyori = 0;
        Meteostac = 0;
        lastTime = 100f; //残り時間100秒
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {　
        //残り時間を減らす処理
        lastTime -= Time.deltaTime;
        TimeGauge.fillAmount = lastTime / 100f;

        // 距離が600kmで割り切れるときにアイテム出現
        if (kyori % 600 == 0)
        {
            Instantiate(itemPre);
        }
        // 距離が5000kmで割り切れるとき?にボス出現
        if (kyori % 5000 == 0 && kyori != 0)
        {
            Instantiate(Boss);
        }

        //残り時間が0になったらリロード
        if (lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        MeteostacLabel.text = "残り" + Meteostac.ToString("D1") + "回";
    }
}


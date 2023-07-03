using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    AudioSource AudioSource; // オーディオソースコンポーネント取得
    AudioClip Audioclip;    // オーディオクリップ保存
    AudioClip[] BgmClip = new AudioClip[1]; // オーディオクリップ保存(3曲分)

    AudioClip SeClip;   // 効果音を保存する変数
    Vector3 SePos;      // 効果音を再生する位置を保存する変数

    // Start is called before the first frame update
    void Start()
    {
        SeClip = Resources.Load<AudioClip>("Audio/SE/bomb");
        SePos = GameObject.Find("Main Camera").transform.position;

        //bgmClip[0] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit08");
        //bgmClip[1] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit10");
        //bgmClip[2] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");
        string[] bgmName =
        {
            "Audio/BGM/bgm_maoudamashii_8bit11"
        };
        for (int i = 0; i < 1; i++)
        {
            BgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }

        // Resourcesフォルダ内に保存されているAudioフォルダ内に保存されている
        // BGMフォルダ内に保存されているオーディオファイルを読み込む
        Audioclip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");

        // オーディオソースコンポーネントを取得する
        AudioSource = GetComponent<AudioSource>();

        AudioSource.clip = Audioclip;

        // オーディオソースに登録されているオーディオクリップを再生する
        //audioSource.Play();
        AudioSource.clip = BgmClip[0];

        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource; // オーディオソースコンポーネント取得
    AudioClip audioclip;    // オーディオクリップ保存
    AudioClip[] bgmClip = new AudioClip[1]; // オーディオクリップ保存(3曲分)

    AudioClip seClip;   // 効果音を保存する変数
    Vector3 sePos;      // 効果音を再生する位置を保存する変数

    // Start is called before the first frame update
    void Start()
    {
        seClip = Resources.Load<AudioClip>("Audio/SE/shoot3");
        sePos = GameObject.Find("Main Camera").transform.position;

        //bgmClip[0] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit08");
        //bgmClip[1] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit10");
        //bgmClip[2] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");
        string[] bgmName =
        {
            "Audio/BGM/bgm_maoudamashii_8bit25"    // bgmName[0]
        };
        for (int i = 0; i < 1; i++)
        {
            bgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }

        // Resourcesフォルダ内に保存されているAudioフォルダ内に保存されている
        // BGMフォルダ内に保存されているオーディオファイルを読み込む
        audioclip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit25");

        // オーディオソースコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioclip;

        // オーディオソースに登録されているオーディオクリップを再生する
        //audioSource.Play();

        audioSource.clip = bgmClip[0];

        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    AudioSource.PlayClipAtPoint(seClip, sePos);
        //}

    }
}
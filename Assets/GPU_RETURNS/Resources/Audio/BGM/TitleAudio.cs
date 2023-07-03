using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    AudioSource AudioSource; // �I�[�f�B�I�\�[�X�R���|�[�l���g�擾
    AudioClip Audioclip;    // �I�[�f�B�I�N���b�v�ۑ�
    AudioClip[] BgmClip = new AudioClip[1]; // �I�[�f�B�I�N���b�v�ۑ�(3�ȕ�)

    AudioClip SeClip;   // ���ʉ���ۑ�����ϐ�
    Vector3 SePos;      // ���ʉ����Đ�����ʒu��ۑ�����ϐ�

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

        // Resources�t�H���_���ɕۑ�����Ă���Audio�t�H���_���ɕۑ�����Ă���
        // BGM�t�H���_���ɕۑ�����Ă���I�[�f�B�I�t�@�C����ǂݍ���
        Audioclip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");

        // �I�[�f�B�I�\�[�X�R���|�[�l���g���擾����
        AudioSource = GetComponent<AudioSource>();

        AudioSource.clip = Audioclip;

        // �I�[�f�B�I�\�[�X�ɓo�^����Ă���I�[�f�B�I�N���b�v���Đ�����
        //audioSource.Play();
        AudioSource.clip = BgmClip[0];

        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

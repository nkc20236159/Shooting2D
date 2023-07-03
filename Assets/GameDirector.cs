using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //������\������UI-Text�I�u�W�F�N�g
    public static int kyori; //������ۑ�����ϐ�
    public GameObject Boss;
    public GameObject itemPre; // �A�C�e���v���n�u�ۑ�
    public Image TimeGauge; //�^�C���Q�[�W��\������UI
    PlayerController playerCon;
    public static float lastTime; //  �c�莞�Ԃ�ۑ�����ϐ�
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
        lastTime = 100f; //�c�莞��100�b
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {�@
        //�c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        TimeGauge.fillAmount = lastTime / 100f;

        // ������600km�Ŋ���؂��Ƃ��ɃA�C�e���o��
        if (kyori % 600 == 0)
        {
            Instantiate(itemPre);
        }
        // ������5000km�Ŋ���؂��Ƃ�?�Ƀ{�X�o��
        if (kyori % 5000 == 0 && kyori != 0)
        {
            Instantiate(Boss);
        }

        //�c�莞�Ԃ�0�ɂȂ����烊���[�h
        if (lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";

        MeteostacLabel.text = "�c��" + Meteostac.ToString("D1") + "��";
    }
}


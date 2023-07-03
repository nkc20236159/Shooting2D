using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject exploPre; // �����̃v���n�u��ۑ�
    public GameObject shotPre;  // �e�̃v���n�u��ۑ�
    float Speed;                // �ړ����x��ۑ�
    Vector3 Dir;                // �ړ�������ۑ�
    int EnemyType;              // �G�̎�ނ�ۑ�
    float Rad;                  // �G�̓����T�C���J�[�u�p
    float ShotTime;             // �e�̔��ˊԊu�v�Z�p
    float ShotInterval = 0.4f;    // �e�̔��ˊԊu
    GameDirector Gd;            // GameDirector�R���|�[�l���g��ۑ�
    AudioClip SEClip;
    AudioClip seClip;   // ���ʉ���ۑ�����ϐ�
    Vector3 sePos;      // ���ʉ����Đ�����ʒu��ۑ�����ϐ�
    int i = 0;
    void Start()
    {
        EnemyType = Random.Range(0, 4); // �G�̎��
        Speed = 5;                      // �ړ����x
        Dir = Vector3.left;             // �ړ�����
        Rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        ShotTime = 0;                   // �e���ˊԊu�v�Z�p

        // GameDirector�R���|�[�l���g��ۑ�
        Gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
        SEClip = Resources.Load<AudioClip>("Audio/SE/damage1");
        sePos = GameObject.Find("Main Camera").transform.position;

    }

    void Update()
    {

        // �ړ�����
        transform.position += Dir.normalized * Speed * Time.deltaTime;

        // �G�̒e�̐���
        ShotTime += Time.deltaTime;
        if (ShotTime > ShotInterval)
        {
            ShotTime = 0;
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * 5);
            Instantiate(shotPre, transform.position, rot);
        }
        if (EnemyType == 3)
        {
            transform.position += Dir.normalized * Speed * Time.deltaTime;

        }
        // ��ʓ�����
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 6f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;
    }

    // �d�Ȃ蔻�菈��
    void OnTriggerEnter2D(Collider2D other)
    {
        // �d�Ȃ�������̃^�O���yPlayer�z��������
        if (other.tag == "Player")
        {
            // ���������炷
            Gd.Kyori -= 1000;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(exploPre, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(seClip, sePos);
            AudioSource.PlayClipAtPoint(SEClip, sePos);
        }
        if (other.tag == "MeteoShot")
        {
            i += 50;
            Debug.Log(i);
            //HP
            if (i >= 100)
            {
                // �����𑝂₷
                Gd.Kyori += 10000;
                AudioSource.PlayClipAtPoint(seClip, sePos);
                // �����i�G�j�폜
                Destroy(gameObject);
            }
            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(exploPre, transform.position, transform.rotation);
        }

        // �d�Ȃ�������̃^�O���yPlayerShot�z��������
        if (other.tag == "PlayerShot")
        {
            i += 1;
            Debug.Log(i);
            //HP
            if (i >= 100)
            {
                // �����𑝂₷
                Gd.Kyori += 10000;
                AudioSource.PlayClipAtPoint(seClip, sePos);
                AudioSource.PlayClipAtPoint(seClip, sePos);
                AudioSource.PlayClipAtPoint(seClip, sePos);
                // �����i�G�j�폜
                Destroy(gameObject);
            }
            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(exploPre, transform.position, transform.rotation);
        }

    }
}
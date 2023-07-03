using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ExploPre; // �����̃v���n�u��ۑ�
    public GameObject ShotPre;  // �e�̃v���n�u��ۑ�
    float speed;                // �ړ����x��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 2.5f;    // �e�̔��ˊԊu
    GameDirector gd;            // GameDirector�R���|�[�l���g��ۑ�
    AudioClip seClip;   // ���ʉ���ۑ�����ϐ�
    AudioClip SEClip;
    Vector3 sePos;      // ���ʉ����Đ�����ʒu��ۑ�����ϐ�
    void Start()
    {
        Destroy(gameObject, 6);		    // ����
        enemyType = Random.Range(0, 3); // �G�̎��
        speed = 5;                      // �ړ����x
        dir = Vector3.left;             // �ړ�����
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        shotTime = 0;                   // �e���ˊԊu�v�Z�p

        // GameDirector�R���|�[�l���g��ۑ�
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
        SEClip = Resources.Load<AudioClip>("Audio/SE/damage1");
        sePos = GameObject.Find("Main Camera").transform.position;
    }

    void Update()
    {
        if (enemyType == 1)
        {
            dir = Vector3.left;
        }
            // �G�l�~�[�^�C�v�Q�����c�ړ��i�T�C���J�[�u�j�ǉ�
            if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }

        // �ړ�����
        transform.position += dir.normalized * speed * Time.deltaTime;

        // �G�̒e�̐���
        shotTime += Time.deltaTime;
        if (shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }

    // �d�Ȃ蔻�菈��
void OnTriggerEnter2D(Collider2D other)
    {
        // �d�Ȃ�������̃^�O���yPlayer�z��������
        if (other.tag == "Player")
        {
            // ���������炷
            gd.Kyori -= 300;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);

            // �����i�G�j�폜
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(seClip, sePos);
            AudioSource.PlayClipAtPoint(SEClip, sePos);
        }

        // �d�Ȃ�������̃^�O���yPlayerShot�z��������
        if (other.tag == "PlayerShot")
        {

            // �����𑝂₷
            gd.Kyori += 200;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);

            // �����i�G�j�폜
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(seClip, sePos);
        }
        // �d�Ȃ�������̃^�O���yMeteoShot�z��������
        if (other.tag == "MeteoShot")
        {

            // �����𑝂₷
            gd.Kyori += 300;

            // �d�Ȃ������肪�Փ˔����𐶐�
            Instantiate(ExploPre, transform.position, transform.rotation);

            // �����i�G�j�폜
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(seClip, sePos);
        }
    }
}
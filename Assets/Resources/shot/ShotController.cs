using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float speed;
    Transform player;
    //public GameObject tama;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        //�v���[���[�̃g�����X�t�H�[���R���|�[�l���g�̏����擾
        player = GameObject.Find("Player").transform;

        //�e�̔��ˈʒu���v���[���[�ɍ��킹��
        transform.position = player.position + new Vector3(0.85f, 0, 0);

        //�e�̌������v���[���[�̌����Ă�������ɍ��킹��
        //transform.forward = player.forward;
        speed = 10f;             // �e���x
        Destroy(gameObject, 2f); // �����Q�b
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�
        transform.position += transform.up * speed * Time.deltaTime;
        ////���_����70m�ȏ㗣�ꂽ�猴�_�ɖ߂�
        //if (transform.position.magnitude > 70)
        //{
        //    Destroy(gameObject);
        //    //transform.position = new Vector3(0, 0.5f, 0);
        //}
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        // �d�Ȃ�������̃^�O���yEnemy�z��������
        if (c.tag == "Enemy")
        {
            // ���e�폜
            Destroy(gameObject);
        }
    }
}

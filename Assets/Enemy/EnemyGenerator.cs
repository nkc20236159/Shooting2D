using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre; //�G�̃v���n�u��ۑ�����ϐ�
    float delta =0;                //�o�ߎ��Ԍv�Z�p
    float span = 1;                 //�G���o���Ԋu(�b)
    void Start()
    {
        delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�v�Z���Ԃ����Z
        delta += Time.deltaTime;
        if (delta > span)
        {
            //�G�𐶐�����
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-6f, 7f);
            go.transform.position = new Vector3(10, py, 0);

            //�o�ߎ��Ԃ�ۑ����Ă���ϐ���0�N���A����
            delta = 0;

            //�G���o���Ԋu�����X�ɒZ������
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }   
    }
}

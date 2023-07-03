using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPre; //“G‚ÌƒvƒŒƒnƒu‚ð•Û‘¶‚·‚é•Ï”
    float delta =0;                //Œo‰ßŽžŠÔŒvŽZ—p
    float span = 1;                 //“G‚ðo‚·ŠÔŠu(•b)
    void Start()
    {
        delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ŒvŽZŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;
        if (delta > span)
        {
            //“G‚ð¶¬‚·‚é
            GameObject go = Instantiate(EnemyPre);
            float py = Random.Range(-6f, 7f);
            go.transform.position = new Vector3(10, py, 0);

            //Œo‰ßŽžŠÔ‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð0ƒNƒŠƒA‚·‚é
            delta = 0;

            //“G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }   
    }
}

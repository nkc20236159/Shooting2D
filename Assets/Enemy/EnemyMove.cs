using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //X•ûŒü‚ÌˆÚ“®
        float speed = 5f;
        Vector3 dir = Vector3.zero;

        //¶‚ÉŒ©Ø‚ê‚½‚ç‰E‚©‚ç“oê
        //if(transform.position.x < -9f)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = 9f;
        //    transform.position = pos;
        //}

        //Y•ûŒü‚ÌˆÚ“®
        //-1 <= Marhf.Sin(Time.time * 5f) <= 1
        //dir.x = 5f * Mathf.Cos(Time.time * 5f);
        dir.y = 2f * Mathf.Sin(Time.time * 5f);
        transform.position += dir/*.normalized*/ * speed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    Transform player;
    float speed = 5f;
    Vector3 dir = Vector3.zero;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //敵の移動方向をプレイヤーのいる方向にする
        dir = player.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;

    } 
}
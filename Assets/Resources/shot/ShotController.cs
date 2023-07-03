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
        //プレーヤーのトランスフォームコンポーネントの情報を取得
        player = GameObject.Find("Player").transform;

        //弾の発射位置をプレーヤーに合わせる
        transform.position = player.position + new Vector3(0.85f, 0, 0);

        //弾の向きをプレーヤーの向いている方向に合わせる
        //transform.forward = player.forward;
        speed = 10f;             // 弾速度
        Destroy(gameObject, 2f); // 寿命２秒
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        transform.position += transform.up * speed * Time.deltaTime;
        ////原点から70m以上離れたら原点に戻す
        //if (transform.position.magnitude > 70)
        //{
        //    Destroy(gameObject);
        //    //transform.position = new Vector3(0, 0.5f, 0);
        //}
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        // 重なった相手のタグが【Enemy】だったら
        if (c.tag == "Enemy")
        {
            // 自弾削除
            Destroy(gameObject);
        }
    }
}

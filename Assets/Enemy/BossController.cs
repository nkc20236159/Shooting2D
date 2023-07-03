using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject exploPre; // 爆発のプレハブを保存
    public GameObject shotPre;  // 弾のプレハブを保存
    float Speed;                // 移動速度を保存
    Vector3 Dir;                // 移動方向を保存
    int EnemyType;              // 敵の種類を保存
    float Rad;                  // 敵の動きサインカーブ用
    float ShotTime;             // 弾の発射間隔計算用
    float ShotInterval = 0.4f;    // 弾の発射間隔
    GameDirector Gd;            // GameDirectorコンポーネントを保存
    AudioClip SEClip;
    AudioClip seClip;   // 効果音を保存する変数
    Vector3 sePos;      // 効果音を再生する位置を保存する変数
    int i = 0;
    void Start()
    {
        EnemyType = Random.Range(0, 4); // 敵の種類
        Speed = 5;                      // 移動速度
        Dir = Vector3.left;             // 移動方向
        Rad = Time.time;                // サインカーブの動きをずらす用
        ShotTime = 0;                   // 弾発射間隔計算用

        // GameDirectorコンポーネントを保存
        Gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
        SEClip = Resources.Load<AudioClip>("Audio/SE/damage1");
        sePos = GameObject.Find("Main Camera").transform.position;

    }

    void Update()
    {

        // 移動処理
        transform.position += Dir.normalized * Speed * Time.deltaTime;

        // 敵の弾の生成
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
        // 画面内制限
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 6f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;
    }

    // 重なり判定処理
    void OnTriggerEnter2D(Collider2D other)
    {
        // 重なった相手のタグが【Player】だったら
        if (other.tag == "Player")
        {
            // 距離を減らす
            Gd.Kyori -= 1000;

            // 重なった相手が衝突爆発を生成
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
                // 距離を増やす
                Gd.Kyori += 10000;
                AudioSource.PlayClipAtPoint(seClip, sePos);
                // 自分（敵）削除
                Destroy(gameObject);
            }
            // 重なった相手が衝突爆発を生成
            Instantiate(exploPre, transform.position, transform.rotation);
        }

        // 重なった相手のタグが【PlayerShot】だったら
        if (other.tag == "PlayerShot")
        {
            i += 1;
            Debug.Log(i);
            //HP
            if (i >= 100)
            {
                // 距離を増やす
                Gd.Kyori += 10000;
                AudioSource.PlayClipAtPoint(seClip, sePos);
                AudioSource.PlayClipAtPoint(seClip, sePos);
                AudioSource.PlayClipAtPoint(seClip, sePos);
                // 自分（敵）削除
                Destroy(gameObject);
            }
            // 重なった相手が衝突爆発を生成
            Instantiate(exploPre, transform.position, transform.rotation);
        }

    }
}
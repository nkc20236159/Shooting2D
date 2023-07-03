using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoContoroller : MonoBehaviour
{
    float speed;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("iti").transform;
        Destroy(gameObject, 5f);
        transform.position = player.position + new Vector3(0.85f, 0, 0);
        speed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        // d‚È‚Á‚½‘Šè‚Ìƒ^ƒO‚ªyEnemyz‚¾‚Á‚½‚ç
        if (c.tag == "Enemy")
        {
            
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcode : MonoBehaviour
{
    void Start()
    {
        Invoke("DestoryGameObj", 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemyhealthcode>().bulletHit();
            DestoryGameObj();
        }
    }

    void DestoryGameObj()
    {
        Destroy(gameObject);
    }
}

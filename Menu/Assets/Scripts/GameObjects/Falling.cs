using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Human"))
        {
            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 2f);    
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}

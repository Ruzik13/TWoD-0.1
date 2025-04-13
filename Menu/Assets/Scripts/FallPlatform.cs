using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Invoke("fallPlatform", 1f);
            Destroy(gameObject, 2f);
        }
    }
    void fallPlatform()
    {
        rb.isKinematic = false;
    }
}

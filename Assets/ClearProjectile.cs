using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

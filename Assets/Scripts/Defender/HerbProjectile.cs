using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbProjectile : Projectile
{

    [SerializeField] float slowFactor = 0.5f;

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attacker")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;

            var attacker = collision.GetComponent<Attacker>();
            attacker.DealDamage(damage);
            StartCoroutine(SlowAttackerDown(attacker));
        }
    }

    IEnumerator SlowAttackerDown(Attacker attacker)
    {
        attacker.SetSlowFactor(slowFactor);
        yield return new WaitForSeconds(3f);
        attacker.SetSlowFactor(1f);
        Destroy(gameObject);
    }
}

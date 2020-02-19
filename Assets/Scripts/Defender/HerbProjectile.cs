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
            var slowColor = new Color32(221, 203, 191, 255);

            attacker.DealDamage(damage);

            StartCoroutine(SlowAttackerDown(attacker, slowColor));
        }
    }

    IEnumerator SlowAttackerDown(Attacker attacker,  Color32 slowColor)
    {
        attacker.SetSlowFactor(slowFactor);
        attacker.SetColor(slowColor);

        yield return new WaitForSeconds(2f);

        if (attacker)
        {
            attacker.SetSlowFactor(1f);
            attacker.SetColor(Color.white);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBottleProjectile : Projectile
{
    public new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attacker")
        {
            var attacker = collision.GetComponent<Attacker>();

            attacker.DealDamage(damage);

            StartCoroutine(BlinkColor(attacker));
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.GetComponent<Boss>().DealDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkColor(Attacker attacker)
    {
        var currentColor = attacker.GetColor();
        var blinkColor = new Color32(221, 203, 191, 255);
        attacker.SetColor(blinkColor);

        yield return new WaitForSeconds(0.1f);

        if (attacker)
        {
            attacker.SetColor(currentColor);
        }
    }
}

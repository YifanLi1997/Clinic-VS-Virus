using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBottleProjectile : Projectile
{

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attacker")
        {
            // play destroy animation

            var attacker = collision.GetComponent<Attacker>();
            attacker.DealDamage(damage);
        }
    }
}

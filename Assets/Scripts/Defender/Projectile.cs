using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] float speed = 1f;
    //[SerializeField] int damage = 100;

    public float speed = 1f;
    public int damage = 100;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attacker")
        {
            // play destroy animation
            Destroy(gameObject);

            var attacker = collision.GetComponent<Attacker>();
            attacker.DealDamage(damage);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}

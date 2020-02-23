using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] int health = 2222;
    [SerializeField] AudioClip deathSFX;

    // for visualization
    [SerializeField] bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Defender" || collision.gameObject.tag == "Attacker")
        {
            Destroy(collision.gameObject);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;

        if (currentSpeed > 0)
        {
            isActive = true;
        }
    }

    public bool GetIsActive()
    {
        return isActive;
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isActive = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<AudioSource>().mute = true;

            AudioSource.PlayClipAtPoint(deathSFX, transform.position, 0.03f);
        }
    }
}

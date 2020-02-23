using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] int fullHealth = 6666;

    [SerializeField] AudioClip deathSFX;
    [SerializeField] Slider healthBar;

    // for visualization
    [SerializeField] bool isActive = false;
    [SerializeField] int currentHealth = 6666;

    private void Start()
    {
        healthBar.maxValue = fullHealth;
    }

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

        healthBar.value = currentHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isActive = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<AudioSource>().mute = true;

            AudioSource.PlayClipAtPoint(deathSFX, transform.position, 0.03f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Movement")]
    [Range(0f, 5f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float slowFactor = 1f;

    [Header("Health")]
    [SerializeField] int health = 500;
    [SerializeField] GameObject deathVFXPrefab;
    [SerializeField] AudioClip deathSFX;


    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * slowFactor * Time.deltaTime);
    }

    public float GetMovementSpeed()
    {
        return currentSpeed;
    }

    public void SetMovementSpeed(float speed)
    {
         currentSpeed = speed;
    }

    public float GetSlowFactor()
    {
        return slowFactor;
    }

    public void SetSlowFactor(float factor)
    {
        slowFactor = factor;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            var deathVFX = Instantiate(deathVFXPrefab, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(deathSFX, transform.position);
            Destroy(gameObject);
            Destroy(deathVFX, 1f);
        }
    }
}

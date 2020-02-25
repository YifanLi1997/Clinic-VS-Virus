using System;
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

    [Header("Attack")]
    [SerializeField] int damage = 50;
    GameObject currentTarget;

    LevelController m_levelController;

    private void Start()
    {
        m_levelController = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * slowFactor * Time.deltaTime);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Defender")
        {
            currentTarget = collision.gameObject;
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
    }

    public void DoDamage()
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<Defender>().DealDamage(damage);
        }
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

    public Color32 GetColor()
    {
        return gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }

    public void SetColor(Color32 color32)
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color32;
    }
}

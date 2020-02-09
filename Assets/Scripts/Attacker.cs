using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] int health = 500;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // play death animation
            Destroy(gameObject);
        }
    }
}

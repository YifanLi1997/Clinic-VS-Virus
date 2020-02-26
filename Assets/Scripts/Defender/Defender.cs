using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int cost = 100;

    bool m_mouseOver;
    
    public int GetCost()
    {
        return cost;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (RightClick())
        {
            Destroy(gameObject);
        }
    }

    private bool RightClick()
    {
        if (m_mouseOver && Input.GetMouseButtonDown(1))
        {
            return true;
        }
        return false;
    }

    private void OnMouseEnter()
    {
        m_mouseOver = true;
    }

    private void OnMouseExit()
    {
        m_mouseOver = false;
    }
}

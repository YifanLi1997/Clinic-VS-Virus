using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gunPosition;

    Animator m_animator;
    AttackerSpawner m_attackerSpawner;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_attackerSpawner = FindMySpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            // shoot
            m_animator.SetBool("isAttacking", true);
        }
        else
        {
            // idle
            m_animator.SetBool("isAttacking", false);
        }
        
    }

    private AttackerSpawner FindMySpawner()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(transform.position.y - spawner.transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                 return spawner;
            }
        }

        return null;
    }

    private bool IsAttackerInLane()
    {
        if (m_attackerSpawner.transform.childCount > 0)
        {
            return true;
        }

        return false;
    }

    public void Fire()
    {
        var newProjectile = Instantiate(
            projectilePrefab,
            gunPosition.transform.position,
            transform.rotation);
        newProjectile.transform.parent = transform;
    }
}

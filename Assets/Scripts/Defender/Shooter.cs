using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gunPosition;

    public void Fire()
    {
        var newProjectile = Instantiate(
            projectilePrefab,
            gunPosition.transform.position,
            transform.rotation);
        newProjectile.transform.parent = transform;
    }
}

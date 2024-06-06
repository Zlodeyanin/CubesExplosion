using System.Collections.Generic;
using UnityEngine;

public class CubesDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> spawnedCubes)
    {
        foreach (Rigidbody cube in spawnedCubes)
        {
           cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
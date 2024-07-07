using System.Collections.Generic;
using UnityEngine;

public class CubesDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode()
    {
        if (gameObject.transform.localScale.x == 1)
        {
            foreach (Rigidbody cube in GetExplodableObjects())
            {
                cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
        else
        {
            float difference = 1f - gameObject.transform.localScale.x;
            difference *= 10;

            foreach (Rigidbody cube in GetExplodableObjects())
            {
                cube.AddExplosionForce(_explosionForce * difference, transform.position, _explosionRadius * difference);
            }           
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
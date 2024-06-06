using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private MouseRayHandler _handler;
    [SerializeField] private CubesDetonator _cubesDetonator;

    private List<Rigidbody> _spawnedCubes = new List<Rigidbody>();

    private void OnEnable()
    {
        _handler.CubeChanged += Spawn;
    }

    private void OnDisable()
    {
        _handler.CubeChanged -= Spawn;
    }

    private void Spawn(Cube hittedCube)
    {
        int count = Random.Range(2, 6);
        float chanse = Random.Range(0f, 1f);

        if (hittedCube.ShareChanse > chanse) 
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newCube = Instantiate(hittedCube.gameObject);
                newCube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
                newCube.transform.localScale = newCube.transform.localScale / 2;      
                Rigidbody spawnedCube = newCube.GetComponent<Rigidbody>();
                _spawnedCubes.Add(spawnedCube);
                Destroy(hittedCube.gameObject);
            }

            _cubesDetonator.Explode(_spawnedCubes);
            _spawnedCubes.Clear();         
        }
        else
        {
            Destroy(hittedCube.gameObject);
        }
        
    }
}
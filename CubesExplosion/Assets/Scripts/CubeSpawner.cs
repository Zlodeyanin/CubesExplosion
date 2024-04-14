using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private MouseRayHandler _handler;
    [SerializeField] private Cube _cube;

    private GameObject _newCube;
    
    private void Start()
    {
        _newCube = _cube.gameObject;
    }

    private void OnEnable()
    {
        _handler.CubeChanged += Spawn;
    }

    private void OnDisable()
    {
        _handler.CubeChanged -= Spawn;
    }

    private void Spawn()
    {
        int count = Random.Range(2, 6);
        int chanse = 100;
        Vector3 newCubeScale;

            for (int i = 0; i < count; i++)
            {
                GameObject newCube = Instantiate(_newCube);
                newCube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1f),Random.Range(0.0f, 1f),Random.Range(0.0f, 1f));
                newCubeScale = newCube.transform.localScale/2;
                newCube.transform.localScale = newCubeScale;
                chanse /= 2;
                //_newCube = newCube;
            }
    }
}
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private MouseRayHandler _handler;

    private CubesDetonator _cubesDetonator;

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
        _cubesDetonator = hittedCube.GetComponent<CubesDetonator>();
        int count = Random.Range(2, 6);
        float chanse = Random.Range(0f, 1f);

        if (hittedCube.ShareChanse > chanse) 
        {
            for (int i = 0; i < count; i++)
            {
                MeshRenderer newCube = Instantiate(hittedCube.GetComponent<MeshRenderer>());
                newCube.material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
                newCube.transform.localScale = newCube.transform.localScale / 2;
                Destroy(hittedCube.gameObject);
            }

            _cubesDetonator.Explode();       
        }

        else
        {
            _cubesDetonator.Explode();
            Destroy(hittedCube.gameObject);
        }   
    }
}
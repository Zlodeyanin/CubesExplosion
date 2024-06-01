using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private MouseRayHandler _handler;

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
        int chanse = Random.Range(0, 100);

        Debug.Log("Шанс разделения" + chanse);
        Debug.Log("Шанс разделения выбранного куба" + hittedCube.ShareChanse);


        if (hittedCube.ShareChanse > chanse) 
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newCube = Instantiate(hittedCube.gameObject);
                newCube.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
                newCube.transform.localScale = newCube.transform.localScale / 2;
                hittedCube.ReduceShareChanse();
                Destroy(hittedCube.gameObject);
            }
        }
        else
        {
            Destroy(hittedCube.gameObject);
        }
        
    }
}
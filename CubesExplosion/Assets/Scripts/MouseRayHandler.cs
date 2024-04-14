using System;
using UnityEngine;

public class MouseRayHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private Ray _ray;

    public event Action CubeChanged;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction *100f, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<Cube>())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.collider.gameObject);
                    CubeChanged?.Invoke();
                    Debug.Log("Oy eee");
                }
            }
        }
    }
}
using System;
using UnityEngine;

public class MouseRayHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private Ray _ray;

    public event Action<Cube> CubeChanged;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube hittedCube))
            {
                if (Input.GetMouseButtonDown(0))
                {   
                    CubeChanged?.Invoke(hittedCube);
                }
            }
        }
    }
}
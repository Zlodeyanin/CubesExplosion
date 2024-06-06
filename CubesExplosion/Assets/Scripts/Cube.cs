using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ShareChanse { get; private set; }

    private void FixedUpdate()
    {
        ShareChanse = gameObject.transform.localScale.x;
    }
}
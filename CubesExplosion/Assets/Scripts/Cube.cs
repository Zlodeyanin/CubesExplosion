using UnityEngine;

public class Cube : MonoBehaviour
{
    public int ShareChanse { get; private set; } = 100;

    public void ReduceShareChanse()
    {
        ShareChanse /= 2;
    }
}
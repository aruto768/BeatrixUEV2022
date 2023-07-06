using UnityEngine;

public class Spinner : MonoBehaviour
{
    [Range(1f, 1000f)]
    public float floatRange = 100f;

    public void Update()
    {
        transform.Rotate(0, 0, -floatRange * Time.deltaTime);
    }
}

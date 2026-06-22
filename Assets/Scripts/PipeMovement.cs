using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(-3,0,0);
    }

}

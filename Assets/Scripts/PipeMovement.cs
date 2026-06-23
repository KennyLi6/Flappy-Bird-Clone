using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = .25f;
    [SerializeField] private float _despawnTime = 3.5f;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(-_moveSpeed,0,0);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_despawnTime);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}

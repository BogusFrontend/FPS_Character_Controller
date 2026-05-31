using System.Collections;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action<Vector3> Collected;
    
    [SerializeField] private float shrinkTime = 0.3f;
    private bool _collected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_collected) return;
        if (other.CompareTag("Player"))
        {
            _collected = true;
            
            Collected?.Invoke(other.transform.position);
            
            StartCoroutine(ShrinkAndDestroy());
        }
    }
    
    private IEnumerator ShrinkAndDestroy()
    {
        Vector3 startScale = transform.localScale;
        float t = 0f;

        while (t < shrinkTime)
        {
            t += Time.deltaTime;
            transform.localScale = startScale * (1f - t / shrinkTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}

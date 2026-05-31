using UnityEngine;

public class PhysicsMover : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    
    private Rigidbody _rb;
    private float _h, _v;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _v = Input.GetAxis("Vertical");
        _h = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_h, 0f, _v);
        _rb.AddForce(direction * force);
    }
}

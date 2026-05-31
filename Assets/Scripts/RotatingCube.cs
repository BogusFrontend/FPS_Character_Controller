using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float rotationSpeed = 90f;

    private void Awake()
    {
        Debug.Log("Awake: объект проснулся");
    }

    private void Start()
    {
        Debug.Log("Start: первый кадр вот-вот начнётся");
    }

    private void Update()
    {
        /*
         *  Time.deltaTime - это время в секундах, прошедшее с момента завершения отрисовки предыдущего кадра.
         *  Ключевое: Скорость игры станет одинаковой на любых устройствах, слабых и мощных ПК.
        */
        
        // Vector3.up = (1, 0, 0) - ось Y.
        transform.Rotate(Vector3.right * (rotationSpeed * Time.deltaTime));
        
        // Vector3.up = (0, 1, 0) - ось Y.
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        
        // Vector3.up = (0, 0, 1) - ось Z.
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}

using UnityEngine;

public class RotationNazi : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float rotationSpeed = 90f;

    private void Update()
    {
        /*
         *  Time.deltaTime - это время в секундах, прошедшее с момента завершения отрисовки предыдущего кадра.
         *  Ключевое: Скорость игры станет одинаковой на любых устройствах, слабых и мощных ПК.
         */
        
        // Vector3.back = (0, 0, -1) - ось Z.
        transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
    }
}

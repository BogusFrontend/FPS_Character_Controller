using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
     
        /*
         * GetAxis возвращает число от -1 до 1
         * "Horizontal" = A/D и стрелки влево/вправо
         * "Vertical"   = W/S и стрелки вниз/вверх
        */
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        /*
         *  Направление
         *  X - влево/вправо, Z - вперёд/назад, (Y не трогаем - это высота)
         *  normalized - чтобы диагонали не двигаться быстрее
        */
        
        //                              x   y  z
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        
        // Двигаем объект
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
    }
}

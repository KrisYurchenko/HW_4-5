using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField] private float force = 11;
        [SerializeField] private float damage = 1;
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private Transform shootPoint;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                {
                    print(hit.transform.gameObject.name);

                    Instantiate(impactPrefab, hit.point,Quaternion.LookRotation(hit.normal,Vector3.up));

                    var destructible = hit.transform.GetComponent<DestructibleObject>();
                    if (destructible != null)
                    {
                        destructible.ReceiveDamage(damage);
                    }

                    var rigidbody = hit.transform.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                    }
                }
            }
        }
        // Юнити метод, который рисует графику для редактора
        // в нём можно обращаться к классу Gizmos
        // Так же вызвается на каждом кадре, даже когда игра не запущена
        private void OnDrawGizmos()
        {
            // Выставляем красный цвет
            Gizmos.color = Color.red;
            
            // Рисуем луч, идущий из позиции нашего объекта shootPoint, направленный в shootPoint.forward
            // длина луча 9999 метров
            Gizmos.DrawRay(shootPoint.position, shootPoint.forward * 9999);
        }
    }
}
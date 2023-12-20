using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    // Метод для вимкнення колайдера на певний час
    public void DisableCollider()
    {
        // Запускаємо корутину
        StartCoroutine(DisableColliderCoroutine());
    }

    // Корутина для вимкнення колайдера на певний час
    private IEnumerator DisableColliderCoroutine()
    {
        // Вимкнення колайдера
        _boxCollider.enabled = false;

        // Очікування 3 секунд
        yield return new WaitForSeconds(3f);

        // Увімкнення колайдера
        _boxCollider.enabled = true;
    }
    public void EnableСollider()
    {
        // Увімкнення колайдера
        _boxCollider.enabled = true;
    }
}




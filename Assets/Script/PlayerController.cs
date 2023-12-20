using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;   // Зовнішній компонент для керування рухом гравця
    [SerializeField] private Vector3 _greenZone;    // Позначення місця, куди гравець буде рухатися
    [SerializeField] private Animator _animator;    // Аніматор для керування анімаціями гравця
    private Vector3 _initialPosition; // Початкова позиція гравця
    private bool _isDead = false;      // Прапорець, що позначає смерть гравця

    // Метод, який викликається при старті гри
    private void Start()
    {
        // Запам'ятовуємо початкову позицію гравця
        _initialPosition = transform.position;

        // Запускаємо таймер для виклику методу PlayerMove через 2 секунди
        Invoke("PlayerMove", 2f);
    }

    // Метод для переміщення гравця до визначеної точки
    private void PlayerMove()
    {
        // Встановлюємо точку призначення для NavMeshAgent
        _agent.SetDestination(_greenZone);
    }

    // Метод, який викликається при зіткненні гравця з іншим об'єктом
    private void OnCollisionEnter(Collision other)
    {
        // Перевіряємо, чи зіткнулися з червоною зоною
        if (other.gameObject.CompareTag("RedZone") && !_isDead)
        {
            // Встановлюємо прапорець смерті
            _isDead = true;

            // Відтворюємо анімацію смерті гравця
            _animator.Play("PlayerDeath");

            // Викликаємо метод Death через 0.7 секунди
            Invoke("Death", 0.7f);
        }
        else if (other.gameObject.CompareTag("GreenZone"))
        {
            _animator.Play("PlayerWin");
            StartCoroutine(ReloadSceneAfterAnimation());
        }
    }
    private IEnumerator ReloadSceneAfterAnimation()
    {
        // Очікування часу, необхідного для відтворення анімації "PlayerWin"
        yield return new WaitForSeconds(1);

        // Перезавантаження сцени
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Метод для смерті гравця
    private void Death()
    {
        // Вимикаємо GameObject гравця
        gameObject.SetActive(false);

        // Переміщаємо гравця на початкову позицію
        transform.position = _initialPosition;

        // Включаємо GameObject гравця
        gameObject.SetActive(true);

        // Знуляємо прапорець смерті
        _isDead = false;

        // Запускаємо PlayerMove після респавну
        PlayerMove();
    }
}

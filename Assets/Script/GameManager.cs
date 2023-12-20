using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Змінна, що вказує на об'єкт гравця
    [SerializeField] private GameObject _player;

    // Змінна для отримання компонента Renderer гравця
    private Renderer _playerRender;

    private void Start()
    {
        // Отримання посилання на компонент Renderer при запуску гри
        _playerRender = _player.GetComponent<Renderer>();
    }

    // Метод, що встановлює зелений колір для функції щита гравця
    public void ShieldGreen()
    {
        _playerRender.material.color = new Color(0.1333333f, 0.5450981f, 0.1333333f);
    }

    // Метод, що встановлює жовтий колір для функції щита гравця
    public void ShieldYellow()
    {
        _playerRender.material.color = new Color(1f, 1f, 0f);
    }

    // Метод для виходу з гри
    public void Exit()
    {
        Application.Quit();
    }
}

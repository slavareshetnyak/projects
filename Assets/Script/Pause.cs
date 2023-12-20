using UnityEngine;

public class Pause : MonoBehaviour
{
    // Посилання на об'єкт канвасу гравця
    [SerializeField] private GameObject _playerCanvas;

    // Посилання на об'єкт панелі паузи
    [SerializeField] private GameObject _pausaPanel;

    // Метод-обробник для активації паузи
    public void PausaHandler()
    {
        // Зупинка часу гри при активації паузи
        Time.timeScale = 0f;

        // Активація панелі паузи
        _pausaPanel.SetActive(true);
    }
}

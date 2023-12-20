using UnityEngine;

public class EndPause : MonoBehaviour
{
    // Посилання на об'єкт канвасу для паузи
    [SerializeField] private GameObject _pausaCanvas;

    // Посилання на об'єкт панелі паузи
    [SerializeField] private GameObject _pausaPanel;

    // Метод-обробник для завершення паузи
    public void EndPausaHandler()
    {
        // Відновлення часу гри після паузи
        Time.timeScale = 1;

        // Вимкнення панелі паузи
        _pausaPanel.SetActive(false);
    }
}

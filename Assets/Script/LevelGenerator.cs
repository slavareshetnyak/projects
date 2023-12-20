using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Розміри рівня
    [SerializeField] private int width = 13;
    [SerializeField] private int height = 13;

    // Префаби об'єктів для генерації
    [SerializeField] private GameObject wall;     // Префаб стіни
    [SerializeField] private GameObject redZone;  // Префаб червоної зони

    // Метод, який викликається при старті гри
    private void Start()
    {
        // Генерація рівня
        GenerateLevel();
    }

    // Метод для генерації рівня
    private void GenerateLevel()
    {
        // Перебираємо координати рівня
        for (int x = 1; x < width; x += 2)
        {
            for (int y = 1; y < height; y += 2)
            {
                // Якщо випадкове значення більше 0.1, генеруємо об'єкт
                if (Random.value > 0.1f)
                {
                    // Визначаємо позицію об'єкта
                    Vector3 pos = new Vector3(x - width / 2f, -0.029f, y - height / 2f);

                    // Визначаємо, який об'єкт генерувати: стіну чи червону зону
                    GameObject prefabToInstantiate = (Random.value > 0.2f) ? wall : redZone;

                    // Рандомно визначаємо кут повороту (0 або 90 градусів)
                    Quaternion rotation = Quaternion.Euler(0f, (Random.Range(0, 2) * 90f), 0f);

                    // Інстанціюємо об'єкт із заданою позицією та кутом повороту
                    GameObject instantiatedObject = Instantiate(prefabToInstantiate, pos, rotation);

                    // Встановлюємо батьківський об'єкт, щоб утримувати порядок в ієрархії сцени
                    instantiatedObject.transform.parent = transform;
                }
            }
        }
    }
}

using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // ������ ����
    [SerializeField] private int width = 13;
    [SerializeField] private int height = 13;

    // ������� ��'���� ��� ���������
    [SerializeField] private GameObject wall;     // ������ ����
    [SerializeField] private GameObject redZone;  // ������ ������� ����

    // �����, ���� ����������� ��� ����� ���
    private void Start()
    {
        // ��������� ����
        GenerateLevel();
    }

    // ����� ��� ��������� ����
    private void GenerateLevel()
    {
        // ���������� ���������� ����
        for (int x = 1; x < width; x += 2)
        {
            for (int y = 1; y < height; y += 2)
            {
                // ���� ��������� �������� ����� 0.1, �������� ��'���
                if (Random.value > 0.1f)
                {
                    // ��������� ������� ��'����
                    Vector3 pos = new Vector3(x - width / 2f, -0.029f, y - height / 2f);

                    // ���������, ���� ��'��� ����������: ���� �� ������� ����
                    GameObject prefabToInstantiate = (Random.value > 0.2f) ? wall : redZone;

                    // �������� ��������� ��� �������� (0 ��� 90 �������)
                    Quaternion rotation = Quaternion.Euler(0f, (Random.Range(0, 2) * 90f), 0f);

                    // ������������ ��'��� �� ������� �������� �� ����� ��������
                    GameObject instantiatedObject = Instantiate(prefabToInstantiate, pos, rotation);

                    // ������������ ����������� ��'���, ��� ���������� ������� � �������� �����
                    instantiatedObject.transform.parent = transform;
                }
            }
        }
    }
}

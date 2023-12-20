using UnityEngine;

public class Pause : MonoBehaviour
{
    // ��������� �� ��'��� ������� ������
    [SerializeField] private GameObject _playerCanvas;

    // ��������� �� ��'��� ����� �����
    [SerializeField] private GameObject _pausaPanel;

    // �����-�������� ��� ��������� �����
    public void PausaHandler()
    {
        // ������� ���� ��� ��� ��������� �����
        Time.timeScale = 0f;

        // ��������� ����� �����
        _pausaPanel.SetActive(true);
    }
}

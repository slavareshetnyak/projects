using UnityEngine;

public class EndPause : MonoBehaviour
{
    // ��������� �� ��'��� ������� ��� �����
    [SerializeField] private GameObject _pausaCanvas;

    // ��������� �� ��'��� ����� �����
    [SerializeField] private GameObject _pausaPanel;

    // �����-�������� ��� ���������� �����
    public void EndPausaHandler()
    {
        // ³��������� ���� ��� ���� �����
        Time.timeScale = 1;

        // ��������� ����� �����
        _pausaPanel.SetActive(false);
    }
}

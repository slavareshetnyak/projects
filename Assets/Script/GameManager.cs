using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �����, �� ����� �� ��'��� ������
    [SerializeField] private GameObject _player;

    // ����� ��� ��������� ���������� Renderer ������
    private Renderer _playerRender;

    private void Start()
    {
        // ��������� ��������� �� ��������� Renderer ��� ������� ���
        _playerRender = _player.GetComponent<Renderer>();
    }

    // �����, �� ���������� ������� ���� ��� ������� ���� ������
    public void ShieldGreen()
    {
        _playerRender.material.color = new Color(0.1333333f, 0.5450981f, 0.1333333f);
    }

    // �����, �� ���������� ������ ���� ��� ������� ���� ������
    public void ShieldYellow()
    {
        _playerRender.material.color = new Color(1f, 1f, 0f);
    }

    // ����� ��� ������ � ���
    public void Exit()
    {
        Application.Quit();
    }
}

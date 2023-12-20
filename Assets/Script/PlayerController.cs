using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;   // ������� ��������� ��� ��������� ����� ������
    [SerializeField] private Vector3 _greenZone;    // ���������� ����, ���� ������� ���� ��������
    [SerializeField] private Animator _animator;    // ������� ��� ��������� ��������� ������
    private Vector3 _initialPosition; // ��������� ������� ������
    private bool _isDead = false;      // ���������, �� ������� ������ ������

    // �����, ���� ����������� ��� ����� ���
    private void Start()
    {
        // �����'������� ��������� ������� ������
        _initialPosition = transform.position;

        // ��������� ������ ��� ������� ������ PlayerMove ����� 2 �������
        Invoke("PlayerMove", 2f);
    }

    // ����� ��� ���������� ������ �� ��������� �����
    private void PlayerMove()
    {
        // ������������ ����� ����������� ��� NavMeshAgent
        _agent.SetDestination(_greenZone);
    }

    // �����, ���� ����������� ��� ������� ������ � ����� ��'�����
    private void OnCollisionEnter(Collision other)
    {
        // ����������, �� ��������� � �������� �����
        if (other.gameObject.CompareTag("RedZone") && !_isDead)
        {
            // ������������ ��������� �����
            _isDead = true;

            // ³��������� ������� ����� ������
            _animator.Play("PlayerDeath");

            // ��������� ����� Death ����� 0.7 �������
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
        // ���������� ����, ����������� ��� ���������� ������� "PlayerWin"
        yield return new WaitForSeconds(1);

        // ���������������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ����� ��� ����� ������
    private void Death()
    {
        // �������� GameObject ������
        gameObject.SetActive(false);

        // ��������� ������ �� ��������� �������
        transform.position = _initialPosition;

        // �������� GameObject ������
        gameObject.SetActive(true);

        // �������� ��������� �����
        _isDead = false;

        // ��������� PlayerMove ���� ��������
        PlayerMove();
    }
}

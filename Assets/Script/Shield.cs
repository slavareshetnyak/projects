using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    // ����� ��� ��������� ��������� �� ������ ���
    public void DisableCollider()
    {
        // ��������� ��������
        StartCoroutine(DisableColliderCoroutine());
    }

    // �������� ��� ��������� ��������� �� ������ ���
    private IEnumerator DisableColliderCoroutine()
    {
        // ��������� ���������
        _boxCollider.enabled = false;

        // ���������� 3 ������
        yield return new WaitForSeconds(3f);

        // ��������� ���������
        _boxCollider.enabled = true;
    }
    public void Enable�ollider()
    {
        // ��������� ���������
        _boxCollider.enabled = true;
    }
}




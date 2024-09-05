using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject ui; //EŰ��������ȣ�ۿ� ��¼�� ���ִ°�
    public Animator doorAnimator;   // �� �ִϸ����� 
    private bool isPlayerNearby = false;  // �÷��̾ Ʈ���� �ȿ� �ִ��� ����
    private bool isDoorOpen = false; // ���� �����ִ��� ����
    public AudioSource audioSource;  // �� ������ �Ҹ�

    void Start () 
    {
        ui.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) // Ʈ���� ������ ���� �� ����Ǵ� �Լ�
    {
        // �÷��̾ �ݶ��̴��� ������
        if (other.CompareTag("Player"))
        {
            // UI Ȱ��ȭ
            ui.SetActive(true);
            // �÷��̾ Ʈ���� ������ �������� ǥ��
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other) // Ʈ���� ������ ������ �� ����Ǵ� �Լ�
    {
        // �÷��̾ �ݶ��̴����� ������
        if (other.CompareTag("Player"))
        {
            // UI ��Ȱ��ȭ
            ui.SetActive(false);
            // �÷��̾ Ʈ���� �������� �������� ǥ��
            isPlayerNearby = false;
        }
    }
    void Update()
    {
        // �÷��̾ Ʈ���� ���� �ȿ� �ְ�, E Ű�� ������ ��
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (isDoorOpen)
            {
                // ���� ���������� �ݱ�
                doorAnimator.SetTrigger("close");
                isDoorOpen = false; // �� ���¸� �������� ����
            }
            else
            {
                // ���� ���������� ����
                doorAnimator.SetTrigger("open");
                isDoorOpen = true; // �� ���¸� �������� ����
            }

            // �� ������/������ �Ҹ� ���
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("����� ���");
            }
        }
    }

}

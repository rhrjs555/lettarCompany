using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject ui; //EŰ��������ȣ�ۿ� ��¼�� ���ִ°�
    public Animator doorAnimator;   // �� �ִϸ����� 
    private bool isPlayerNearby = false;  // �÷��̾ Ʈ���� �ȿ� �ִ��� ����
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
            // �ִϸ������� "open" Ʈ���Ÿ� Ȱ��ȭ
            doorAnimator.SetTrigger("open");
        }
        // �� ������ �Ҹ� ���
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing door sound");
        }
    }
}

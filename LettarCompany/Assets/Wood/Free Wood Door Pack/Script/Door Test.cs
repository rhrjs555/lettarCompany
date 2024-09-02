using DoorScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // ������ ��ȣ�ۿ� ������ �Ÿ�
    //public LayerMask interactableLayer; // ���� ��ġ�� ���̾�
    public GameObject ui;
    private bool isPlayerClose = false;

    private void Update()
    {
        // E Ű �Է� üũ
        if (isPlayerClose)
        {
            ui.SetActive(true);
            /*
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*
                // �÷��̾���� �Ÿ��� ����Ͽ� ��ȣ�ۿ� �������� Ȯ��
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayer))
                {
                    // ���� ��ȣ�ۿ�
                    Door door = hit.collider.GetComponent<Door>();
                    if (door != null)
                    {
                        door.Interact();
                    }
                }
               
               
            }*/
        }
        else
            ui.SetActive(false);
    }
    public class Door : MonoBehaviour
    {
        public void Interact()
        {
            // ���� ���� ���� ����
            // ���� ��� ���� �����ų� �������� �ִϸ��̼��� ����� �� �ֽ��ϴ�.
            Debug.Log("���� ��ȣ�ۿ��մϴ�.");
            // �� ���� �ִϸ��̼� �Ǵ� ���� ���� �ڵ� �߰�
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            isPlayerClose = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isPlayerClose = false;
    }
}



using DoorScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // 문과의 상호작용 가능한 거리
    //public LayerMask interactableLayer; // 문이 위치한 레이어
    public GameObject ui;
    private bool isPlayerClose = false;

    private void Update()
    {
        // E 키 입력 체크
        if (isPlayerClose)
        {
            ui.SetActive(true);
            /*
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*
                // 플레이어와의 거리를 계산하여 상호작용 가능한지 확인
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayer))
                {
                    // 문과 상호작용
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
            // 문을 여는 동작 구현
            // 예를 들어 문이 열리거나 닫히도록 애니메이션을 재생할 수 있습니다.
            Debug.Log("문과 상호작용합니다.");
            // 문 열기 애니메이션 또는 상태 변경 코드 추가
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



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject ui; //E키를눌러상호작용 어쩌고 써있는거
    public Animator doorAnimator;   // 문 애니메이터 
    private bool isPlayerNearby = false;  // 플레이어가 트리거 안에 있는지 여부
    public AudioSource audioSource;  // 문 열리는 소리

    void Start () 
    {
        ui.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) // 트리거 영역에 들어갔을 때 실행되는 함수
    {
        // 플레이어가 콜라이더에 들어오면
        if (other.CompareTag("Player"))
        {
            // UI 활성화
            ui.SetActive(true);
            // 플레이어가 트리거 영역에 들어왔음을 표시
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other) // 트리거 영역을 나갔을 때 실행되는 함수
    {
        // 플레이어가 콜라이더에서 나가면
        if (other.CompareTag("Player"))
        {
            // UI 비활성화
            ui.SetActive(false);
            // 플레이어가 트리거 영역에서 나갔음을 표시
            isPlayerNearby = false;
        }
    }
    void Update()
    {
        // 플레이어가 트리거 영역 안에 있고, E 키를 눌렀을 때
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // 애니메이터의 "open" 트리거를 활성화
            doorAnimator.SetTrigger("open");
        }
        // 문 열리는 소리 재생
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing door sound");
        }
    }
}

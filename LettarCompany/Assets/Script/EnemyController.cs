using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // 플레이어의 위치를 참조하기 위한 변수
    public float sightRange = 10f; // 적의 시야 범위
    public float viewAngle = 60f; // 적의 시야각
    public float loseSightRange = 15f; // 적이 플레이어를 잃는 범위
    public Animator enemyAnimator; // 적의 애니메이터
    private bool isSpotted = false; // 플레이어가 발견되었는지 여부

    void Start()
    {
        // 초기화 시 애니메이터의 isSpotted를 false로 설정
        enemyAnimator.SetBool("isSpotted", false);
    }

    void Update()
    {
        // 적과 플레이어 사이의 거리를 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어가 시야 범위 내에 있을 때
        if (distanceToPlayer <= sightRange)
        {
            // 적이 플레이어를 바라보고 있는지 확인
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // 시야각 내에 있고 시야 범위 안에 있을 때
            if (angleBetweenEnemyAndPlayer <= viewAngle / 2f)
            {
                if (!isSpotted)
                {
                    // 플레이어가 발견되면 애니메이터의 isSpotted를 true로 설정
                    isSpotted = true;
                    enemyAnimator.SetBool("isSpotted", true);
                }

                // 플레이어를 바라보도록 회전
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);  
            }
           
        }
        // 플레이어가 일정 거리 이상 멀어졌을 때
        else if (isSpotted && distanceToPlayer > loseSightRange)
        {
            // 플레이어가 범위를 벗어나면 isSpotted를 false로 설정
            isSpotted = false;
            enemyAnimator.SetBool("isSpotted", false);
        }
    }
}

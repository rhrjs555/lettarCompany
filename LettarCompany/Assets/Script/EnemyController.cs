using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    public float sightRange = 10f; // ���� �þ� ����
    public float viewAngle = 60f; // ���� �þ߰�
    public float loseSightRange = 15f; // ���� �÷��̾ �Ҵ� ����
    public Animator enemyAnimator; // ���� �ִϸ�����
    private bool isSpotted = false; // �÷��̾ �߰ߵǾ����� ����

    void Start()
    {
        // �ʱ�ȭ �� �ִϸ������� isSpotted�� false�� ����
        enemyAnimator.SetBool("isSpotted", false);
    }

    void Update()
    {
        // ���� �÷��̾� ������ �Ÿ��� ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �÷��̾ �þ� ���� ���� ���� ��
        if (distanceToPlayer <= sightRange)
        {
            // ���� �÷��̾ �ٶ󺸰� �ִ��� Ȯ��
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleBetweenEnemyAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // �þ߰� ���� �ְ� �þ� ���� �ȿ� ���� ��
            if (angleBetweenEnemyAndPlayer <= viewAngle / 2f)
            {
                if (!isSpotted)
                {
                    // �÷��̾ �߰ߵǸ� �ִϸ������� isSpotted�� true�� ����
                    isSpotted = true;
                    enemyAnimator.SetBool("isSpotted", true);
                }

                // �÷��̾ �ٶ󺸵��� ȸ��
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);  
            }
           
        }
        // �÷��̾ ���� �Ÿ� �̻� �־����� ��
        else if (isSpotted && distanceToPlayer > loseSightRange)
        {
            // �÷��̾ ������ ����� isSpotted�� false�� ����
            isSpotted = false;
            enemyAnimator.SetBool("isSpotted", false);
        }
    }
}

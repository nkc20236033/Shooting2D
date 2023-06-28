using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 10f;             // �e���x
        Destroy(gameObject, 2f); // �����Q�b
    }

    void Update()
    {
        // �ړ�
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // �d�Ȃ蔻��
    void OnTriggerEnter2D(Collider2D c)
    {
        
            // �������Ă����I�u�W�F�N�g��Tag���ubullet�v��������
            if (c.tag == "enemy")
            {
                Destroy(c.gameObject);  // �������Ă����I�u�W�F�N�g���폜
                Destroy(gameObject);    // �������g���폜
            }
        
    }
}


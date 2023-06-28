using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshot : MonoBehaviour
{
    Vector3 dir;        // �ړ�����
    float speed;        // �ړ����x
    gamedirec gd;    // GameDirector�R���|�[�l���g�ۑ�
    Transform player;   // �v���[���[�̃g�����X�t�H�[���R���|�[�l���g��ۑ�

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("tomato").transform;

        speed = 12f;

        dir = player.position - transform.position;
       
        gd = GameObject.Find("gamedirec").GetComponent<gamedirec>();

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag == "player")
        {
            gamedirec.kyori -= 500;
            Destroy(gameObject);
        }
    }
}

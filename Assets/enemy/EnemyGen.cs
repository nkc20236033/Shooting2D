using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    public GameObject enemyPre;
    float delta = 0;

    float span = 1f;
    
    void Update()
    {
        //�o�ߎ��Ԃ����Z
        delta += Time.deltaTime;


        //�G�𐶐�
        if (delta>span)
        {//���Ԍo�߂�ۑ����Ă���ϐ����O�ɂ���
            delta = 0;
            //�G�̏o���Ԋu��Z������
            span -= (span > 0.5f) ? 0.01f : 0f;
            GameObject go = Instantiate(enemyPre);
            float ey = Random.Range(-5f, 5f);
            go.transform.position = new Vector3(10, ey, 0);
            
        }
    }
}

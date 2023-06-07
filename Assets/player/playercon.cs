using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playercon : MonoBehaviour
{Vector3 dir = Vector3.zero;//�ړ�������ۑ�

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized  *  speed * Time.deltaTime;
        //��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;


        //�A�j���[�V�����̐ݒ�
        if(dir.y==0) 
        {
            anim.Play("player");
        }
        else if (dir.y==1) 
        {
            anim.Play("playerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("playerR");
        }


    }
}

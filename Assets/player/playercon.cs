using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class playercon : MonoBehaviour
{
    float speed = 20f;
    Vector3 dir = Vector3.zero; // �ړ�������ۑ�����ϐ�

    Animator anim;// �A�j���[�^�[�R���|�[�l���g�̏���ۑ�����ϐ�
    public GameObject shot;
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
    }

    void Update()
    {


        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // �A�j���[�V�����ݒ�
        if (dir.y == 0)
        {
            // �A�j���[�V�����N���b�v�yPlayer�z���Đ�
            anim.Play("player");
        }
        else if (dir.y == 1)
        {
            anim.Play("playerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("playerR");
        }
        float g = 0;
        g += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z)&& 0.8>= g)
        {
            GameObject go = Instantiate(shot);
            go.transform.position = new Vector3((pos.x + 0.01f), (pos.y+1f), 0);
            go.transform.Translate(1, 0, 0);
        }
    }
}

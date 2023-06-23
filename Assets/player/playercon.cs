using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class playercon : MonoBehaviour
{
    float speed = 20f;          //�ړ����x�ۑ�
    Vector3 dir = Vector3.zero; // �ړ������ۑ�
    float timer;    // ���e�̔��ˊԊu�v�Z�p
    Animator anim;// �A�j���[�^�[�R���|�[�l���g�̏���ۑ�����ϐ�
    public GameObject shot;

    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 1, 20);
        }
        get { return speed; }
    }

    int shotLevel;  // ����̃��x��
    public int ShotLevel
    {
        set
        {
            shotLevel = value;
            shotLevel = Mathf.Clamp(shotLevel, 0, 12);
        }
        get { return shotLevel; }
    }
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
        shotLevel = 0;  // �e���x��
        timer = 0;  // ���ԏ�����
        speed = 10; // �����X�s�[�h   
    }

    void Update()
    {


        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.C)) 
        {
        shotLevel =(shotLevel + 1)%13;
        }
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;
            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // �e�̐����ʒu�̓v���[���[�Ɠ����ꏊ
                Vector3 p = transform.position;

                // �v���[���[�̉�]�p�x���擾���A15�x�����炵�������ɒe����]������
                //Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                //Quaternion rot = Quaternion.Euler(r);
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // �ʒu�Ɖ�]�����Z�b�g���Đ���
                Instantiate(shot, p, rot);
            }
        }

        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        
       
    }
}

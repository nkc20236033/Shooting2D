using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    AudioSource audioSouce; //�I�[�f�B�I�\�[�X�R���|�[�l���g��ۑ�
    AudioClip audioClip;�@�@//�I�[�f�B�I�N���b�v��ۑ�
    // Start is called before the first frame update
    void Start()
    {



        //�I�[�f�B�I�\�[�X�R���|�[�l���g�̏����擾
        audioSouce = GetComponent<AudioSource>();

        audioSouce.clip = audioClip;
        //�I�[�f�B�I�\�[�X�ɓo�^����Ă���I�[�f�B�I�N���b�v���Đ�����
        audioSouce.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

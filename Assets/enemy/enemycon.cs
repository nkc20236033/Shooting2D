using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycon : MonoBehaviour
{ 
    public GameObject ExploPre; // �����̃v���n�u��ۑ�
    public GameObject ShotPre;  // �e�̃v���n�u��ۑ�
    // speed 3~7                // �ړ����x��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 2f;    // �e�̔��ˊԊu
    AudioClip seClip;
    Vector3 sepos;
    AudioSource audioSouce; //�I�[�f�B�I�\�[�X�R���|�[�l���g��ۑ�
    AudioClip audioClip;�@�@//�I�[�f�B�I�N���b�v��ۑ�
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,6);
        enemyType = Random .Range(0,3);
        
        dir = Vector3.left;
        rad = Time.time;
        shotTime = 0;

        seClip = audioClip = Resources.Load<AudioClip>("bomb");
        sepos = new Vector3(0, 0, -10);


    }

    // Update is called once per frame
    void Update()
    {
       if(enemyType == 0)
        {
            
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }
        //�ړ�����
        transform.position += dir.normalized *  Random.Range(3, 7) * Time.deltaTime;

        //�G�e����
        shotTime += Time.deltaTime;
        if(shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }
        void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "player")
        {
            gamedirec.kyori -= 1000;

            AudioSource.PlayClipAtPoint(seClip, sepos);
            Instantiate(ExploPre, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (c.tag == "shot")
        {
            // �����𑝂₷
            gamedirec.kyori += 200;

            // �d�Ȃ������肪�Փ˔����𐶐�
            AudioSource.PlayClipAtPoint(seClip, sepos);
            Instantiate(ExploPre, transform.position, transform.rotation);
            // �����i�G�j�폜
            Destroy(gameObject);
        }
    }
}

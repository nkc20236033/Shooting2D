using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamedirec : MonoBehaviour
{
    public Text kyoriLabel;//������\������UI-Text�I�u�W�F�N�g
    public static int kyori;             // ������ۑ�
    public static float LastTime;�@�@�@�@//�c�莞�Ԃ�ۑ�
    public Image timegauge;//�^�C���Q�[�W��\��
    // Start is called before the first frame update

    public Text shotLabel;  // �e�̋����\���e�L�X�g�I�u�W�F�N�g�ۑ�

    public GameObject itemPre; // �A�C�e���v���n�u�ۑ�

    // �v���[���[�R���g���[���[�R���|�[�l���g�ۑ�
    playercon PC;

    // �c�莞�Ԃ𑼂̃X�N���v�g����ύX���邽�߂̐錾 public static
    public static float lastTime;
    


    void Start()
    {
        kyori = 0;
        LastTime = 100f;//�c�莞��10�O�b
        PC = GameObject.Find("tomato").GetComponent<playercon>();
    }

    // Update is called once per frame
    void Update()
    {
        int s = PC.ShotLevel;
        shotLabel.text = "ShotLv" + s;
        kyori++;
        if(kyori<0)kyori = 0;
        kyoriLabel.text = "�l���_" + kyori.ToString("D6") + "Pt";
        //�c�莞�Ԃ����炷����
        LastTime -= Time.deltaTime;
        timegauge.fillAmount = LastTime/100f;
        //�c�莞�Ԃ�0�ɂȂ�����EndingScence��
        if (LastTime < 0)
        {
            SceneManager.LoadScene(2);
        }
        // ������600km�Ŋ���؂��Ƃ��ɃA�C�e���o��
        if (kyori % 600.0f == 0)
        {
            Instantiate(itemPre);
        }

       
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    //�A�j���[�V�����̂��߂̃R���|�[�l���g
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������
    Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu
    private float groundLebel = -3.0f;

    //�W�����v�̑��x�̌���
    private float dump = 0.8f;

    //�W�����v�̑��x
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //�A�j���[�^�̃R���|�[�l���g���擾
        this.animator = GetComponent<Animator>();

        //Rigidbody2D�̃R���|�[�l���g���擾
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //����A�j���[�V�����̍Đ��p�AAnimator�̃p�����[�^�𒲐�
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩���ׂ�
        bool isGround = (transform.position.y > this.groundLebel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //�W�����v��Ԃ̎��̓{�����[����0�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        
        //���n��ԂŃN���b�N���ꂽ�ꍇ
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //������̗͂�������
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //�N���b�N����߂��������ւ̑��x����������
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if(transform.position.x < this.deadLine)
        {
            //UIContoller��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGame Over�v�ƕ\��
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unity������j������
            Destroy(gameObject);
        }
    }
}

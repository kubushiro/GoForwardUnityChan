using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    //�L���[�u��Prefab
    public GameObject cubePrefab;

    //���Ԍv���p�̕ϐ�
    private float delta = 0;

    //�L���[�u�̐����Ԋu
    private float span = 1.0f;

    //�L���[�u�̐����ʒu�FX���W
    private float genPosX = 12;

    //�L���[�u�̐����ʒu�I�t�Z�b�g�FY
    private float offsetY = 0.3f;

    //�L���[�u�̏c�����̊Ԋu
    private float spaceY = 6.9f;

    //�L���[�u�̐����ʒu�I�t�Z�b�g�FX
    private float offsetX = 0.5f;

    //�L���[�u�̉������̊Ԋu
    private float spaceX = 0.4f;

    //�L���[�u�̐������̏��
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //�o�ߎ���
        this.delta += Time.deltaTime;
        
        //span�b�ȏ�̎��Ԃ��o�߂��������ׂ�
        if(this.delta > this.span)
        {
            //�o�ߎ��Ԃ̏�����
            this.delta = 0;

            //��������L���[�u�������_���Ō���
            int n = Random.Range(1, maxBlockNum + 1);

            //�L���[�u�̐���
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }

            //���̃L���[�u�܂ł̐������Ԃ̌���
            this.span = this.offsetX + this.spaceX * n;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cube")
        {
            GetComponent<AudioSource>().Play();
        }
        if(collision.gameObject.name == "ground")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
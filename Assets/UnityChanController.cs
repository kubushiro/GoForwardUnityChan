using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    //アニメーションのためのコンポーネント
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLebel = -3.0f;

    //ジャンプの速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //アニメータのコンポーネントを取得
        this.animator = GetComponent<Animator>();

        //Rigidbody2Dのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //走るアニメーションの再生用、Animatorのパラメータを調整
        this.animator.SetFloat("Horizontal", 1);

        //着地しているか調べる
        bool isGround = (transform.position.y > this.groundLebel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態の時はボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        
        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速する
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デッドラインを超えた場合ゲームオーバーにする
        if(transform.position.x < this.deadLine)
        {
            //UIContollerのGameOver関数を呼び出して画面上に「Game Over」と表示
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unityちゃんを破棄する
            Destroy(gameObject);
        }
    }
}

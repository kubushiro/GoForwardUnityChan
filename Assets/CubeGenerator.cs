using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    //キューブのPrefab
    public GameObject cubePrefab;

    //時間計測用の変数
    private float delta = 0;

    //キューブの生成間隔
    private float span = 1.0f;

    //キューブの生成位置：X座標
    private float genPosX = 12;

    //キューブの生成位置オフセット：Y
    private float offsetY = 0.3f;

    //キューブの縦方向の間隔
    private float spaceY = 6.9f;

    //キューブの生成位置オフセット：X
    private float offsetX = 0.5f;

    //キューブの横方向の間隔
    private float spaceX = 0.4f;

    //キューブの生成個数の上限
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //経過時間
        this.delta += Time.deltaTime;
        
        //span秒以上の時間が経過したか調べる
        if(this.delta > this.span)
        {
            //経過時間の初期化
            this.delta = 0;

            //生成するキューブをランダムで決定
            int n = Random.Range(1, maxBlockNum + 1);

            //キューブの生成
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }

            //次のキューブまでの生成時間の決定
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}

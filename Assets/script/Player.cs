using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;	// 移動速度
	public float JumpSpeed = 5.0f;	// ジャンプ速度
	public int JumpNumMax = 2;		// 最大多段ジャンプ回数

	private int jumpNum = 0;		// 現在のジャンプ回数（着地で０に戻る）

	// Start is called before the first frame update
    void Start()
    {
		// ジャンプ回数を０に
		jumpNum = 0;
    }
	
	// Update is called once per frame
	void Update()
	{
		// 左右押した？
		float x_input = Input.GetAxis("Horizontal");
		// ジャンプボタン押した？
		bool is_jump = Input.GetButtonDown("Jump");
		
		// 現在の速度を変数に入れる
		Vector2 next = GetComponent<Rigidbody2D>().velocity;

		// ジャンプボタン押された＆ジャンプ回数がまだ最大でないならジャンプ
		if (is_jump && jumpNum < JumpNumMax){
			// ジャンプは上に速度を
			next.y = 10.0f*JumpSpeed;
			// ジャンプ回数に１を足す
			jumpNum++;
		} else if (x_input > 0.2f){
			// 右に速度を
			next.x = 10.0f*MoveSpeed*x_input;
			// 絵を右に向ける
			GetComponent<SpriteRenderer>().flipX = false;
			// 走るアニメ再生
			GetComponent<Animator>().Play("run");
		} else if (x_input < -0.2f){
			// 左に速度を（x_inputがマイナスなので、左に動く）
			next.x = 10.0f*MoveSpeed*x_input;
			// 絵を左に向ける（反転させる）
			GetComponent<SpriteRenderer>().flipX = true;
			// 走るアニメ再生
			GetComponent<Animator>().Play("run");
		} else {
			// 横移動無し（横速度0に）
			next.x = 0.0f;
			// 待機アニメ再生
			GetComponent<Animator>().Play("wait");
		}
		// 新しい速度を実際に設定
	    GetComponent<Rigidbody2D>().velocity = next;
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		// 地面にぶつかったら、ジャンプ回数リセット
		//Debug.Log(other.tag);
		if(other.tag == "Hit")
			jumpNum = 0;
	}
}

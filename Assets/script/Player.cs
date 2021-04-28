using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;	// �ړ����x
	public float JumpSpeed = 5.0f;	// �W�����v���x
	public int JumpNumMax = 2;		// �ő命�i�W�����v��

	private int jumpNum = 0;		// ���݂̃W�����v�񐔁i���n�łO�ɖ߂�j

	// Start is called before the first frame update
    void Start()
    {
		// �W�����v�񐔂��O��
		jumpNum = 0;
    }
	
	// Update is called once per frame
	void Update()
	{
		// ���E�������H
		float x_input = Input.GetAxis("Horizontal");
		// �W�����v�{�^���������H
		bool is_jump = Input.GetButtonDown("Jump");
		
		// ���݂̑��x��ϐ��ɓ����
		Vector2 next = GetComponent<Rigidbody2D>().velocity;

		// �W�����v�{�^�������ꂽ���W�����v�񐔂��܂��ő�łȂ��Ȃ�W�����v
		if (is_jump && jumpNum < JumpNumMax){
			// �W�����v�͏�ɑ��x��
			next.y = 10.0f*JumpSpeed;
			// �W�����v�񐔂ɂP�𑫂�
			jumpNum++;
		} else if (x_input > 0.2f){
			// �E�ɑ��x��
			next.x = 10.0f*MoveSpeed*x_input;
			// �G���E�Ɍ�����
			GetComponent<SpriteRenderer>().flipX = false;
			// ����A�j���Đ�
			GetComponent<Animator>().Play("run");
		} else if (x_input < -0.2f){
			// ���ɑ��x���ix_input���}�C�i�X�Ȃ̂ŁA���ɓ����j
			next.x = 10.0f*MoveSpeed*x_input;
			// �G�����Ɍ�����i���]������j
			GetComponent<SpriteRenderer>().flipX = true;
			// ����A�j���Đ�
			GetComponent<Animator>().Play("run");
		} else {
			// ���ړ������i�����x0�Ɂj
			next.x = 0.0f;
			// �ҋ@�A�j���Đ�
			GetComponent<Animator>().Play("wait");
		}
		// �V�������x�����ۂɐݒ�
	    GetComponent<Rigidbody2D>().velocity = next;
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		// �n�ʂɂԂ�������A�W�����v�񐔃��Z�b�g
		//Debug.Log(other.tag);
		if(other.tag == "Hit")
			jumpNum = 0;
	}
}

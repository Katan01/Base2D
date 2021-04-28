using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
	public float MoveRange = 4.0f;      // ���E�ɂǂꂾ��������
	public float MoveSpeed = 2.0f;      // �ړ����x

	private float offsetX = 0.0f;       // ���݂̈ړ���
	private float moveDirec = 1.0f;     // �ړ������i1.0 or -1.0)
	private float startX;               // �ŏ��̈ʒu

	// Start is called before the first frame update
	void Start()
	{
		startX = transform.position.x;
	}
	// Update is called once per frame
	void Update()
	{
		float pass_sec = Time.deltaTime;
		offsetX += MoveSpeed*pass_sec*moveDirec;
		if(offsetX >= MoveRange)
			moveDirec = -1.0f;
		else if(offsetX <= -MoveRange)
			moveDirec = 1.0f;

		Vector3 new_pos = transform.position;
		new_pos.x = startX + offsetX;
		transform.position = new_pos;
	}
}

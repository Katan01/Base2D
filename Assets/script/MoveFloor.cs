using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
	public float MoveRange = 4.0f;      // 左右にどれだけ動くか
	public float MoveSpeed = 2.0f;      // 移動速度

	private float offsetX = 0.0f;       // 現在の移動量
	private float moveDirec = 1.0f;     // 移動方向（1.0 or -1.0)
	private float startX;               // 最初の位置

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

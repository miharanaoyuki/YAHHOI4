using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ƁA�ǂ�������
public class Forever_Chase : MonoBehaviour
{

	public string targetObjectName; // �ڕW�I�u�W�F�N�g���FInspector�Ŏw��
	public float speed = 1; // �X�s�[�h�FInspector�Ŏw��

	GameObject targetObject;
	Rigidbody2D rbody;

	void Start()
	{ // �ŏ��ɍs��
	  // �ڕW�I�u�W�F�N�g�������Ă���
		targetObject = GameObject.Find(targetObjectName);
		// �d�͂�0�ɂ��āA�Փˎ��ɉ�]�����Ȃ�
		rbody = GetComponent<Rigidbody2D>();
		rbody.gravityScale = 0;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void FixedUpdate()
	{ // �����ƍs���i��莞�Ԃ��ƂɁj
	  // �ڕW�I�u�W�F�N�g�̕����𒲂ׂ�
		Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
		// ���̕����֎w�肵���ʂŐi��
		float vx = dir.x * speed;
		float vy = dir.y * speed;
		rbody.velocity = new Vector2(vx, vy);
		// �ړ��̌����ō��E�Ɍ�����ς���
		this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
	}
}

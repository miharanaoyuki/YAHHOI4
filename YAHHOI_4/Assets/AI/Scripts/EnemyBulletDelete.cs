using UnityEngine;

public class EnemyBulletDelete : MonoBehaviour
{
    //���̃X�N���v�g�͓G�ɔ��˂�����e�ɕt����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�e���ꂽ�肵�Ă��A���Ȃ̂Ńg���K�[�i�������Z���s���Ȃ��j��
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�^�O���t���Ă���I�u�W�F�N�g�ɓ������������
            Destroy(this.gameObject);
        }
    }
}

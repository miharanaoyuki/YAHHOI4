using UnityEngine;

public class EnemyBulletDelete : MonoBehaviour
{
    //���̃X�N���v�g�͓G�ɔ��˂�����e�ɕt����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("Wall"))
        {
            //Player�^�O���t���Ă���I�u�W�F�N�g�ɓ������������
            Destroy(this.gameObject);
        }
    }
}

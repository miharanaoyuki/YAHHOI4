using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    bool Flag = true;
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�g���K�[�ɐG����
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //�t���O�𔽓]������
            Flag = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�R���W�����ɓ���������
        if (collision.gameObject.CompareTag("Enemy") && !Flag)
        {
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class BulletDelete : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�R���W�����ɓ���������
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //�J�����̊O�ɏo����폜
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}

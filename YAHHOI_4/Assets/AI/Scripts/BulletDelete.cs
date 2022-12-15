using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //トリガーに触れると
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
        //コリジョンに当たったら
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //カメラの外に出たら削除
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}

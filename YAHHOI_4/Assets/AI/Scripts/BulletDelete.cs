using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    bool Flag = true;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //フラグを反転させる
            Flag = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //コリジョンに当たったら
        if (collision.gameObject.CompareTag("Enemy") && !Flag)
        {
            Destroy(this.gameObject);
        }
    }
}

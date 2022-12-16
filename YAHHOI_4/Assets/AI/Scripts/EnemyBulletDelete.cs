using UnityEngine;

public class EnemyBulletDelete : MonoBehaviour
{
    //このスクリプトは敵に発射させる弾に付ける
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("Wall"))
        {
            //Playerタグが付いているオブジェクトに当たったら消す
            Destroy(this.gameObject);
        }
    }
}

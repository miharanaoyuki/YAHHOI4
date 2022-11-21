using UnityEngine;

public class EnemyBulletDelete : MonoBehaviour
{
    //このスクリプトは敵に発射させる弾に付ける
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //弾かれたりしてもアレなのでトリガー（物理演算が行われない）で
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerタグが付いているオブジェクトに当たったら消す
            Destroy(this.gameObject);
        }
    }
}

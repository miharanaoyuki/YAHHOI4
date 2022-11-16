using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMeG : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip destroySound;
    public int enemyHP;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall") ||
    //        collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵のHPを１ずつ減少させる
        enemyHP -= 1;

        // 敵のHPが０になったら敵オブジェクトを破壊する。
        if (enemyHP == 0)
        {
            if (collision.gameObject.CompareTag("Bullet"))

                Destroy(this.gameObject);  //エフェクトを発生させる

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //0.5秒後にエフェクトを消す
            Destroy(effect, 0.5f);
            // 破壊の効果音を出す
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }
    }

}

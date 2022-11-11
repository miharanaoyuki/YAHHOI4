using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip destroySound;
    public int enemyHP;

    void OnCollisionEnter2D(Collision2D other)
    {
        // もしもぶつかった相手に「yahhoi」というタグ（Tag）がついていたら、
        if (other.gameObject.tag=="yahhoi")
        {
            // 敵のHPを１ずつ減少させる
            enemyHP -= 1;
           
            // 敵のHPが０になったら敵オブジェクトを破壊する。
            if (enemyHP == 0)
            {
                //ゲームオブジェクトの破壊
                Destroy(gameObject);

                //エフェクトを発生させる
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //0.5秒後にエフェクトを消す
                Destroy(effect, 0.5f);
                // 破壊の効果音を出す
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
        }
    }

    
}
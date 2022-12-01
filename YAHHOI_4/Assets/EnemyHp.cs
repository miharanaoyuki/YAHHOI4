using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    //体力設定
    public int HP;

    //エフェクト
    public GameObject effectPrefab;

    //撃破サウンド
    public AudioClip destroySound;

    //アイテム
    public GameObject itemPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //敵のHPを減らす
            HP -= 1;
            if (HP == 0)
            {
                //自身を消す
                Destroy(this.gameObject);

                //エフェクト生成
                GameObject effect1 = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //アイテム生成
                Instantiate(itemPrefab, transform.position, Quaternion.identity);

                //0.5秒後にエフェクトを消す
                Destroy(effect1, 0.5f);

                //サウンド再生
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
            Debug.Log(HP);
        }
    }
}

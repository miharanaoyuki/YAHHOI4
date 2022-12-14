using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHP : MonoBehaviour
{
    //エフェクト
    public GameObject effectPrefab;

    //撃破サウンド
    public AudioClip destroySound;

    //HP設定
    public int BossHP;

    //シーン移動
    public string scene;

    //アイテムドロップ
    public GameObject itemprefab;

    //OnTriggerなので注意！！！
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もし、Bulletと言うタグに当たったら
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //敵のHPを1減らす
            BossHP -= 1;
            if (BossHP == 0)
            {
                //自身を消す
                Destroy(this.gameObject);

                //オブジェクト生成(エフェクト)
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //0.5秒後にエフェクトを消す
                Destroy(effect, 0.5f);
                //サウンド再生
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
                //任意のシーンに移動する
                SceneManager.LoadScene(scene);

                //敵を破壊した瞬間＝敵のHPが0になった瞬間にアイテムプレハブを実体化させる。
                Instantiate(itemprefab, transform.position, Quaternion.identity);
            }
            Debug.Log(BossHP);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //プレイヤーとタグに当たった時の処理
    //if (collision.gameObject.CompareTag("Wall") ||
    //collision.gameObject.CompareTag("Player"))
    //{
    // Destroy(this.gameObject);
    //}
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    //�̗͐ݒ�
    public int HP;

    //�G�t�F�N�g
    public GameObject effectPrefab;

    //���j�T�E���h
    public AudioClip destroySound;

    //�A�C�e��
    public GameObject itemPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //�G��HP�����炷
            HP -= 1;
            if (HP == 0)
            {
                //���g������
                Destroy(this.gameObject);

                //�G�t�F�N�g����
                GameObject effect1 = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //�A�C�e������
                Instantiate(itemPrefab, transform.position, Quaternion.identity);

                //0.5�b��ɃG�t�F�N�g������
                Destroy(effect1, 0.5f);

                //�T�E���h�Đ�
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
            Debug.Log(HP);
        }
    }
}

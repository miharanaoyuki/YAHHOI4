using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHP : MonoBehaviour
{
    //�G�t�F�N�g
    public GameObject effectPrefab;

    //���j�T�E���h
    public AudioClip destroySound;

    //HP�ݒ�
    public int BossHP;

    //�V�[���ړ�
    public string scene;

    //�A�C�e���h���b�v
    public GameObject itemprefab;

    //OnTrigger�Ȃ̂Œ��ӁI�I�I
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����ABullet�ƌ����^�O�ɓ���������
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //�G��HP��1���炷
            BossHP -= 1;
            if (BossHP == 0)
            {
                //���g������
                Destroy(this.gameObject);

                //�I�u�W�F�N�g����(�G�t�F�N�g)
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //0.5�b��ɃG�t�F�N�g������
                Destroy(effect, 0.5f);
                //�T�E���h�Đ�
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
                //�C�ӂ̃V�[���Ɉړ�����
                SceneManager.LoadScene(scene);

                //�G��j�󂵂��u�ԁ��G��HP��0�ɂȂ����u�ԂɃA�C�e���v���n�u�����̉�������B
                Instantiate(itemprefab, transform.position, Quaternion.identity);
            }
            Debug.Log(BossHP);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //�v���C���[�ƃ^�O�ɓ����������̏���
    //if (collision.gameObject.CompareTag("Wall") ||
    //collision.gameObject.CompareTag("Player"))
    //{
    // Destroy(this.gameObject);
    //}
    //}
}
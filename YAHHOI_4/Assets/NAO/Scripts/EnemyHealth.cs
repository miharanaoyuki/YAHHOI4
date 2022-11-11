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
        // �������Ԃ���������Ɂuyahhoi�v�Ƃ����^�O�iTag�j�����Ă�����A
        if (other.gameObject.tag=="yahhoi")
        {
            // �G��HP���P������������
            enemyHP -= 1;
           
            // �G��HP���O�ɂȂ�����G�I�u�W�F�N�g��j�󂷂�B
            if (enemyHP == 0)
            {
                //�Q�[���I�u�W�F�N�g�̔j��
                Destroy(gameObject);

                //�G�t�F�N�g�𔭐�������
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                //0.5�b��ɃG�t�F�N�g������
                Destroy(effect, 0.5f);
                // �j��̌��ʉ����o��
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
        }
    }

    
}
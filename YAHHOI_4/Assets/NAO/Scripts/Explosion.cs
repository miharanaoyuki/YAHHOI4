using UnityEngine;

// �����G�t�F�N�g�𐧌䂷��R���|�[�l���g
public class Explosion : MonoBehaviour
{
    // �����G�t�F�N�g���������ꂽ���ɌĂяo�����֐�
    private void Start()
    {
        // ���o������������폜����
        var particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }
}
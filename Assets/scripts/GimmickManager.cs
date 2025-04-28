using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    public GameObject bowGenerator;       // �|�W�F�l���[�^�[
    public GameObject bowGenerator2;       // �|�W�F�l���[�^�[
    public GameObject bowGenerator3;       // �|�W�F�l���[�^�[
    public GameObject laserGenerator;     // ���[�U�[�W�F�l���[�^�[
    public GameObject laserGenerator2;     // ���[�U�[�W�F�l���[�^�[
    public GameObject laserGenerator3;     // ���[�U�[�W�F�l���[�^�[
    public GameObject sawGenerator;       // �̂�����W�F�l���[�^�[

    private int lastLevel = 0; // �Ō�Ɋm�F�������x��

    private void Start()
    {
        UpdateGenerators(); // �ŏ��Ɉ�x�`�F�b�N
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            if (lastLevel != GameManager.Instance.CurrentLevel)
            {
                UpdateGenerators();
            }
        }
    }

    private void UpdateGenerators()
    {
        int level = GameManager.Instance.CurrentLevel;
        lastLevel = level;

        // ���x���ɉ����āA�ߋ������A�N�e�B�u�ɂ���
        if (level >= 1 && bowGenerator != null)
        {
            bowGenerator.SetActive(true);
        }
        if (level >= 2 && laserGenerator != null)
        {
            laserGenerator.SetActive(true);
        }
        if (level >= 3 && sawGenerator != null)
        {
            bowGenerator2.SetActive(true);
            sawGenerator.SetActive(true);
        }
        if (level >= 4 && laserGenerator2 != null)
        {
            laserGenerator2.SetActive(true);
        }
        if (level >= 5 && laserGenerator3 != null)
        {
            laserGenerator3.SetActive(true);
        }

        if (level >= 6 && bowGenerator3 != null)
        {
            bowGenerator3.SetActive(true);
        }
    }
}

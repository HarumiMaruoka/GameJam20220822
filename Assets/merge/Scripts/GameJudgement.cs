using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�N���A�[�ƃQ�[���I�[�o�[�����m����
public class GameJudgement : MonoBehaviour
{
    [Header("���Ώ�"), SerializeField] GameObject _motherShip;
    [Header("�}���Ώ�"), SerializeField] GameObject _boss;

    [Header("�}���Ώ�"), SerializeField] string _clearSceneName;
    [Header("�}���Ώ�"), SerializeField] string _gameOverSceneName;

    void Update()
    {
        if (!_motherShip)
        {
            SceneManager.LoadScene(_clearSceneName);
        }
        if (!_boss)
        {
            SceneManager.LoadScene(_gameOverSceneName);
        }
    }
}

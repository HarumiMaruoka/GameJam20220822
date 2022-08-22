using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�N���A�[�ƃQ�[���I�[�o�[�����m����
public class GameJudgement : MonoBehaviour
{
    [Header("���Ώ�"), SerializeField] GameObject _motherShip;
    static public GameObject _boss;
    static public bool _setBoss = false;

    [Header("clear�V�[���̖��O"), SerializeField] string _clearSceneName;
    [Header("gameover�V�[���̖��O"), SerializeField] string _gameOverSceneName;

    void Update()
    {
        if (!_motherShip)
        {
            SceneManager.LoadScene(_gameOverSceneName);
        }
        if (_setBoss && !_boss)
        {
            SceneManager.LoadScene(_clearSceneName);
        }
    }
}

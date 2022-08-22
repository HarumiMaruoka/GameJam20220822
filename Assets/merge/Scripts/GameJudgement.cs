using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//クリアーとゲームオーバーを検知する
public class GameJudgement : MonoBehaviour
{
    [Header("守護対象"), SerializeField] GameObject _motherShip;
    [Header("迎撃対象"), SerializeField] GameObject _boss;

    [Header("迎撃対象"), SerializeField] string _clearSceneName;
    [Header("迎撃対象"), SerializeField] string _gameOverSceneName;

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

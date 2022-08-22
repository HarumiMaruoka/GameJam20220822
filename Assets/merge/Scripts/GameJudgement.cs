using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//クリアーとゲームオーバーを検知する
public class GameJudgement : MonoBehaviour
{
    [Header("守護対象"), SerializeField] GameObject _motherShip;
    static public GameObject _boss;
    static public bool _setBoss = false;

    [Header("clearシーンの名前"), SerializeField] string _clearSceneName;
    [Header("gameoverシーンの名前"), SerializeField] string _gameOverSceneName;

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

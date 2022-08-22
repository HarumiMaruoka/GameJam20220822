using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    /// <summary>出現するTransform</summary>
    [Tooltip("出現させるTransform")]
    [SerializeField] List<Transform> _generateMuzzles = new List<Transform>();
    /// <summary>Waveで出現させるPrefab</summary>
    [Tooltip("0からWave毎に出現させる")]
    [SerializeField] List<GameObject> _waveEnemies = new List<GameObject>();
    [Tooltip("")]

    /// <summary>ボスを登場させるWave数</summary>
    [Tooltip("ボスを登場させるWave数")]
    [SerializeField] int _bossWaveCount = default;
    int _waveCount = default;
    public static int _currentEnemyCount;
    void Start()
    {

    }

    void Update()
    {
        if (_waveCount >= 0 && _currentEnemyCount == 0)
        {
            foreach (var Spown in _generateMuzzles)
            {
                GameObject go = Instantiate(_waveEnemies[_waveCount]);
                go.transform.position = Spown.position;
            }
            _currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
        Debug.Log(_currentEnemyCount);
    }
}

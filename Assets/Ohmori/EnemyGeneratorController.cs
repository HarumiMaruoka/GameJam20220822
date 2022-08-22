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
    [Tooltip("ボスのプレハブ")]
    [SerializeField] GameObject _bossPrefab;
    /// <summary>ボスを登場させるWave数</summary>
    [Tooltip("ボスを登場させるWave数")]
    [SerializeField] int _bossWaveCount = default;
    [Tooltip("Waveの間隔")]
    [SerializeField] float _distance = default;
    int _waveCount = default;
    float _timer = default;
    void Start()
    {

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_waveCount >= 0 && _waveCount < _bossWaveCount && _timer > _distance)
        {
            foreach (var Spown in _generateMuzzles)
            {
                GameObject go = Instantiate(_waveEnemies[_waveCount]);
                go.transform.position = Spown.position;
            }
            _distance = 0f;
            _waveCount++;
        }
        else if (_waveCount == _bossWaveCount)
        {
            GameObject go = Instantiate(_bossPrefab);
            go.transform.position = _generateMuzzles[4].position;
        }
        //Debug.Log(_currentEnemyCount);
    }
}

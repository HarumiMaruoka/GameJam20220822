using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    /// <summary>出現するTransform</summary>
    [Tooltip("出現させるTransform")]
    [SerializeField] List<Transform> _generateMuzzles = new List<Transform>();
    /// <summary>Waveで出現させるPrefab</summary>
    [Tooltip("Muzzle1で0からWave毎に出現させる")]
    [SerializeField] List<GameObject> _waveEnemies1 = new List<GameObject>();

    [Tooltip("Muzzle2で0からWave毎に出現させる")]
    [SerializeField] List<GameObject> _waveEnemies2 = new List<GameObject>();

    [Tooltip("Muzzle3で0からWave毎に出現させる")]
    [SerializeField] List<GameObject> _waveEnemies3 = new List<GameObject>();

    [Tooltip("Muzzle4で0からWave毎に出現させる")]
    [SerializeField] List<GameObject> _waveEnemies4 = new List<GameObject>();

    [Tooltip("ボスのプレハブ")]
    [SerializeField] GameObject _bossPrefab;
    [Tooltip("Waveの間隔")]
    [SerializeField] float _interval = default;
    int _waveCount = default;
    float _timer = default;
    void Start()
    {

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_waveCount >= 0 && _waveCount < _waveEnemies1.Count && _timer > _interval)
        {
            GameObject go1 = Instantiate(_waveEnemies1[_waveCount]);
            go1.transform.position = _generateMuzzles[0].position;
            GameObject go2 = Instantiate(_waveEnemies2[_waveCount]);
            go2.transform.position = _generateMuzzles[1].position;
            GameObject go3 = Instantiate(_waveEnemies3[_waveCount]);
            go3.transform.position = _generateMuzzles[2].position;
            GameObject go4 = Instantiate(_waveEnemies4[_waveCount]);
            go4.transform.position = _generateMuzzles[3].position;
            _timer = 0f;
            _waveCount++;
        }
        else if (_waveCount == _waveEnemies1.Count)
        {
            GameObject go = Instantiate(_bossPrefab);
            go.transform.position = _generateMuzzles[4].position;
        }
        //Debug.Log(_currentEnemyCount);
    }
}

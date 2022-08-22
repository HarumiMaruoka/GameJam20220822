using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    /// <summary>�o������Transform</summary>
    [Tooltip("�o��������Transform")]
    [SerializeField] List<Transform> _generateMuzzles = new List<Transform>();
    /// <summary>Wave�ŏo��������Prefab</summary>
    [Tooltip("0����Wave���ɏo��������")]
    [SerializeField] List<GameObject> _waveEnemies = new List<GameObject>();
    [Tooltip("�{�X�̃v���n�u")]
    [SerializeField] GameObject _bossPrefab;
    /// <summary>�{�X��o�ꂳ����Wave��</summary>
    [Tooltip("�{�X��o�ꂳ����Wave��")]
    [SerializeField] int _bossWaveCount = default;
    [Tooltip("Wave�̊Ԋu")]
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    /// <summary>�o������Transform</summary>
    [Tooltip("�o��������Transform")]
    [SerializeField] List<Transform> _generateMuzzles = new List<Transform>();
    /// <summary>Wave�ŏo��������Prefab</summary>
    [Tooltip("Muzzle1��0����Wave���ɏo��������")]
    [SerializeField] List<GameObject> _waveEnemies1 = new List<GameObject>();

    [Tooltip("Muzzle2��0����Wave���ɏo��������")]
    [SerializeField] List<GameObject> _waveEnemies2 = new List<GameObject>();

    [Tooltip("Muzzle3��0����Wave���ɏo��������")]
    [SerializeField] List<GameObject> _waveEnemies3 = new List<GameObject>();

    [Tooltip("Muzzle4��0����Wave���ɏo��������")]
    [SerializeField] List<GameObject> _waveEnemies4 = new List<GameObject>();

    [Tooltip("�{�X�̃v���n�u")]
    [SerializeField] GameObject _bossPrefab;
    [Tooltip("Wave�̊Ԋu")]
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

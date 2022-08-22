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
    [Tooltip("")]

    /// <summary>�{�X��o�ꂳ����Wave��</summary>
    [Tooltip("�{�X��o�ꂳ����Wave��")]
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

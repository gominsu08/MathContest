using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {
        
    }
    public Transform targetPoint;   // 목표 지점
    public float height = 5f;       // 포물선의 최고점 높이
    public float duration = 2f;     // 이동 시간
    public int resolution = 20;     // 경로를 구성하는 점의 수 (포물선의 매끄러움)

    public void Initalize(Transform _target)
    {
        targetPoint = _target;
        // 포물선 경로 계산
        Vector3[] path = CalculateParabolicPath(transform.position, targetPoint.position, height, resolution);

        // DoPath를 이용해 경로를 따라 이동
        transform.DOPath(path, duration, PathType.CatmullRom)
            .SetEase(Ease.Linear);  // 선형 이동
    }

    // 포물선 경로 계산 함수
    private Vector3[] CalculateParabolicPath(Vector3 start, Vector3 end, float height, int resolution)
    {
        Vector3[] path = new Vector3[resolution + 1];

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / resolution;  // 0에서 1 사이의 값을 가짐 (포물선 경로에서의 비율)
            
            // 수평 거리의 비율을 따라 X 위치 계산
            float xPos = Mathf.Lerp(start.x, end.x, t);

            // 포물선의 높이 (y축) 계산
            float yPos = Mathf.Lerp(start.y, end.y, t) + height * (1 - Mathf.Pow(2 * t - 1, 2));

            // z축 값은 고정 (2D라서 Z축을 고정하는 경우)
            float zPos = start.z;

            // 계산된 위치를 경로에 추가
            path[i] = new Vector3(xPos, yPos, zPos);
        }

        return path;
    }
}

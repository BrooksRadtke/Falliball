using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelStartPrefab;
    [SerializeField] private Transform levelPrefab;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStartPrefab.Find("EndPosition").position;
        SpawnLevelPrefab();
        SpawnLevelPrefab();     
    }

    private void SpawnLevelPrefab()
    {
        Transform lastLevelPrefabTransform = SpawnLevelPrefab(lastEndPosition);
        lastEndPosition = lastLevelPrefabTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPrefab(Vector3 spawnPosition)
    {
        Transform levelPrefabTransform = Instantiate(levelPrefab, spawnPosition, Quaternion.identity);
        return levelPrefabTransform;
    }
}

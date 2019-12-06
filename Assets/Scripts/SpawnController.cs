using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnPoints;
    [SerializeField] private int SpawnRate;

    [SerializeField] private List<GameObject> DropsPrefabs;

    private void Start()
    {
        StartCoroutine(SpawnDrops());
    }

    private IEnumerator SpawnDrops()
    {
       var RNG = new System.Random();
       var DropsIndex = RNG.Next(DropsPrefabs.Count);
       var SpawnIndex = RNG.Next(SpawnPoints.Count);

       Instantiate(DropsPrefabs[DropsIndex], SpawnPoints[SpawnIndex].transform.position, SpawnPoints[SpawnIndex].transform.rotation);
       
       yield return new WaitForSeconds(SpawnRate);
       StartCoroutine(SpawnDrops());
    }
}

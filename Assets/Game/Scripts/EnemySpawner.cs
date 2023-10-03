using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveData[] waveDataList; // รายการข้อมูล Wave ทั้งหมด
    public int maxEnemyCountPerWave = 20; // จำนวนสูงสุดของ Enemy ในแต่ละ Wave

    private int currentWave = 0; // Wave ปัจจุบัน
    public int spawnedEnemyCount;
    private float timer = 0f; // ตัวนับเวลา
    public float spawnTime = 1f; // 
    public float CounterSpawnTime; //
    public List<Transform> spawnPos = new List<Transform>();
    

    void Start()
    {
        // StartCoroutine(SpawnWaveRoutine());
        CounterSpawnTime = spawnTime;
    }

    void Update()
    {
        if(GameManager.Instance.Pause)
            return;
        
        timer += Time.deltaTime;
        CounterSpawnTime -= Time.deltaTime;
        // เมื่อผ่านไปเวลา 2 นาที ให้สลับ Wave
        if (CounterSpawnTime <= 0f && spawnedEnemyCount < maxEnemyCountPerWave)
        {
            CounterSpawnTime = spawnTime;
            SpawnWave();
        }
        if (timer >= waveDataList[currentWave].waveInterval)
        {
            timer = 0f;
            SwitchWave();
        }
    }

    private IEnumerator SpawnWaveRoutine()
    {
        while (currentWave < waveDataList.Length)
        {
            yield return new WaitForSeconds(waveDataList[currentWave].waveInterval);
            //SpawnWave(waveDataList[currentWave]);
            currentWave++;
        }
    }

    private void SpawnWave()
    {
        WaveData waveData = waveDataList[currentWave];
        int enemyCount = waveData.enemyDataList.Length;
        int totalPercentage = 0;
        foreach (WaveData.EnemyData enemyData in waveData.enemyDataList)
        {
            totalPercentage += enemyData.percentage;
        }

        int maxEnemyCount = Mathf.Min(maxEnemyCountPerWave, enemyCount);
        int randomPercentage = Random.Range(0, totalPercentage);
        int cumulativePercentage = 0;
        for (int j = 0; j < enemyCount; j++)
        {
            cumulativePercentage += waveData.enemyDataList[j].percentage;
            if (randomPercentage < cumulativePercentage)
            {
                GameObject enemy = Instantiate(waveData.enemyDataList[j].enemyPrefab, spawnPos[Random.Range(0,spawnPos.Count)].position, Quaternion.identity);
                spawnedEnemyCount++;

                //เมื่อ Enemy ตายให้เพิ่มจำนวน Enemy ที่สร้างไปแล้ว
                enemy.GetComponent<Enemy>().OnEnemyDeath += () =>
                {
                    spawnedEnemyCount--;
                };

                break;
            }
        }
    }

    private void SwitchWave()
    {
        currentWave++;
        if (currentWave >= waveDataList.Length)
        {
            // หากเล่น Wave ถึงตัวสุดท้าย ให้ทำการรีเซ็ต
            currentWave = 0;
        }
    }
}

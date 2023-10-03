using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Game/Wave Data", order = 1)]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemyData
    {
        public GameObject enemyPrefab; // พรีแฟปของ Enemy
        public int percentage; // เปอร์เซ็นต์ของ Enemy
    }
    public float waveInterval;
    public EnemyData[] enemyDataList; // รายการข้อมูล Enemy ใน Wave นั้นๆ
}

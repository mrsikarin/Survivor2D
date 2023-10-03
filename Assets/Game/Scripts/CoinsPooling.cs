using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPooling : MonoBehaviour
{
    public static CoinsPooling Instance;
    public GameObject coinPrefabs;
    private List<GameObject> coins = new List<GameObject>();
    public int maxCoins = 10;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            CreatePoolingObjects();
        }
    }
    public void CreatePoolingObjects()
    {
        GameObject obj = Instantiate(coinPrefabs);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        coins.Add(obj);
        //return
    }
    public GameObject GetPool()
    {
            for (int i = 0; i < maxCoins; i++)
            {
                if (!coins[i].activeSelf)
                {
                    
                    return coins[i];
                }
            }
        return null;
        

    }
    public void Pooling(Vector3 spawnPos, int amount)
    {
        GameObject obj = GetPool();
        if(obj != null){
        obj.transform.position = spawnPos;
        obj.SetActive(true);
        obj.GetComponent<Coins>().Amount = amount;
        }
    }
    //  public void 

}

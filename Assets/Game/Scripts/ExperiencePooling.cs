using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePooling : MonoBehaviour
{
    public static ExperiencePooling Instance;
    public GameObject expPrefabs;
    private List<GameObject> exps = new List<GameObject>();
    public int maxList = 10;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxList; i++)
        {
            CreatePoolingObjects();
        }
    }
    public void CreatePoolingObjects()
    {
        GameObject obj = Instantiate(expPrefabs);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        exps.Add(obj);
        //return
    }
    public GameObject GetPool()
    {
            for (int i = 0; i < maxList; i++)
            {
                if (!exps[i].activeSelf)
                {
                    
                    return exps[i];
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
        obj.GetComponent<Experience>().gainExp = amount;
        }
    }
}

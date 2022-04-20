using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private GameObject[] coins;

    Vector3 SpawnLocation;

    [SerializeField] private float minSpawnTime = .1f;
    [SerializeField] private float maxSpawnTime= .5f;
    [SerializeField] private int range = 7;

    private void Awake()
    {
        foreach (GameObject enemy in enemys)
        {
            enemy.SetActive(false);
        }
        foreach (GameObject coin in coins)
        {
            coin.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnEnemy()
    {      
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i].activeInHierarchy)
            {
                i++;
                break;
            }
            if (i >= enemys.Length-1)
            {
                i = 0;   
            }
            SpawnLocation = new Vector3(Random.Range(-range, range), 0.6f, 90);
            enemys[i].transform.position = SpawnLocation;
            enemys[i].SetActive(true);
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }     
    }

    IEnumerator SpawnCoin()
    {
        for (int i = 0; i < coins.Length; i++)
        {      
            if (i >= coins.Length - 1)
            {
                i = 0;
            }
            SpawnLocation = new Vector3(Random.Range(-range, range), 0.48f, 90);
            coins[i].transform.position = SpawnLocation;
            coins[i].SetActive(true);
            yield return new WaitForSeconds(Random.Range(8, 50));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Stats CoinStats;
    [SerializeField] private PlayerController myController;
    float coinSpeed = 40f;

    void Start()
    {
        LoadOnStart();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - coinSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            myController.HealthChange(CoinStats.Damage);
            this.gameObject.SetActive(false);
        }
        else if (other.transform.tag == "Destroy")
        {
            this.gameObject.SetActive(false);
        }
    }
    private void LoadOnStart()
    {
        CoinStats = GetComponent<Stats>();
        CoinStats.Damage = 20;
    }
    private void OnDisable()
    {
        coinSpeed += 5;
        coinSpeed = Mathf.Clamp(coinSpeed, 30, 90);
    }
}

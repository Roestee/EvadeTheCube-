using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Stats enemyStats;

    private int enemySpeed = 30;
    [SerializeField] PlayerController myController;



    private void Start()
    {
        LoadOnStart();
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - enemySpeed * Time.deltaTime);
    }
    private void LoadOnStart()
    {
        enemyStats = GetComponent<Stats>();

        enemyStats.Health = 100;
        enemyStats.Damage = 20;
        enemyStats.Score = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" )
        {
            myController.ScoreChange(-enemyStats.Score * (enemySpeed / 30));
            myController.HealthChange(-enemyStats.Damage);
            this.gameObject.SetActive(false);
        }
        else if(other.transform.tag == "Destroy")
        {
            myController.ScoreChange(enemyStats.Score*(enemySpeed/30));
            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        enemySpeed += 3;
        enemySpeed = Mathf.Clamp(enemySpeed, 30, 90);
    }
}

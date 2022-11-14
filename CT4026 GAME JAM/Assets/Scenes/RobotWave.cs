using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWave : MonoBehaviour
{
    private EnemyMovement _robotMovement;
    public GameObject robot;
    private int numberInc = 0;


    private void Start()
    {
        _robotMovement = GameObject.Find("Robot enemy").GetComponent<EnemyMovement>();
        StartCoroutine(RobotSpawner());
    }

    IEnumerator RobotSpawner()
    {
        for (int i = 0; i < 10; i++) {
            yield return new WaitForSeconds(3f);
            GameObject newEnemy = Instantiate(robot);
            _robotMovement = newEnemy.GetComponent<EnemyMovement>();
            StartCoroutine(_robotMovement.EnemySteps());
            _robotMovement.numberRobot = numberInc;
            numberInc++;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private GameObject selectedEnemy;
    private EnemyMovement _robotMovementTarget;
    private EnemyMovement _robotMovementSelected;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
            int temp = 1000000;
            _robotMovementSelected = selectedEnemy.GetComponent<EnemyMovement>();
            foreach (GameObject target in allTargets)
            {
                _robotMovementTarget = target.GetComponent<EnemyMovement>();
                if ((_robotMovementTarget.numberRobot<temp)&& Vector3.Distance(selectedEnemy.transform.position, transform.position) < 10)
                {
                    selectedEnemy = target;
                    _robotMovementSelected = selectedEnemy.GetComponent<EnemyMovement>();
                    temp = _robotMovementSelected.numberRobot;
                }
            }

            if (Vector3.Distance(selectedEnemy.transform.position, transform.position) < 10)
            {
                Debug.Log("hit");
                _robotMovementSelected.health -= 50;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

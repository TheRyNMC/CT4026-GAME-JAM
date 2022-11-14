using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float stepLength = 0.03f;
    private float stepInterval = 0.01f;
    public float health = 200;


    public IEnumerator EnemySteps()
    {
        transform.position = new Vector3(-16.9727535f, 3f, 4.05547094f);

        //Path1
        for (int i = 0; i < 300; i++)
        {
            transform.position = transform.position + new Vector3(stepLength,0f,0f);
            yield return new WaitForSeconds(stepInterval);
        }

        //Rotate
        for (int i = 0; i < 30; i++)
        {
            transform.Rotate(0f, 0f, 3f);
            yield return new WaitForSeconds(0.01f);
        }

        //Path2
        for (int i = 0; i < 300; i++)
        {
            transform.position = transform.position + new Vector3(0f, 0f, -stepLength);
            yield return new WaitForSeconds(stepInterval);
        }
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }

}

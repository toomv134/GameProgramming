using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject rangeobject;
    public GameObject enemy;
    BoxCollider rangeCollider;
    private void Awake()
    {
        rangeCollider = rangeobject.GetComponent<BoxCollider>();
    }
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }
    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            GameObject instantEnemy = Instantiate(enemy, Return_RandomPosition(), Quaternion.Euler(0f, Random.Range(0.0f, 360.0f), 0f));
        }
    }
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeobject.transform.position;

        float range_x = rangeCollider.bounds.size.x;
        float range_z = rangeCollider.bounds.size.y;

        range_x = Random.Range((range_x / 2) * -1, range_x / 2);
        range_z = Random.Range((range_z / 2) * -1, range_z / 2);
        Vector3 RandomPosition = new Vector3(range_x, 0f, range_z);

        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }
}

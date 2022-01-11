using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;
    GameObject player;
    GameObject enemy;
    public static Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        //player = GameObject.Find("Player");
        //enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (CheckPlayerEnemyDistance())
        {
            CheckTimeToFire();
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    bool CheckPlayerEnemyDistance()
    {
        if (Mathf.Abs(position.x - Move.position.x) < 5.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

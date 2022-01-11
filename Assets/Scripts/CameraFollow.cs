using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 8f;
    public Transform target;
    public static bool isPlayerHit = false;
    public GameObject playerHitGradient;
    public int fakeTimer = 0;


    private void Start()
    {
        playerHitGradient.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerHit)
        {
            playerHitGradient.SetActive(true);
            fakeTimer++;
            if (fakeTimer == 30)
            {
                isPlayerHit = false;
                fakeTimer = 0;
            }
        }
        else
        {
            playerHitGradient.SetActive(false);
        }
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

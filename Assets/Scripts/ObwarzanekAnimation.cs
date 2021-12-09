 using UnityEngine;
 using System.Collections;
 
 public class ObwarzanekAnimation : MonoBehaviour
{
    public Vector3 MoveVector = Vector3.up;
    public float MoveRange = 0.33f;
    public float MoveSpeed = 5f;
    private ObwarzanekAnimation bounceObject;
    Vector3 startPosition; 
    void Start()
    {
        bounceObject = this;
        startPosition = bounceObject.transform.position;
    }
    void Update()
    {
        bounceObject.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));
    }
}
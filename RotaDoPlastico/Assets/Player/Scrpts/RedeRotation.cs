using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeRotation : MonoBehaviour
{
    public float speed;

    private Vector2 direction;
    public Transform Player;


    private void Update()
    {
        direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
}

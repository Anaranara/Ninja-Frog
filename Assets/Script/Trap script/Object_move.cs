using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_move : MonoBehaviour
{
    [SerializeField] private GameObject[] point;
    private int i = 0;
    [SerializeField] private float speed = 6f;
    private void Update()
    {
        if (Vector2.Distance(point[i].transform.position, transform.position) < .1f)
        {
            i++;
            if(i >= point.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, point[i].transform.position, Time.deltaTime * speed);
    }

}

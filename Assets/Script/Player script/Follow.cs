using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float size = 7f;

    private void Start()
    {
        Camera.main.orthographicSize = size;
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}

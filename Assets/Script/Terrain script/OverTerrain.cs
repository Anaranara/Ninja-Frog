using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OverTerrain : MonoBehaviour
{
    [SerializeField] private TilemapRenderer overterrain;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            overterrain.sortingLayerName = "Hidden";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            overterrain.sortingLayerName = "Default";
        }
    }
}

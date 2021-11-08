using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    public GameObject[] Pieces;

    [SerializeField] GameObject EndScreen = null;

    void Start()
    {
        NewPiece();
    }

    // Update is called once per frame
    public void NewPiece()
    {
        Instantiate(Pieces[Random.Range(0, Pieces.Length)], transform.position, Quaternion.identity);
    }

    public void EndSpawning()
    {
        EndScreen.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}

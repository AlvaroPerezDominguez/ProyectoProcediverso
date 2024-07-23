using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteConstruccion : MonoBehaviour
{
    public static int PieceLimit;
    public float minPiezas = 200f; 
    public float maxPiezas = 275f; 

    // Start is called before the first frame update
    void Start()
    {
        PieceLimit = Mathf.RoundToInt(Random.Range(minPiezas, maxPiezas));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

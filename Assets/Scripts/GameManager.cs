using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public Text timeTxt;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    void MakeSquare()
    {
        Instantiate(square);
    }
}

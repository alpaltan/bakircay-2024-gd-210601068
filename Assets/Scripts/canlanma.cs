using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canlanma : MonoBehaviour
{
    public GameObject prefab;
    public int dogmaSayisi = 2; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < dogmaSayisi; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-10, 10),
                Random.Range(0, 5),
                Random.Range(-10, 10)
            );
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

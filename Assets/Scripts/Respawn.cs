using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 CheckPoint;
    public GameObject player;
    public List<GameObject> checkPoints;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = CheckPoint;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckPoint = player.transform.position;
    }
}

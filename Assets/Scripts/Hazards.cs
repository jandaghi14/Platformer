using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    private Player player;

    public GameObject Blood;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine("respawndelay");
        }
    }

    public IEnumerator respawndelay()
    {
        Instantiate(Blood, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2);
        player.transform.position = new Vector3(-22, 6, 0);
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
    }
}


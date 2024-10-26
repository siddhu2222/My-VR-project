using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private float bulletspeed;

    public AudioClip bulletSound;
    public AudioSource audioSource;


    public void FireBullet(){
        audioSource = GetComponent<AudioSource>();
       GameObject spawnbullet=  Instantiate(bullet, spawnpoint.position , spawnpoint.rotation);
       spawnbullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * bulletspeed;
       audioSource.PlayOneShot(bulletSound);
       Destroy(spawnbullet,5f);
    }

}

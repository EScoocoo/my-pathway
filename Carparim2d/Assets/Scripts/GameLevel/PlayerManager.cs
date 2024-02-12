using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private Transform gun;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip topClick;

    float angle;
    float donusHizi=50f;

    float ikiMermiArasiSure = 200f;
    float sonrakiAtisSure;

    public bool rotaDegissinmi;

    private void Start()
    {
        rotaDegissinmi = false;
    }
    void Update()
    {
        if(rotaDegissinmi)
        {
            RotateDegistir();
        }
        
    }

    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        if(angle<45 && angle>-45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonDown(0))
        {            
            if(Time.time>sonrakiAtisSure)
            {
                sonrakiAtisSure = Time.time + ikiMermiArasiSure / 1000;
                MermiAt();
            }
        }                
    }

    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }

        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;
            
    }
}

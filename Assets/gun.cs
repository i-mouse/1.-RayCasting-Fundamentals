using System;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera camera;
    public float impactforce =0.1f;
    public GameObject flare;
    public float firerate = 15f;
    public float nexttimetofire = 0;


    public ParticleSystem muzzle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time>=nexttimetofire)
        {
            nexttimetofire = Time.time + firerate;
            shoot();
        }
    }

    private void shoot()
    {
       // Ray ray = camera.ScreenPointToRay(camera.transform.position);
        RaycastHit hit;
        muzzle.Play();

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            // time to get the componemt that we hit
            Enemy enemy= hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
              
                enemy.TakingDamage(damage);
            }
            if(hit.rigidbody!=null)
            {
               
                hit.rigidbody.AddForce(-hit.transform.position.x,0,0);
            }

        }
        
        GameObject impact = Instantiate(flare, hit.point, Quaternion.identity);
        Destroy(impact, 2f);
    }
}

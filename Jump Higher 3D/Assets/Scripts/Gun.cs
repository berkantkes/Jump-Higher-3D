using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleEffect;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject decal;
    [SerializeField] private float decalSize = 1f;

    private float range = 20000f;
    private Renderer obje;
    public bool ifStart = false;
    public static bool ifFly = false;

    private void Start()
    {
        ifFlyFalse();
    }

    private void Update()
    {
        if (ifStart)
        {
            InvokeRepeating("Shoot", 0, 0.5f);
            ifStart = false;
        }
        
    }
    void Shoot()
    {
        if (!ifFly)
        {
            muzzleEffect.Play();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Builds builds = hit.transform.GetComponent<Builds>();
                if (builds != null)
                {
                    var goDecal = Instantiate(decal, hit.point, Quaternion.identity, hit.transform);
                    goDecal.transform.localScale = Vector3.one * decalSize;
                    builds.Painting();
                }
            }
        }
    }

    public void ifStartTrue()
    {
        ifStart = true;
    }

    public void ifStartFalse()
    {
        ifStart = false;
    }

    public void ifFlyTrue()
    {
        ifFly = true;
    }

    public void ifFlyFalse()
    {
        ifFly = false;
    }
}

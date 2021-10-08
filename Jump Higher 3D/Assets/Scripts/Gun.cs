using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleEffect;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject brush;
    [SerializeField] private float brushSize = 0.1f;

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
                    var goBrush = Instantiate(brush, hit.point, Quaternion.identity, hit.transform);
                    goBrush.transform.localScale = Vector3.one * brushSize;
                    
                    if (hit.transform.name == "-z")
                    {
                        goBrush.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        builds.Painting();

                    }
                    else if (hit.transform.name == "+x")
                    {
                        goBrush.transform.rotation = Quaternion.Euler(-90, 0, -90);
                        builds.Painting();
                    }
                    else if (hit.transform.name == "+z")
                    {
                        goBrush.transform.rotation = Quaternion.Euler(-90, 0, -180);
                        builds.Painting();

                    }
                    else if (hit.transform.name == "-x")
                    {
                        goBrush.transform.rotation = Quaternion.Euler(-90, 0, -270);
                        builds.Painting();

                    }
                    else if (hit.transform.name == "+y")
                    {
                        goBrush.transform.rotation = Quaternion.Euler(0, 90, 0);
                        builds.Painting();

                    }
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

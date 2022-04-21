using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage; // boolen has "false", default data
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(!hasPackage && other.tag=="Package")
       {
           Debug.Log("Package is picked up by Coupang Friend");
           spriteRenderer.color = hasPackageColor;
           hasPackage = true;
           Destroy(other.gameObject, destroyDelay);

       }
       if(hasPackage && other.tag=="Customer")
       {
           Debug.Log("Package is arrived by Coupang Friend");
           spriteRenderer.color = noPackageColor;
           hasPackage = false;
           Destroy(other.gameObject, destroyDelay);
       }
   } 
}
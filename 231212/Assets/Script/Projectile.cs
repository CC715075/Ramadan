//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static IDamageable;

//public class Projectile : MonoBehaviour
//{
//    private void OnHitObject(RaycastHit hit)
//    {
//        IDamgeable damgeableObject = hit.collider.GetComponent<IDamgeable>();
//        if (damgeableObject != null)
//        {
//            damgeableObject.TakeHit(damage, hit);
//        }

//        GameObject.Destroy(this.gameObject);
//    }
//}

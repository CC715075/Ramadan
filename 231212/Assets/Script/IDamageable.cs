using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamageable : MonoBehaviour
{
    public interface IDamgeable
    {
        void TakeHit(float damage, RaycastHit hit);
    }
}

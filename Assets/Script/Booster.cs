using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostValue = 10f;

    public Vector3 targetDir;

    private void Start() {
        targetDir = transform.forward;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.AddForce(targetDir * boostValue, ForceMode.Impulse);
            Debug.Log($"Add force to {other.gameObject.name} with a value of {boostValue} in the direction of {targetDir}");
            SoundHolder.Instance.PlaySound(SoundHolder.soundCatagory.bumper, transform.position, true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody m_myrigidbody = null;

    private void OnEnable()
    {
        if(m_myrigidbody == null)
        {
            m_myrigidbody = GetComponent<Rigidbody>();
        }

        m_myrigidbody.velocity = Vector3.zero;
        m_myrigidbody.AddExplosionForce(1000, transform.position, 1f);

        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.instance.insertQueue(gameObject);
    }
}

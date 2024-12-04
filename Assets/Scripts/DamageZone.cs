using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public Collider damageCollider;
    public int damageAmount = 20;

    public string targetTag;

    public List<Collider> colliderTargets = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        damageCollider.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag) && !colliderTargets.Contains(other))
        {
            colliderTargets.Add(other);
            var go = other.GetComponent<Health>();
            if(go != null)
            {
                go.TakeDamage(damageAmount);
            }
        }
    }
    public void BeginAttack()
    {
        colliderTargets.Clear();
        damageCollider.enabled = true;
    }
    public void EndAttack()
    {
        colliderTargets.Clear();
        damageCollider.enabled = false;
    }
}

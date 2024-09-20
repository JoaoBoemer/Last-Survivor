using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float Life = 3.0f;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if(Life <= 0 && !isDead)
        {
            //anim.trigger(deathanmi);
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        //Anim.trigger(damageTakken);
        // effect
        Life -= 1;
    }

}

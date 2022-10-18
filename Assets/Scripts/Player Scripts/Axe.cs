using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Rigidbody2D rb;
    Collider2D thisCollider;
    private SpriteRenderer sprite;
    public GameObject wielder;
    ThrowingAndTheWorks ed;
    // 0 = held by player, 1 = thrown, 2 = stuck, 3 = returning

    public int state;
    public float returnSpeed = 10f;
    public GameObject shockwavePrefab;
    public int damage = 1;
    // Start is called before the first frame update
    public float spinSpeed = 60;
    private float throwAngle;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        thisCollider = gameObject.GetComponent<Collider2D>();
        rb.simulated = false;
        ed = wielder.GetComponent<ThrowingAndTheWorks>();
        state = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (state == 3)
        {
            rb.velocity = (wielder.transform.position - transform.position).normalized * returnSpeed;
        }
        if(state == 0 || state == 2){
            thisCollider.enabled = false;
        }
        else{
            thisCollider.enabled = true;
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
        if(state == 0){
            sprite.enabled = false;
        }
        else{
            sprite.enabled = true;
        }
        if(state == 2){
            rb.velocity = Vector2.zero;
        }
    }

    public void ThrowThyself(Transform throwingPoint, float axeForce)
    {
        if(CinemachineShakeScript.instance != null){
            CinemachineShakeScript.instance.ShakeCamera(4, .12f);
        }
        transform.parent = null;
        state = 1;
        rb.simulated = true;
        transform.position = throwingPoint.position;
        transform.rotation = throwingPoint.rotation;
        throwAngle = throwingPoint.eulerAngles.z;
        rb.velocity = throwingPoint.up * axeForce;
        AudioManager.instance.PlaySound("Axe Throw");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" && state == 1)
        {
            state = 2;
            rb.velocity = Vector2.zero;
            CinemachineShakeScript.instance.ShakeCamera(4, .12f);
            GameObject shockwave = Instantiate(shockwavePrefab, gameObject.transform);
            Destroy(shockwave, .5f);
            transform.eulerAngles = new Vector3(0, 0, throwAngle + 90f);
            AudioManager.instance.PlaySound("Hit 2");
        } else if (collision.tag == "Player" && state == 3)
        {
            CinemachineShakeScript.instance.ShakeCamera(4f, .12f);
            rb.velocity = Vector2.zero;
            rb.simulated = false;
            transform.parent = wielder.transform;
            state = 0;
            ed.holdingAxe = true;
            transform.position = ed.throwingPoint.position;
            transform.rotation = ed.throwingPoint.rotation;
            //AudioManager.instance.PlaySound("Axe Throw");
            //AudioManager.instance.PlaySound("Hit " + Random.Range(1, 3));
            AudioManager.instance.PlaySound("Hit 2");
            
        } else if ((collision.tag == "object" || collision.tag == "Enemy") && (state == 1 || state == 3))
        {
            ObjectHealthScript objectHealth = collision.GetComponent<ObjectHealthScript>();
            objectHealth.UpdateHealth(damage);
            if(CinemachineShakeScript.instance != null){
                CinemachineShakeScript.instance.ShakeCamera(6.5f, .2f);
            }
        }

    }

    public void Summon(float axeForce)
    {
        if(state == 2){
            state = 3; 
            if(CinemachineShakeScript.instance != null){
                CinemachineShakeScript.instance.ShakeCamera(4, .12f);
            }
            AudioManager.instance.PlaySound("Axe Throw");
        }
    }
}

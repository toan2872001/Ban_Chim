using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xSpeed;
    public float minYspeed;
    public float maxYspeed;
    public GameObject deathVfx;

    Rigidbody2D m_rb;
    bool m_moveLeftOnStart;
    bool m_isDeadBird;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandomMovingDirection();
    }

    private void Update()
    {
        m_rb.velocity = m_moveLeftOnStart ? 
            new Vector2(-xSpeed, Random.Range(minYspeed, maxYspeed)) 
            : new Vector2(xSpeed, Random.Range(minYspeed, maxYspeed));
    }
    public void RandomMovingDirection()
    {
        m_moveLeftOnStart = transform.position.x > 0 ? true : false;

        if (m_moveLeftOnStart)
        {
            transform.localScale = new Vector2(-(transform.localScale.x), (transform.localScale.y));
        }
        else
        {
            transform.localScale = new Vector2((transform.localScale.x), (transform.localScale.y));
        }

    }

    public void DieBird()
    {
        m_isDeadBird = true;
        Destroy(gameObject);
        GameManager.Ins.IncreBirdKiiled();

        if (deathVfx)
        {
            Instantiate(deathVfx, transform.position, Quaternion.identity);
        }

        GameGUIManager.Ins.UpdateKilledCounting(GameManager.Ins.BirdKilled);
    }


}

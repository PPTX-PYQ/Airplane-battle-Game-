using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public int frameRate = 10;
    public Sprite[] idleSprites;
    public Vector3 lastMousePosition = Vector3.zero;
    public bool isMouseDown = false;


    private SpriteRenderer spriteRenderer;
    private float timer = 0;
    private int currentFrame = 0;

    //weapon
    public float superGunDuration = 3;
    private float superGunTimer = 0;
    public GameObject gunTop;
    public GameObject gunRight;
    public GameObject gunLeft;

    public int hp = 3;
    private float invincibleTime = 1.5f;
    private bool isInvincible = false;
    private float invincibleTimer = 0;

    public float blinkInterval = 0.1f;
    public Sprite[] deathSprites;

    public AudioSource getBombAudio;
    public AudioSource getSuperGunAudio;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IdleAnimationUpdate();
        MoveUpdate();
        SuperGunUpdate();
        InvincibleUpdate();
        DeathAnimationUpdate();
    }
    void IdleAnimationUpdate()
    {
        if (hp <= 0) return;
        timer += Time.deltaTime;
        if (timer > 1f / frameRate)
        {
            timer -= 1f / frameRate;
            currentFrame = (currentFrame + 1) % idleSprites.Length;
            spriteRenderer.sprite = idleSprites[currentFrame];
        }
    }
    void DeathAnimationUpdate()
    {
        if (hp > 0) return;
        timer += Time.deltaTime;
        if (timer > 1f / frameRate)
        {
            timer -= 1f / frameRate;
            currentFrame++;
        }
        if (currentFrame >= deathSprites.Length)
        {
            //GameOver
            gamemanager.Instance.gameover();
        }
        else
        {
            spriteRenderer.sprite = deathSprites[currentFrame];
        }
    }

    void MoveUpdate()
    {
        if (gamemanager.Instance.IsPause()) return;
        if (hp <= 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
        if (isMouseDown)
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
            transform.position = transform.position + offset;
            CheckPosition();
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void SuperGunUpdate()
    {
        if (superGunTimer > 0)
        {
            superGunTimer -= Time.deltaTime;

            if (superGunTimer <= 0)
            {
                TransformToNormalGun();
            }
        }
    }
    void CheckPosition()
    {
        //x 2.13
        //y -3.78 3.45
        Vector3 pos = transform.position;
        if (pos.x < -2.13f)
        {
            pos.x = -2.13f;
        }
        if (pos.x > 2.13f)
        {
            pos.x = 2.13f;
        }
        if (pos.y < -3.78f)
        {
            pos.y = -3.78f;
        }
        if (pos.y > 3.45f)
        {
            pos.y = 3.45f;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Award")
        {
            if (collision.GetComponent<award>().awardType == AwardType.SuperGun)
            {
                 TransformToSuperGun();
                 getSuperGunAudio.Play();
            }
            else
            {
                getBombAudio.Play();
                gamemanager.Instance.AddBomb();
            }
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Enemy" && isInvincible == false)
        {
            collision.SendMessage("TakeDamage");
            this.hp--;
            if (hp <= 0)
            {
                TransformToDeath();
            }
            else
            {
                TransformToInvincible();
            }
        }
    }
    void TransformToSuperGun()
    {
        gunRight.SetActive(true);
        gunLeft.SetActive(true);
        gunTop.SetActive(false);
        superGunTimer = superGunDuration;
    }
    void TransformToNormalGun()
    {
        gunRight.SetActive(false);
        gunLeft.SetActive(false);
        gunTop.SetActive(true);
    }
    void DisableAllGun()
    {
        gunRight.SetActive(false);
        gunLeft.SetActive(false);
        gunTop.SetActive(false);
    }
    void TransformToInvincible()
    {
        isInvincible = true;
        invincibleTimer = 0;
        StartCoroutine(BlinkEffect());
    }

    void InvincibleUpdate()
    {
        //if (isInvincible == false) return;

        //invincibleTimer += Time.deltaTime;
        //if (invincibleTimer > invincibleTime)
        //{
        //    isInvincible = false;
        //}
    }

    IEnumerator BlinkEffect()
    {
        while (invincibleTimer <= invincibleTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            invincibleTimer += blinkInterval;
        }
        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    void TransformToDeath()
    {
        DisableAllGun();
        timer = 0;
        currentFrame = 0;
    }
}


 
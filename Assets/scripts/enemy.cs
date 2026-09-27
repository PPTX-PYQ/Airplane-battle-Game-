using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class  enemy : MonoBehaviour
{
    public float speed = 3;
    public int hp = 1;
    private bool isPlayDamageAni = false;
    private bool isPlayDeathAni = false;

    public Sprite[] damageSprites;
    public float frameRate = 10;
    private float timer = 0;
    private int currentFrame = 0;

    public Sprite[] deathSprites;  
    private SpriteRenderer spriteRenderer;
    private Sprite idleSprite;

    public int score = 100;

    public AudioSource deathAudio;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        idleSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();

        PlayDamageAnimationUpdate();

        PlayDeathAnimationUpdate(); 
    }
    void MoveUpdate()
    {
        if (hp > 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }//死亡后不再飞行

        if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }
      
    void PlayDamageAnimationUpdate()
    {
        if (isPlayDamageAni == false) return;

        timer += Time.deltaTime;
        if (timer > 1 / frameRate)
        {
            currentFrame++;
            timer -= 1 / frameRate;
        }

        if (currentFrame >= damageSprites.Length)
        {
            ResetIdleState();
        }
        else
        {
            spriteRenderer.sprite = damageSprites[currentFrame];
        }
    }
    void PlayDeathAnimationUpdate()
    {
        if (isPlayDeathAni == false) return;

        timer += Time.deltaTime;
        if (timer > 1 / frameRate)
        {
            currentFrame++;
            //动画帧不会闪动，需要减掉一桢的时间
            timer -= 1 / frameRate;
        }

        if (currentFrame >= deathSprites.Length)
        {
            //音效播放与视频同步
            spriteRenderer.enabled = false;
            Destroy(this.gameObject, 5);
        }
        else
        {
            spriteRenderer.sprite = deathSprites[currentFrame];
        }
    }
    void ResetIdleState()
    {
        isPlayDamageAni = false;
        this.spriteRenderer.sprite = idleSprite;
        timer = 0;
        currentFrame = 0;
    }

    void TakeDamage()
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage = 1)
    {
        if (hp <= 0) return;
        //死亡后依然可以攻击

        hp -= damage;

        if (hp <= 0)
        {
            //死亡处理
            Die();
        }
        else
        {
            //受伤处理
            ResetIdleState();
            isPlayDamageAni = true;
        }
    }
    void Die()
    {

        ResetIdleState();
        isPlayDeathAni = true;
        GetComponent<Collider2D>().enabled = false;//取消碰撞器
        gamemanager.Instance.AddScore(score);
        deathAudio.Play();
    }


}
 
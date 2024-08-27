using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private float MAX_X;
    [SerializeField] private float MIN_X;
    [SerializeField] private float MAX_Y;
    [SerializeField] private float MIN_Y;
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerBullet;
    [SerializeField] private Transform PlayerBulletPos;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject GameOverUI;

    private Animator PlayerAnimator;
    private int BoomHash = Animator.StringToHash("boom");
    private float PlayerHealth = 1f;
    private float attack_timer;
    private float current_attck_timer;
    private bool Shoot_ok;
    private float AnimTime;
    private float currentAnimTime;
    public float EnemyDamageAmmount;
    private bool PlayGameOver = false;


    // Use this for initialization
    void Start()
    {
        attack_timer = 0.35f;
        current_attck_timer = attack_timer;
        //HealthBar.GetComponent<Image>();
        //EnemyDamageAmmount = 10f;
        PlayerAnimator = GetComponent<Animator>();
        currentAnimTime = 0;
        if (Time.time < 5f)
        {
            AnimTime = 100f * 20;
        }
        else
        {
            AnimTime = 150f * Time.time;
        }

        GameOverUI.SetActive(false);
    }
    void Update()
    {
        Die();
        MoveY();
        MoveX();
        Shoot();
    }
    void MoveY()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 tempPosition = transform.position;
            if (tempPosition.y >= MAX_Y)
            {
                transform.position = tempPosition;
            }
            else
            {
                tempPosition.y += speed * Time.deltaTime;
                transform.position = tempPosition;
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 tempPosition = transform.position;
            if (tempPosition.y <= MIN_Y)
            {
                transform.position = tempPosition;
            }
            else
            {
                tempPosition.y -= speed * Time.deltaTime;
                transform.position = tempPosition;
            }
        }
    }
    void MoveX()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 tempPosition = transform.position;
            if (tempPosition.x >= MAX_X)
            {
                transform.position = tempPosition;
            }
            else
            {
                tempPosition.x += speed * Time.deltaTime;
                transform.position = tempPosition;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 tempPosition = transform.position;
            if (tempPosition.x <= MIN_X)
            {
                transform.position = tempPosition;
            }
            else
            {
                tempPosition.x -= speed * Time.deltaTime;
                transform.position = tempPosition;
            }
        }
    }
    void Shoot()
    {
        attack_timer += Time.deltaTime;

        if (attack_timer > current_attck_timer)
        {
            Shoot_ok = true;
        }

        if(Shoot_ok == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(PlayerBullet, PlayerBulletPos.position, Quaternion.identity);
                attack_timer = 0f;
                Shoot_ok = false;

                // Play SFX
                AudioManager.Instance.PlaySFX(3);
            }
        }

    }
    void TakeDamege(float DamegeAmmount)
    {
        PlayerHealth -= DamegeAmmount / 100f;
        //Debug.Log(PlayerHealth);
        Image bar = HealthBar.GetComponent<Image>();
        bar.fillAmount = PlayerHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            TakeDamege(EnemyDamageAmmount);
            //destroy the enemy here
    }

    void Die()
    {
        if (PlayGameOver != false)
        {
            AudioManager.Instance.Muisic.Stop();
            AudioManager.Instance.SFX.PlayOneShot(AudioManager.Instance.Sounds[2]);
            AudioManager.Instance.SFX.PlayOneShot(AudioManager.Instance.Sounds[4]);
        }

        if (PlayerHealth <= 0)
        {
            Time.timeScale = 1f;
            PlayGameOver = true;
            PlayerAnimator.Play(BoomHash);
            currentAnimTime += Time.time;
            if (currentAnimTime > AnimTime)
            {
                DestroyObject(Player);
                Time.timeScale = 0f;
                GameOverUI.SetActive(true);
            }
        }
    }
}
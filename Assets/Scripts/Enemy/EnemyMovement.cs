using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] private GameObject Player;
    [SerializeField] private float speed;
    private Animator animatorColntroller;
    private BoxCollider2D BoxColl;
    private int DieAnimetionHash = Animator.StringToHash("boom");

    private int killed;
    private Text ScoreText;
    private Text PontuationText;
    public float EnemyDamage;
    private bool alive;

    private float AnimationTime;
    private float currentAnimationTime;

    // Use this for initialization
   void Awake() {
            BoxColl = GetComponent<BoxCollider2D>();

            GameObject score = GameObject.FindGameObjectWithTag("Score");
            ScoreText = score.GetComponent<Text>();
            EnemyDamage = 5f;

            animatorColntroller = GetComponent<Animator>();
            alive = true;
            currentAnimationTime = 0f;
            if (Time.time < 5f)
            {
                AnimationTime = 70f * 5;
            }else {
                AnimationTime = 70f * Time.time;
            }
        }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "PlayerBullet(Clone)" || coll.gameObject.name == "Player")
        {
            BoxColl.size = new Vector2(0f,0f);

            speed = 0f;

            // Score and Killed enemies
            killed = int.Parse(ScoreText.text) + 1;
            ScoreText.text = killed.ToString();
            Time.timeScale += killed / 10000f;

            AudioManager.Instance.SFX.PlayOneShot(AudioManager.Instance.Sounds[4]);
            animatorColntroller.Play(DieAnimetionHash);

            alive = false;

            
            if (coll.gameObject.name == "PlayerBullet(Clone)")
            {
                coll.gameObject.SetActive(false);
                GameObject.DestroyObject(coll.gameObject);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        Die();
    }
     void EnemyShoot() {
         
    }

    void Die()
    {
        if (this.alive == false) {
            currentAnimationTime += Time.time;
            if (currentAnimationTime > AnimationTime)
            {
                this.gameObject.SetActive(false);
                GameObject.DestroyObject(this.gameObject);
            }
        };
    }
}

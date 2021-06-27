
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject dashEffect;
    public GameObject cap;
    public TMP_Text scoreU;
    public Data data;

    public float _damage = 0.5f;

    Vector2 moveDir;

    public float health, max_health;
    public float runSpeed;
    public float lastX, lastY;

    public bool dashCooldownOver= false;  
    public float dashSpeed;
    private float dashTime;
    public bool dashUnlocked = false;
    private float dashCooldown = 0.6f;
    public float startDashTime;
    public bool hasLazer = false;

    private float direction;
    private bool dead = false;
    

    static float data_playerSpeed = 10f, data_playerDashSpeed = 40f, data_playerDashTime = 0.005f;
    static float data_playerHealth = 5f, data_playerMaxHealth = 5f, data_fireDamage = 20f, data_lazerDamage = 40f;
    static bool data_hasLazer = false, data_dashUnlocked = false;
    public static string currentAttack = "fire";

    public float level = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        level = PlayerPrefs.GetFloat("Level", 1);
        runSpeed = 10.0f;
        //health = 5.0f;
        max_health = 5.0f;
        dashTime = startDashTime;
        runSpeed = data_playerSpeed     ;
        dashSpeed = data_playerDashSpeed ;
        dashTime = data_playerDashTime  ;
        string str = PlayerPrefs.GetString("startHealth", null);
        if (string.IsNullOrEmpty(str))
        {
            health = 5.0f;

        }
        else
            health = data_playerHealth    ;
        max_health = data_playerMaxHealth ;
        hasLazer = data_hasLazer        ;
        gameObject.GetComponent<shooting>().fireForce = data_fireDamage   ; 
        gameObject.GetComponent<shooting>().lazerForce = data_lazerDamage ;  
        dashUnlocked = data_dashUnlocked;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        data = gameObject.GetComponent<Data>();
    }

    private void Update()
    {
        string str = PlayerPrefs.GetString("startHealth", null);
        if (string.IsNullOrEmpty(str))
        {
            Debug.Log(level);
            data_playerSpeed = runSpeed;
            data_playerDashSpeed = dashSpeed;
            data_playerDashTime = dashTime;
            data_playerHealth = health;
            data_playerMaxHealth = max_health;
            data_hasLazer = hasLazer;
            data_fireDamage = gameObject.GetComponent<shooting>().fireForce;
            data_lazerDamage = gameObject.GetComponent<shooting>().lazerForce;
            data_dashUnlocked = dashUnlocked;
        }
        else
        {
            data_playerSpeed = 10.0f;
            data_playerDashSpeed = 40f;
            data_playerDashTime = 40f;
            data_playerHealth = 5f;
            data_playerMaxHealth = 5f;
            data_hasLazer = false;
            data_fireDamage = gameObject.GetComponent<shooting>().fireForce;
            data_lazerDamage = gameObject.GetComponent<shooting>().lazerForce;
            data_dashUnlocked = false;
            PlayerPrefs.DeleteKey("startHealth");
        }

        if (health <= 0){
            data_playerSpeed = 10f;
            data_playerDashSpeed = 40f;
            data_playerDashTime = 0.005f;
            data_playerHealth = 5f;
            data_playerMaxHealth = 5f;
            data_fireDamage = 20f;
            data_lazerDamage = 40f;
            data_hasLazer = false;
            data_dashUnlocked = false;
            currentAttack = "fire";
            level = 0;
            Die();
        }

        //inputs
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
            moveDir.y = Input.GetAxisRaw("Vertical");
        }

        //record last moved direction
        {
            if (moveDir.x != 0)
            {
                lastX = moveDir.x;
                lastY = 0;
            }
            if (moveDir.y != 0)
            {
                lastY = moveDir.y;
                lastX = 0;
            }
        }

        moveDir = moveDir.normalized;

        if (Input.GetKeyDown(KeyCode.LeftControl) && dashUnlocked && dashTime <= 0)
        {

            rb.AddForce(moveDir * dashSpeed * 3, ForceMode2D.Impulse);
            dashCooldownOver = true;
            dashTime = startDashTime;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }

        if (dashTime <= 0) dashCooldownOver = false;
        else dashTime -= Time.deltaTime;


        //animate movement
        {
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
            animator.SetFloat("Speed", moveDir.sqrMagnitude);
            
        }

        //animate idle
        {
            animator.SetFloat("LastH", lastX);
            animator.SetFloat("LastV", lastY);
        }
        scoreUpdate();
    }

    void scoreUpdate()
    {
        scoreU.text = "Score: " + data.score.ToString();
    }

    private void FixedUpdate()
    {

        if(!dashCooldownOver) rb.velocity = new Vector2(moveDir.x * runSpeed, moveDir.y * runSpeed);
    }

    private void Die()
    {
        if (!dead)
        {
            //play death effect
            Vector3 pos = transform.position;
            animator.SetBool("Dead", true);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject, 0.8f);
            if (dashCooldown > 0)
            {
                dashCooldown -= Time.deltaTime;
            }
            else
            {
                Instantiate(cap, pos, Quaternion.identity);
                dead = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            

        }
    }
}

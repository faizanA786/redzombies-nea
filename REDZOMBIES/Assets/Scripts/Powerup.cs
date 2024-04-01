using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject playerObject;
    public GameObject powerupDisplay;
    Text powerupText;
    Player player;
    SpriteRenderer spriteRenderer;

    float powerupDisplayTimer = 0;
    bool activated = false;
    float powerupTimer = 0;
    int originalHealth;
    int powerupType;
    float deathTimer = 15f;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        powerupDisplay = GameObject.Find("PowerupText");

        spriteRenderer = GetComponent<SpriteRenderer>();
        player = playerObject.GetComponent<Player>();
        powerupText = powerupDisplay.GetComponent<Text>();
    }

    void Update()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0 && activated == false)
        {
            Destroy(gameObject);
        }

        //Check for colliders in the circle on a specific layer
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, playerLayer);

        //loop through all colliders
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == playerObject && activated == false)
            {
                activated = true;
                spriteRenderer.color = new Color(0, 0, 0, 0);
                int randomChance = Random.Range(1,6); //Generate num from 1-5
                powerupType = randomChance;
                switch (randomChance)
                {
                    case 1: //On the case that random chance == 1
                        MaxAmmo();
                        break; //Break so that other cases cannot be executed

                    case 2:
                        PlayerSpeedBoost();
                        break;

                    case 3:
                        InstantKill();
                        break;

                    case 4:
                        DoublePoints();
                        break;

                    case 5:
                        Invincible();
                        break;

                    default: //If none of the cases were matched
                        break;
                }
            }
        }

        powerupDisplayTimer -= Time.deltaTime;
        if (powerupDisplayTimer <= 0 && activated == true)
        {
            powerupText.text = "";
            
        }

        powerupTimer -= Time.deltaTime;
        if (powerupTimer <= 0 && activated == true)
        {
            switch (powerupType) //reset powerup effect
            {
                case 2: //stop speed boost
                    player.movementSpeed /= 2;
                    break;

                case 3: //stop instant kill
                    Enemy.instantKill = false;
                    ExploderEnemy.instantKill = false;
                    break;

                case 4: //stop double points
                    Enemy.doublePoints = 1;
                    ExploderEnemy.doublePoints = 1;
                    break;

                case 5: //stop invincible
                    player.playerHealth = originalHealth;
                    break;
            }
            Destroy(gameObject);
        }
    }

    void MaxAmmo()
    {
        powerupDisplayTimer = 2.5f;
        powerupTimer = 10f;
        powerupText.text = "MAX AMMO!";
        switch (player.weaponSelected)
        {
            case 1: //If weapon selected is pistol (1)
                player.bulletCapacity = 100;
                break;

            case 2: //Assualt rifle (2)
                player.bulletCapacity = 500;
                break;

            case 3: //Shotgun (3)
                player.bulletCapacity = 300;
                break;

            case 4: //Rocket launcher (4)
                player.bulletCapacity = 80;
                break;

            default:
                Debug.Log("Max ammo not activated!");
                break;
        }
        Debug.Log("Max ammo!");
    }
    void PlayerSpeedBoost()
    {
        powerupDisplayTimer = 10f;
        powerupTimer = 10f;
        powerupText.text = "SPEED BOOST!";
        player.movementSpeed *= 2;
        Debug.Log("Speed boost!");
    }
    void InstantKill()
    {
        powerupDisplayTimer = 10f;
        powerupTimer = 10f;
        powerupText.text = "INSTAKILL!";
        Enemy.instantKill = true;
        ExploderEnemy.instantKill = true;
        Debug.Log("Insta kill!");
    }
    void DoublePoints()
    {
        powerupDisplayTimer = 10f;
        powerupTimer = 10f;
        Enemy.doublePoints = 2;
        ExploderEnemy.doublePoints = 2;
        powerupText.text = "DOUBLE POINTS!";
        Debug.Log("Double points!");
    }
    void Invincible()
    {
        powerupDisplayTimer = 10f;
        powerupTimer = 10f;
        originalHealth = player.playerHealth;
        player.playerHealth = 99;
        powerupText.text = "INVINCIBLE!";
        Debug.Log("Invincible!");
    }
}

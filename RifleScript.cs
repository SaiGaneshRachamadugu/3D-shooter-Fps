using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RifleScript : MonoBehaviour {
    private float damage = 30f;
    private float range = 100f;
    private int enemies = 8;

    public ParticleSystem muzzleFlash;
    public AudioClip shootSound;
    public AudioClip dieSound;
    public Text enemiesText;

    public Camera fpsCam;

    private void Start() {
        
    }
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        ShowEnemies();
    }

    void Shoot() {
        muzzleFlash.Play();
        GetComponent<AudioSource>().PlayOneShot(shootSound, 1);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            if (enemy != null) {
                if (enemy.health - damage <= 0f) killEnemy();
                enemy.takedamage(damage);
            }
        }
    }

    public void killEnemy() {
        enemies--;
        GetComponent<AudioSource>().PlayOneShot(dieSound, 1);
    }

    public void ShowEnemies() {
        string message = enemies.ToString();
        enemiesText.text = message;
    }

    

}


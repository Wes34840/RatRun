using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D hitbox;
    public AudioClip splat;
    public AudioClip splash;
    private AudioSource source;
    SpriteRenderer sr;
    [SerializeField] private Sprite[] deathSprites;
    internal PlayerMovement pm;
    void Start()
    {
        hitbox= GetComponent<BoxCollider2D>();
        sr= GetComponent<SpriteRenderer>();
        pm= GetComponent<PlayerMovement>();
        source= GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("hit by car");
            Die("Roadkill");
        }
    }
    internal async void Die(string type)
    {
        switch (type)
        {
            case "Drowning":
                sr.sprite = deathSprites[0];
                source.PlayOneShot(splash, 1f);
                OpenScene();
                
                break;

            case "Roadkill":
                sr.sprite = deathSprites[1];
                source.PlayOneShot(splat, 1f);
                OpenScene();
      
                break;
        }
        pm.enabled = false;
    }
    async private void OpenScene()
    {
        await Task.Delay(3000);
        SceneManager.LoadScene(sceneName: "MainMenu");

    }

}

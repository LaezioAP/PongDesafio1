using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Ball : MonoBehaviour
{
    public float speed;
    public TrailRenderer trailRenderer;
    private Rigidbody2D rig;
    public SpriteRenderer sprite;
    float maxSpeed = 18.0f;

    PaddleJuice paddleJuice;

    public GameObject explosionEffect;

    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip explode;
    public AudioClip hit;
    public AudioClip gameOver;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayBall());
    }

    void Launch()
    {
        audioSource.PlayOneShot(hit);

        Vector2 direction = Vector2.zero;

        // Esquerda
        if (Random.value < 0.5f)
        {
            direction = Vector2.left;
        }
        // Direita
        else
        {
            direction = Vector2.right;
        }

        direction.y = Random.Range(-0.5f, 0.5f);

        rig.linearVelocity = direction * speed;
    }

    public void ResetBall()
    {
        PlayExplosionAndGameOverAudio();
        GameSettings.BounceForce = 15; // Reseta a força de rebote para o valor inicial


        SpawnExplosionEffect();
        rig.linearVelocity = Vector2.zero;
        trailRenderer.Clear();
        trailRenderer.enabled = false;
        transform.position = Vector2.zero;

        trailRenderer.enabled = true;


        StartCoroutine(PlayBall());
    }

    IEnumerator PlayBall()
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sprite.enabled = true;

        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            other.gameObject.GetComponent<PaddleJuice>().PlayHitEffect();
            BallEffectJuice();
        }

        if (other.gameObject.layer == 6)
        {
            BallEffectJuice();
        }
    }

    void BallEffectJuice()
    {
        audioSource.PlayOneShot(hit);

        sprite.transform.DOKill();
        sprite.transform.localScale = Vector3.one;
        sprite.transform.DOScale(1.8f, 0.1f).SetLoops(2, LoopType.Yoyo);


        Camera.main.transform.DOKill();
        Camera.main.transform.DOShakePosition(
            0.1f, // Duration
            0.2f, // Força do shake
            10, // Vibrações 
            90, // aleatoriedade do shake
            false, // não mudar o eixo z
            true // fade out do shake
            );
    }

    void SpawnExplosionEffect()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 2f);
    }

    void PlayExplosionAndGameOverAudio()
    {
        audioSource.PlayOneShot(explode);
        audioSource.PlayOneShot(gameOver);
    }
}

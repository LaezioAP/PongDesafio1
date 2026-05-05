using DG.Tweening;
using System;
using UnityEngine;

public class PaddleJuice : MonoBehaviour
{
    public Transform paddleSprite;
    public void PlayHitEffect()
    {
        paddleSprite.transform.DOKill();
        paddleSprite.transform.localScale = Vector3.one; // Reseta antes de começar
        paddleSprite.transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRig = other.gameObject.GetComponent<Rigidbody2D>();

            float yOffset = other.transform.position.y - transform.position.y;
            float paddleHeight = GetComponent<Collider2D>().bounds.size.y;
            float normalizedY = yOffset / (paddleHeight / 2f);

            // Se a velocidade for menor que 0, vai pra esquerda (-1), senão vai pra direita (1)
            float dirX = ballRig.linearVelocity.x < 0 ? -1f : 1f;

            Vector2 direction = new Vector2(dirX, normalizedY).normalized;

            if (GameSettings.cpuDifficulty == 1.0f && GameSettings.BounceForce < 20)
            {
                GameSettings.BounceForce += 1;
                Debug.Log("Dificuldade Máxima: Aumentando força de rebote para " + GameSettings.BounceForce);
            }

            ballRig.linearVelocity = direction * GameSettings.BounceForce;

            Debug.Log("Velocidade da bola após bater na raquete: " + ballRig.linearVelocity.magnitude);

        }

    }
}

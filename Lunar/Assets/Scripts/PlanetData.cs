using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class PlanetData : MonoBehaviour
    {
        private PlayerController playerController;
        private SpriteRenderer spriteRenderer;
        private CircleCollider2D circleCollider;

        private AudioSource source;
        [SerializeField] private AudioClip upgradeSound;

        [Header("Styx")]
        [SerializeField] private float styxSpeed;
        [SerializeField] private float styxAcceleration;
        [SerializeField] private float styxDeceleration;
        [SerializeField] private float styxColliderRadius;
        [SerializeField] private float styxInnerGlow;
        [SerializeField] private float styxOuterGlow;
        
        [Header("Nix")]
        [SerializeField] private float nixSpeed;
        [SerializeField] private float nixAcceleration;
        [SerializeField] private float nixDeceleration;
        [SerializeField] private float nixColliderRadius;
        [SerializeField] private float nixInnerGlow;
        [SerializeField] private float nixOuterGlow;
        
        [Header("Kerberos")]
        [SerializeField] private float kerberosSpeed;
        [SerializeField] private float kerberosAcceleration;
        [SerializeField] private float kerberosDeceleration;
        [SerializeField] private float kerberosColliderRadius;
        [SerializeField] private float kerberosInnerGlow;
        [SerializeField] private float kerberosOuterGlow;
        
        [Header("Hydra")]
        [SerializeField] private float hydraSpeed;
        [SerializeField] private float hydraAcceleration;
        [SerializeField] private float hydraDeceleration;
        [SerializeField] private float hydraColliderRadius;
        [SerializeField] private float hydraInnerGlow;
        [SerializeField] private float hydraOuterGlow;
        
        [Header("Charon")]
        [SerializeField] private float charonSpeed;
        [SerializeField] private float charonAcceleration;
        [SerializeField] private float charonDeceleration;
        [SerializeField] private float charonColliderRadius;
        [SerializeField] private float charonInnerGlow;
        [SerializeField] private float charonOuterGlow;

        [Header("State")]
        [SerializeField]
        private State startingState;

        [Header("Sprites")]
        [SerializeField]
        private Sprite styxSprite;
        [SerializeField]
        private Sprite nixSprite;
        [SerializeField]
        private Sprite kerberosSprite;
        [SerializeField]
        private Sprite hydraSprite;
        [SerializeField]
        private Sprite charonSprite;
        [SerializeField] private SpriteRenderer glowOuterRenderer;
        [SerializeField] private SpriteRenderer glowInnerRenderer;

        private GameObject moonUI;

        private enum State
        {
            Styx,
            Nix,
            Kerberos,
            Hydra,
            Charon
        }

        private State currentPlanet;

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            circleCollider = GetComponent<CircleCollider2D>();
            currentPlanet = startingState;
            moonUI = GameObject.FindWithTag("MoonUI");
            source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
        }

        private void Update()
        {
            switch(currentPlanet)
            {
                case State.Styx:
                    playerController.speed = styxSpeed;
                    playerController.acceleration = styxAcceleration;
                    playerController.deceleration = styxDeceleration;
                    spriteRenderer.sprite = styxSprite;
                    glowOuterRenderer.transform.localScale = Vector3.one * styxOuterGlow;
                    glowInnerRenderer.transform.localScale = Vector3.one * styxInnerGlow;
                    circleCollider.radius = styxColliderRadius;
                    break;
                case State.Nix:
                    playerController.speed = nixSpeed;
                    playerController.acceleration = nixAcceleration;
                    playerController.deceleration = nixDeceleration;
                    spriteRenderer.sprite = nixSprite;
                    glowOuterRenderer.transform.localScale = Vector3.one * nixOuterGlow;
                    glowInnerRenderer.transform.localScale = Vector3.one * nixInnerGlow;
                    circleCollider.radius = nixColliderRadius;
                    break;
                case State.Kerberos:
                    playerController.speed = kerberosSpeed;
                    playerController.acceleration = kerberosAcceleration;
                    playerController.deceleration = kerberosDeceleration;
                    spriteRenderer.sprite = kerberosSprite;
                    glowOuterRenderer.transform.localScale = Vector3.one * kerberosOuterGlow;
                    glowInnerRenderer.transform.localScale = Vector3.one * kerberosInnerGlow;
                    circleCollider.radius = kerberosColliderRadius;
                    break;
                case State.Hydra:
                    playerController.speed = hydraSpeed;
                    playerController.acceleration = hydraAcceleration;
                    playerController.deceleration = hydraDeceleration;
                    spriteRenderer.sprite = hydraSprite;
                    glowOuterRenderer.transform.localScale = Vector3.one * hydraOuterGlow;
                    glowInnerRenderer.transform.localScale = Vector3.one * hydraInnerGlow;
                    circleCollider.radius = hydraColliderRadius;
                    break;
                case State.Charon:
                    playerController.speed = charonSpeed;
                    playerController.acceleration = charonAcceleration;
                    playerController.deceleration = charonDeceleration;
                    spriteRenderer.sprite = charonSprite;
                    glowOuterRenderer.transform.localScale = Vector3.one * charonOuterGlow;
                    glowInnerRenderer.transform.localScale = Vector3.one * charonInnerGlow;
                    circleCollider.radius = charonColliderRadius;
                    break;
            }
        }

        public void SwitchNextMoon()
        {
            var nextMoon = (int) currentPlanet;
            if (nextMoon <= 4)
            {
                nextMoon += 1;
            }
            currentPlanet = (State) nextMoon;

            handleMoonUI(nextMoon, false);
        }
        
        public void SwitchPreviousMoon()
        {
            var nextMoon = ((int) currentPlanet) - 1;
            currentPlanet = (State) nextMoon;

            handleMoonUI(nextMoon, true);
        }

        private void handleMoonUI(int newMoon, bool collided)
        {
            if(newMoon >= 0)
            {
                if (collided)
                {
                    moonUI.transform.GetChild(newMoon+1).GetComponent<CanvasGroup>().alpha = 0.4f;
                } else
                {
                    source.clip = upgradeSound;
                    source.Play();
                    moonUI.transform.GetChild(newMoon).GetComponent<CanvasGroup>().alpha = 1;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class PlanetData : MonoBehaviour
    {
        private PlayerController playerController;
        private SpriteRenderer spriteRenderer;

        [Header("Styx")]
        [SerializeField]
        internal float styxSpeed;
        [SerializeField]
        internal float styxAcceleration;
        [SerializeField]
        internal float styxDeceleration;
        [Header("Nix")]
        [SerializeField]
        internal float nixSpeed;
        [SerializeField]
        internal float nixAcceleration;
        [SerializeField]
        internal float nixDeceleration;
        [Header("Kerberos")]
        [SerializeField]
        internal float kerberosSpeed;
        [SerializeField]
        internal float kerberosAcceleration;
        [SerializeField]
        internal float kerberosDeceleration;
        [Header("Hydra")]
        [SerializeField]
        internal float hydraSpeed;
        [SerializeField]
        internal float hydraAcceleration;
        [SerializeField]
        internal float hydraDeceleration;
        [Header("Charon")]
        [SerializeField]
        internal float charonSpeed;
        [SerializeField]
        internal float charonAcceleration;
        [SerializeField]
        internal float charonDeceleration;

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
            currentPlanet = startingState;
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
                    break;
                case State.Nix:
                    playerController.speed = nixSpeed;
                    playerController.acceleration = nixAcceleration;
                    playerController.deceleration = nixDeceleration;
                    spriteRenderer.sprite = nixSprite;
                    break;
                case State.Kerberos:
                    playerController.speed = kerberosSpeed;
                    playerController.acceleration = kerberosAcceleration;
                    playerController.deceleration = kerberosDeceleration;
                    spriteRenderer.sprite = kerberosSprite;
                    break;
                case State.Hydra:
                    playerController.speed = hydraSpeed;
                    playerController.acceleration = hydraAcceleration;
                    playerController.deceleration = hydraDeceleration;
                    spriteRenderer.sprite = hydraSprite;
                    break;
                case State.Charon:
                    playerController.speed = charonSpeed;
                    playerController.acceleration = charonAcceleration;
                    playerController.deceleration = charonDeceleration;
                    spriteRenderer.sprite = charonSprite;
                    break;
            }
        }

        public void SwitchNextMoon()
        {
            var nextMoon = (int) currentPlanet;
            nextMoon++;
            currentPlanet = (State) nextMoon;
        }
    }
}

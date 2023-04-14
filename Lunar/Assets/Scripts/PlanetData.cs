using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarJam
{
    public class PlanetData : MonoBehaviour
    {
        private PlayerController playerController;

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
                    break;
                case State.Nix:
                    playerController.speed = nixSpeed;
                    playerController.acceleration = nixAcceleration;
                    playerController.deceleration = nixDeceleration;
                    break;
                case State.Kerberos:
                    playerController.speed = kerberosSpeed;
                    playerController.acceleration = kerberosAcceleration;
                    playerController.deceleration = kerberosDeceleration;
                    break;
                case State.Hydra:
                    playerController.speed = hydraSpeed;
                    playerController.acceleration = hydraAcceleration;
                    playerController.deceleration = hydraDeceleration;
                    break;
                case State.Charon:
                    playerController.speed = charonSpeed;
                    playerController.acceleration = charonAcceleration;
                    playerController.deceleration = charonDeceleration;
                    break;
            }
        }
    }
}

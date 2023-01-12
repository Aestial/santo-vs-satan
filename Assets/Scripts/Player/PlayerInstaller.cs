using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Santos
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private Player m_Player;
        private void Awake()
        {
            if (m_Player == null)
            {
                m_Player = FindObjectOfType<Player>();
            }
            m_Player.Configure(
                GetInput()
            );
        }

        private IInput GetInput()
        {
            return new UnityInputManagerAdapter();
        }
    }
}

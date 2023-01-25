using Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        [FormerlySerializedAs("m_Player")] [SerializeField] private Player player;
        private void Awake()
        {
            if (player == null)
            {
                player = FindObjectOfType<Player>();
            }
            player.Configure(
                GetInput()
            );
        }

        private static IInput GetInput()
        {
            return new UnityInputManagerAdapter();
        }
    }
}

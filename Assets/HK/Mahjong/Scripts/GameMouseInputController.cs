using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace HK.Mahjong
{
    /// <summary>
    /// ゲーム中のマウスの入力を制御するクラス
    /// </summary>
    public sealed class GameMouseInputController : MonoBehaviour
    {
        /// <summary>
        /// ゲーム画面を描画している<see cref="Camera"/>
        /// </summary>
        [SerializeField]
        private Camera gameCamera = default;

        /// <summary>
        /// クリックの検知する<see cref="InputAction"/>
        /// </summary>
        [SerializeField]
        private InputAction click = default;

        private void Awake()
        {
            click.performed += (context) => OnClick();
        }

        private void OnEnable()
        {
            click.Enable();
        }

        private void OnDisable()
        {
            click.Disable();
        }

        private void OnClick()
        {
            var position = Mouse.current.position.ReadValue();

            if(Physics.Raycast(gameCamera.ScreenPointToRay(position, Camera.MonoOrStereoscopicEye.Mono), out var hitInfo))
            {
                var clickable = hitInfo.collider.GetComponent<IClickable>();
                clickable?.OnClicked();
            }
        }
    }
}

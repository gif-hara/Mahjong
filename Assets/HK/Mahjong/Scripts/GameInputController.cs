using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace HK.Mahjong
{
    /// <summary>
    /// ゲーム中のキー入力の制御を行うクラス
    /// </summary>
    public sealed class GameInputController : MonoBehaviour
    {
        [SerializeField]
        private InputAction selectTile0 = default;

        [SerializeField]
        private InputAction selectTile1 = default;

        [SerializeField]
        private InputAction selectTile2 = default;

        [SerializeField]
        private InputAction selectTile3 = default;

        [SerializeField]
        private InputAction selectTile4 = default;

        [SerializeField]
        private InputAction selectTile5 = default;

        [SerializeField]
        private InputAction selectTile6 = default;

        [SerializeField]
        private InputAction selectTile7 = default;

        [SerializeField]
        private InputAction selectTile8 = default;

        [SerializeField]
        private InputAction selectTile9 = default;

        [SerializeField]
        private InputAction selectTile10 = default;

        [SerializeField]
        private InputAction selectTile11 = default;

        [SerializeField]
        private InputAction selectTile12 = default;

        [SerializeField]
        private InputAction selectTile13 = default;

        private void Awake()
        {
            selectTile0.performed += context => SelectTile(0);
            selectTile1.performed += context => SelectTile(1);
            selectTile2.performed += context => SelectTile(2);
            selectTile3.performed += context => SelectTile(3);
            selectTile4.performed += context => SelectTile(4);
            selectTile5.performed += context => SelectTile(5);
            selectTile6.performed += context => SelectTile(6);
            selectTile7.performed += context => SelectTile(7);
            selectTile8.performed += context => SelectTile(8);
            selectTile9.performed += context => SelectTile(9);
            selectTile10.performed += context => SelectTile(10);
            selectTile11.performed += context => SelectTile(11);
            selectTile12.performed += context => SelectTile(12);
            selectTile13.performed += context => SelectTile(13);
        }

        private void OnEnable()
        {
            selectTile0.Enable();
            selectTile1.Enable();
            selectTile2.Enable();
            selectTile3.Enable();
            selectTile4.Enable();
            selectTile5.Enable();
            selectTile6.Enable();
            selectTile7.Enable();
            selectTile8.Enable();
            selectTile9.Enable();
            selectTile10.Enable();
            selectTile11.Enable();
            selectTile12.Enable();
            selectTile13.Enable();
        }

        private void OnDisable()
        {
            selectTile0.Disable();
            selectTile1.Disable();
            selectTile2.Disable();
            selectTile3.Disable();
            selectTile4.Disable();
            selectTile5.Disable();
            selectTile6.Disable();
            selectTile7.Disable();
            selectTile8.Disable();
            selectTile9.Disable();
            selectTile10.Disable();
            selectTile11.Disable();
            selectTile12.Disable();
            selectTile13.Disable();
        }

        private void SelectTile(int index)
        {
            GameInputEvent.SelectTile.OnNext(index);
        }
    }
}

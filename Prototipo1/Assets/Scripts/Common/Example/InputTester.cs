using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XInputDotNetPure;

namespace TellInput {



    public class InputTester : MonoBehaviour {
        public bool isPress;
        public bool isPressLeft;
        public Text TextInfo;
        public int buttonCheck;
        public float xCheck;
        public float yCheck;

        private void Start() {
            InputChecker.OnGamepadConnected += HandleGamepadConnection;
            InputChecker.OnGamepadDisconnected += HandleGamepadDisconnection;
        }

        private void HandleGamepadDisconnection(IntellGamePad gpad) {
            gpad.OnButtonPressed -= HandleButtonPressed;
            gpad.OnButtonHold -= HandleButtonHold;
            gpad.OnButtonReleased -= HandleButtonReleased;
            gpad.OnAxisUsed -= HandleAxisUsed;
            gpad.OnAxisStopUsed -= HandleAxisStopUsed;
            Debug.LogFormat("Gamepad disconnesso: {0}", gpad.ID);
        }

        private void HandleGamepadConnection(IntellGamePad gpad) {
            gpad.OnButtonPressed += HandleButtonPressed;
            gpad.OnButtonHold += HandleButtonHold;
            gpad.OnButtonReleased += HandleButtonReleased;
            gpad.OnAxisUsed += HandleAxisUsed;
            gpad.OnAxisStopUsed += HandleAxisStopUsed;
            Debug.LogFormat("Gamepad connesso: {0}", gpad.ID);
        }

        private void HandleAxisUsed(IntellGamePad gpad, IntellGamePad.Buttons button, IntellGamePad.AxisValue values) {
            Debug.LogFormat("Gamepad {0} axis {1} used, values: {2},{3}", gpad.ID, button, values.X, values.Y);
            if (button == IntellGamePad.Buttons.LeftStick && gpad.ID == 0 && GameManager.singleton.tm.isTurn == true)
            {
                buttonCheck = (int)button;
                xCheck = values.X;
                yCheck = values.Y;
            }
            else if(button == IntellGamePad.Buttons.LeftStick && gpad.ID == 1 && GameManager.singleton.tm.isTurn == false)
            {
                buttonCheck = (int)button;
                xCheck = values.X;
                yCheck = values.Y;
            }
        }

        private void HandleAxisStopUsed(IntellGamePad gpad, IntellGamePad.Buttons button, IntellGamePad.AxisValue values) {
            Debug.LogFormat("Gamepad {0} axis {1} stopped use, values: {2},{3}", gpad.ID, button, values.X, values.Y);
            if (button == IntellGamePad.Buttons.LeftStick && gpad.ID == 0 && GameManager.singleton.tm.isTurn == true)
            {
                buttonCheck = (int)button;
                xCheck = values.X;
                yCheck = values.Y;
            }
            else if (button == IntellGamePad.Buttons.LeftStick && gpad.ID == 1 && GameManager.singleton.tm.isTurn == false)
            {
                buttonCheck = (int)button;
                xCheck = values.X;
                yCheck = values.Y;
            }
        }

        private void HandleButtonHold(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button hold {1}", gpad.ID, button);
            if (button == IntellGamePad.Buttons.Start && gpad.ID == 0 && GameManager.singleton.tm.isTurn == true)
            {
                buttonCheck = (int)button;
            }
           else if (button == IntellGamePad.Buttons.Start && gpad.ID == 1 && GameManager.singleton.tm.isTurn == false)
            {
                buttonCheck = (int)button;
            }
        }

        private void HandleButtonReleased(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button released {1}", gpad.ID, button);
          
        }

        private void HandleButtonPressed(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button pressed {1}", gpad.ID, button);
            if (button == IntellGamePad.Buttons.X && gpad.ID == 0 && GameManager.singleton.tm.isTurn == true)
            {
                buttonCheck = (int)button;
            }
            else if (button == IntellGamePad.Buttons.X && gpad.ID == 1 && GameManager.singleton.tm.isTurn == false)
            {
                buttonCheck = (int)button;
            }
        }

        // Update is called once per frame
        void Update() {

            int c = InputChecker.instance.Activegamepads.Count;

            string textToRead = "";

            for (int i = 0; i < 4; i++) {
                bool chk = c > i;

                if (chk) {
                    textToRead += "gamepad " + i + "(id : " + InputChecker.instance.Activegamepads[i].ID + ")  connected : true";
                    textToRead += Environment.NewLine;
                } else {
                    textToRead += "gamepad " + i + " connected : false";
                    textToRead += Environment.NewLine;
                }
            }

            //TextInfo.text = textToRead;

        }

        private void OnDisable() {
            InputChecker.OnGamepadConnected -= HandleGamepadConnection;
            InputChecker.OnGamepadDisconnected -= HandleGamepadDisconnection;
        }
    }


}
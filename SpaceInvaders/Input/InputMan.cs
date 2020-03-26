using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputMan
    {
        public InputMan()
        {
            this.pSubjectArrowRight = new InputSubject();
            this.pSubjectArrowLeft = new InputSubject();
            this.pSubjectAKey = new InputSubject();
            this.pSubjectDKey = new InputSubject();
            this.pSubjectPeriod = new InputSubject();
            this.pSubjectComma = new InputSubject();
            this.pSubjectSpace = new InputSubject();
            this.pSubjectSKey = new InputSubject();
            this.pSubjectCursor = new InputSubject();
            this.pSubjectLeftMouseKey = new InputSubject();
            this.pSubjectRightMouseKey = new InputSubject();

            this.privSpaceKeyPrev = false;
            this.privSKeyPrev = false;
            this.privPeriodKeyPrev = false;
            this.privCommaKeyPrev = false;
            this.privMouseLeftKeyPrev = false;
            this.privMouseRightKeyPrev = false;
        }

        private static InputMan privGetInstance()
        {
            if (pInstance == null)
            {
                pInstance = new InputMan();
            }
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        public static InputSubject GetCommaSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            return pMan.pSubjectComma;
        }

        public static InputSubject GetPeriodSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            return pMan.pSubjectPeriod;
        }

        public static InputSubject GetKeyASubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectAKey;
        }

        public static InputSubject GetKeyDSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectDKey;
        }

        public static InputSubject GetKeySSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectSKey;
        }

        public static InputSubject GetArrowRightSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowLeft;
        }

        public static InputSubject GetCursorSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectCursor;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectSpace;
        }

        public static InputSubject GetMouseLeftKeySubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectLeftMouseKey;
        }

        public static InputSubject GetMouseRightKeySubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectRightMouseKey;
        }

        public static void Update()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            float xCurs = -1;
            float yCurs = -1;
            Azul.Input.GetCursor(ref xCurs, ref yCurs);

            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.pSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.pSubjectArrowRight.Notify();
            }

            // AKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_A) == true)
            {
                pMan.pSubjectAKey.Notify();
            }

            // DKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_D) == true)
            {
                pMan.pSubjectDKey.Notify();
            }

            // SKey: (with key history) -----------------------------------------------------------
            bool sKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_S);
            if (sKeyCurr == true && pMan.privSKeyPrev == false)
            {
                pMan.pSubjectSKey.Notify();
            }
            pMan.privSKeyPrev = sKeyCurr;

            // PeriodKey: (with key history) -----------------------------------------------------------
            bool periodKeycurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_PERIOD);
            if (periodKeycurr == true && pMan.privPeriodKeyPrev == false)
            {
                pMan.pSubjectPeriod.Notify();
            }
            pMan.privPeriodKeyPrev = periodKeycurr;

            // CommaKey: (with key history) -----------------------------------------------------------
            bool commaKeycurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_COMMA);
            if (commaKeycurr == true && pMan.privCommaKeyPrev == false)
            {
                pMan.pSubjectComma.Notify();
            }
            pMan.privCommaKeyPrev = commaKeycurr;

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.pSubjectSpace.Notify();
            }
            pMan.privSpaceKeyPrev = spaceKeyCurr;

            // MouseLeft: (with key history) -----------------------------------------------------------
            bool mouseLeftKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_MOUSE.BUTTON_LEFT);
            if (mouseLeftKeyCurr == true && pMan.privMouseLeftKeyPrev == false)
            {
                pMan.pSubjectLeftMouseKey.Notify(xCurs, yCurs);
            }
            pMan.privMouseLeftKeyPrev = mouseLeftKeyCurr;

            // MouseRight: (with key history) -----------------------------------------------------------
            bool mouseRightKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_MOUSE.BUTTON_RIGHT);
            if (mouseRightKeyCurr == true && pMan.privMouseRightKeyPrev == false)
            {
                pMan.pSubjectRightMouseKey.Notify(xCurs, yCurs);
            }
            pMan.privMouseRightKeyPrev = mouseRightKeyCurr;

            pMan.pSubjectCursor.Notify(xCurs, yCurs);

        }

        public static void SetActive(InputMan pMan)
        {
            InputMan.pInstance = pMan;
        }

        public static InputMan GetActive()
        {
            return InputMan.pInstance;
        }

        // Data: ----------------------------------------------
        private static InputMan pInstance = null;
        private bool privSpaceKeyPrev;
        private bool privSKeyPrev;
        private bool privPeriodKeyPrev;
        private bool privCommaKeyPrev;
        private bool privMouseLeftKeyPrev;
        private bool privMouseRightKeyPrev;

        private InputSubject pSubjectLeftMouseKey;
        private InputSubject pSubjectAKey;
        private InputSubject pSubjectRightMouseKey;
        private InputSubject pSubjectDKey;
        private InputSubject pSubjectComma; // toggle shield bricks
        private InputSubject pSubjectPeriod; // toggle box sprite rendering
        private InputSubject pSubjectArrowRight;
        private InputSubject pSubjectArrowLeft;
        private InputSubject pSubjectSpace;
        private InputSubject pSubjectSKey;
        private InputSubject pSubjectCursor;
    }
}

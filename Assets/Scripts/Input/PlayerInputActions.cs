using InControl;

namespace LD45Jam
{
    public class PlayerInputActions : PlayerActionSet
    {
        // Movement
        public PlayerAction Left;
        public PlayerAction Right;
        public PlayerAction Up;
        public PlayerAction Down;
        public PlayerTwoAxisAction Move;

        // Rotation (Look)
        public PlayerAction LookLeft;
        public PlayerAction LookRight;
        public PlayerAction LookUp;
        public PlayerAction LookDown;
        public PlayerTwoAxisAction Look;

        // Buttons
        public PlayerAction Start;
        public PlayerAction Button1;
        public PlayerAction Button2;
        public PlayerAction Button3;

        public PlayerInputActions()
        {
            // Movement
            Left = CreatePlayerAction("Left");
            Right = CreatePlayerAction("Right");
            Up = CreatePlayerAction("Up");
            Down = CreatePlayerAction("Down");
            Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

            // Rotation (Look)
            LookLeft = CreatePlayerAction("LookLeft");
            LookRight = CreatePlayerAction("LookRight");
            LookUp = CreatePlayerAction("LookUp");
            LookDown = CreatePlayerAction("LookDown");
            Look = CreateTwoAxisPlayerAction(LookLeft, LookRight, LookDown, LookUp);

            // Buttons
            Start = CreatePlayerAction("Start");
            Button1 = CreatePlayerAction("Button 1");
            Button2 = CreatePlayerAction("Button 2");
            Button3 = CreatePlayerAction("Button 3");

            SetDefaultBindings();
        }

        public void SetDefaultBindings()
        {
            // Left
            Left.AddDefaultBinding(Key.LeftArrow);
            Left.AddDefaultBinding(Key.A);
            Left.AddDefaultBinding(InputControlType.DPadLeft);
            Left.AddDefaultBinding(InputControlType.LeftStickLeft);

            // Right
            Right.AddDefaultBinding(Key.RightArrow);
            Right.AddDefaultBinding(Key.D);
            Right.AddDefaultBinding(InputControlType.DPadRight);
            Right.AddDefaultBinding(InputControlType.LeftStickRight);

            // Up
            Up.AddDefaultBinding(Key.UpArrow);
            Up.AddDefaultBinding(Key.W);
            Up.AddDefaultBinding(InputControlType.DPadUp);
            Up.AddDefaultBinding(InputControlType.LeftStickUp);

            // Down
            Down.AddDefaultBinding(Key.DownArrow);
            Down.AddDefaultBinding(Key.S);
            Down.AddDefaultBinding(InputControlType.DPadDown);
            Down.AddDefaultBinding(InputControlType.LeftStickDown);

            // LookLeft
            LookLeft.AddDefaultBinding(Key.Q);
            //LookLeft.AddDefaultBinding(Mouse.NegativeX);
            LookLeft.AddDefaultBinding(InputControlType.RightStickLeft);

            // LookRight
            LookRight.AddDefaultBinding(Key.E);
            //LookRight.AddDefaultBinding(Mouse.PositiveX);
            LookRight.AddDefaultBinding(InputControlType.RightStickRight);

            // LookUp
            //LookUp.AddDefaultBinding(Mouse.PositiveY);
            LookUp.AddDefaultBinding(InputControlType.RightStickUp);

            // LookDown
            //LookDown.AddDefaultBinding(Mouse.NegativeY);
            LookDown.AddDefaultBinding(InputControlType.RightStickDown);

            // Start
            Start.AddDefaultBinding(Key.Return);
            Start.AddDefaultBinding(Key.PadEnter);
            Start.AddDefaultBinding(InputControlType.Start);

            // Button 1
            Start.AddDefaultBinding(Key.Space);
            Button1.AddDefaultBinding(InputControlType.Button0);

            // Button 2
            Button2.AddDefaultBinding(Key.K);
            Button2.AddDefaultBinding(InputControlType.Button1);

            // Button 3
            Button2.AddDefaultBinding(Key.L);
            Button2.AddDefaultBinding(InputControlType.Button2);
        }
    }
}

﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimaXNA.Input;

namespace UltimaXNA.UILegacy.Gumplings
{
    enum ButtonTypes
    {
        Default = 0,
        SwitchPage = 0,
        Activate = 1
    }

    class Button : Control
    {
        Texture2D _gumpUp = null;
        Texture2D _gumpDown = null;
        Texture2D _gumpOver = null;
        Texture2D _texture = null;
        int _gumpID1 = 0, _gumpID2 = 0, _gumpID3 = 0; // 1 == up, 2 == down, 3 == additional over state, not sent by the server but can be added for clientside gumps.
        public int GumpOverID { set { _gumpID3 = value; } }

        public ButtonTypes ButtonType = ButtonTypes.Default;
        public int ButtonParameter = 0;
        public int ButtonID = 0;

        public Button(Control owner, int page)
            : base(owner, page)
        {
            HandlesMouseInput = true;
        }

        public Button(Control owner, int page, string[] arguements)
            : this(owner, page)
        {
            int x, y, gumpID1, gumpID2, buttonType, param, buttonID;
            x = Int32.Parse(arguements[1]);
            y = Int32.Parse(arguements[2]);
            gumpID1 = Int32.Parse(arguements[3]);
            gumpID2 = Int32.Parse(arguements[4]);
            buttonType = Int32.Parse(arguements[5]);
            param = Int32.Parse(arguements[6]);
            buttonID = Int32.Parse(arguements[7]);
            buildGumpling(x, y, gumpID1, gumpID2, buttonType, param, buttonID);
        }

        public Button(Control owner, int page, int x, int y, int gumpID1, int gumpID2, int buttonType, int param, int buttonID)
            : this(owner, page)
        {
            buildGumpling(x, y, gumpID1, gumpID2, buttonType, param, buttonID);
        }

        void buildGumpling(int x, int y, int gumpID1, int gumpID2, int buttonType, int param, int buttonID)
        {
            Position = new Vector2(x, y);
            _gumpID1 = gumpID1;
            _gumpID2 = gumpID2;
            ButtonType = (ButtonTypes)buttonType;
            ButtonParameter = param;
            ButtonID = buttonID;
        }

        public override void Update(GameTime gameTime)
        {
            if (_gumpUp == null)
            {
                _gumpUp = Data.Gumps.GetGumpXNA(_gumpID1);
                _gumpDown = Data.Gumps.GetGumpXNA(_gumpID2);
                Size = new Vector2(_gumpUp.Width, _gumpUp.Height);
            }

            if (_gumpID3 != 0 && _gumpOver == null)
            {
                _gumpOver = Data.Gumps.GetGumpXNA(_gumpID3);
            }

            if (_clicked && _manager.MouseOverControl == this)
                _texture = _gumpDown;
            else if (_manager.MouseOverControl == this && _gumpOver != null)
                _texture = _gumpOver;
            else
                _texture = _gumpUp;

            base.Update(gameTime);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Area.X, Area.Y), 0, false);
            base.Draw(spriteBatch);
        }

        protected override bool _hitTest(int x, int y)
        {
            Color[] pixelData;
            pixelData = new Color[1];
            _texture.GetData<Color>(0, new Rectangle(x, y, 1, 1), pixelData, 0, 1);
            if (pixelData[0].A > 0)
                return true;
            else
                return false;
        }

        bool _clicked = false;

        protected override void _mouseDown(int x, int y, MouseButtons button)
        {
            _clicked = true;
        }

        protected override void _mouseUp(int x, int y, MouseButtons button)
        {
            _clicked = false;
        }

        protected override void _mouseClick(int x, int y, MouseButtons button)
        {
            if (button == MouseButtons.LeftButton)
            {
                switch (this.ButtonType)
                {
                    case ButtonTypes.SwitchPage:
                        // switch page
                        ChangePage(this.ButtonParameter);
                        break;
                    case ButtonTypes.Activate:
                        // send response
                        ActivateByButton(this.ButtonID);
                        break;
                }
            }
        }
    }
}
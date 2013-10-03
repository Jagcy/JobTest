using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Question_Four
{
    class GameObject
    {
        public int x;
        public int y;
        public float scalex;
        public float scaley;
        public Texture2D texture;
        public string name;
        public string nametex;
        public bool locked;
        public Vector2 origin;
        private Vector2 size = Vector2.Zero;
        public float width
        {
            get
            {
                size.X = (texture.Width * scalex);
                return size.X;
            }
            set
            {
                size.X = value;
            }
        }
        public float height
        {
            get
            {
                size.Y = (texture.Height * scaley);
                return size.Y;
            }
            set
            {
                size.Y = value;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public GameObject(string name = "", string nametex = "", int px = 0, int py = 0, float pscalex = 0f, float pscaley = 0f, bool locked = false)
        {
            x = px;
            y = py;
            scalex = pscalex;
            scaley = pscaley;
            origin = Vector2.Zero;
            this.name = name;
            this.nametex = nametex;
            this.locked = locked;
        }
        /// <summary>
        /// content loading function
        /// </summary>
        public virtual void LoadContent(ContentManager cm, string name = "")
        {
            if (name == "")
                name = this.nametex;
            texture = cm.Load<Texture2D>(name);
            width = texture.Width * scalex;
            height = texture.Height * scaley;
        }

        /// <summary>
        /// content unloading function
        /// </summary>
        public virtual void UnloadContent()
        {
            texture = null;
        }

        /// <summary>
        /// draw function
        /// </summary>
        public void Draw(SpriteBatch sb, bool special = false, Texture2D ptexture = null, int px = 0, int py = 0)
        {
            sb.Begin();
            if (ptexture == null)
                ptexture = texture;
            if(px == 0)
                px = x;
            if (py == 0)
                py = y;
            if(special)
                sb.Draw(ptexture, new Vector2(px, py), null, Color.White, 0f, origin, scalex, SpriteEffects.None, 0f);
            else
                sb.Draw(ptexture, new Rectangle(px, py, ptexture.Width, ptexture.Height), Color.White);
            sb.End();

        }

    }
}

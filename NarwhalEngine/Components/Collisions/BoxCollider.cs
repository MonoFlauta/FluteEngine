﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class BoxCollider : Collider
    {
        public int width;
        public int height;

        /// <summary>
        /// Creates a box collider with a new transform and default values
        /// </summary>
        public BoxCollider()
        {
            width = 0;
            height = 0;
            transform = new Transform();
        }

        /// <summary>
        /// Creates a box collider with a new transform and defined values
        /// </summary>
        /// <param name="width">Width of the collider</param>
        /// <param name="height">Height of the collider</param>
        public BoxCollider(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a box collider with a given transform and default values
        /// </summary>
        /// <param name="transform">Transform to set</param>
        public BoxCollider(Transform transform)
        {
            width = 0;
            height = 0;
            this.transform = transform;
        }

        /// <summary>
        /// Creates a box collider with a given transform and defined values
        /// </summary>
        /// <param name="transform">Transform to set</param>
        /// <param name="width">Width of the collider</param>
        /// <param name="height">Height of the collider</param>
        public BoxCollider(Transform transform, int width = 0, int height = 0)
        {
            this.transform = transform;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a box collider with a default transform and uses a Texture2D for values
        /// </summary>
        /// <param name="texture">Texture for values</param>
        public BoxCollider(Texture2D texture)
        {
            transform = new Transform();
            width = texture.Width;
            height = texture.Height;
        }

        /// <summary>
        /// Creates a box collider with a given transform and uses a Texture2D for values
        /// </summary>
        /// <param name="texture">Texture for values</param>
        /// <param name="transform">Transform to use</param>
        public BoxCollider(Texture2D texture, Transform transform)
        {
            this.transform = transform;
            width = texture.Width;
            height = texture.Height;
        }

        /// <summary>
        /// Checks collision with a BoxCollider
        /// </summary>
        /// <param name="boxCollider">Box collider to check collision</param>
        /// <returns>If the collision is made</returns>
        public override bool HitTest(BoxCollider boxCollider)
        {
            var thisRect = new Rectangle(
                (int)transform.position.X, 
                (int)transform.position.Y, 
                (int)(width * transform.scale.X), 
                (int)(height * transform.scale.Y));

            var otherRect = new Rectangle(
                (int)boxCollider.transform.position.X,
                (int)boxCollider.transform.position.Y,
                (int)(boxCollider.width * boxCollider.transform.scale.X),
                (int)(boxCollider.height * boxCollider.transform.scale.Y));

            return thisRect.Intersects(otherRect);
        }
    }
}
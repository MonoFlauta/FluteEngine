﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NarwhalEngine
{
    class CameraManager : ContainerObject
    {
        public static CameraManager instance;

        private Material _currentDrawMaterial;
        private SpriteBatch _currentSpriteBatch;
        private bool _hasStarted;

        /// <summary>
        /// Creates the Camera Manager
        /// </summary>
        public CameraManager()
        {
            instance = this;
        }

        /// <summary>
        /// Draws the camera
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            _currentDrawMaterial = null;
            _currentSpriteBatch = spriteBatch;
            _hasStarted = false;
            base.Draw(_currentSpriteBatch);
            spriteBatch.End();
        }

        public void CheckDrawMaterial(Material material)
        {
            if (_hasStarted)
            {
                if (material != _currentDrawMaterial)
                {
                    _currentSpriteBatch.End();
                    _currentDrawMaterial = material;
                    _currentSpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, material.effect);
                }
            }
            else
            {
                _currentSpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, material.effect);
                _hasStarted = true;
                _currentDrawMaterial = material;
            }
        }
    }
}

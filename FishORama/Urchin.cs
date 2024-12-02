using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FishORamaEngineLibrary;

/* FISHORAMA24 | .NET 6.0 | C.Blythe */

namespace FishORama
{
    class Urchin : IDraw
    {
        private string textureID;
        private float xPosition;
        private float yPosition;
        private int xDirection;
        private Screen screen;
        private ITokenManager tokenManager;

        float xSpeed;

        int posScreenWidthMargin;
        int negScreenWidthMargin;

        int urchinWidth;


        Random rand;

        public Urchin(string pTextureID, float pXpos, float pYpos, Screen pScreen, ITokenManager pTokenManager, Random pRand)
        {
            textureID = pTextureID;
            xPosition = pXpos;
            yPosition = pYpos;
            xDirection = 1;
            screen = pScreen;
            tokenManager = pTokenManager;
            rand = pRand;

            xSpeed = rand.Next(1, 4);


            urchinWidth = 180;

            posScreenWidthMargin = screen.width / 2;
            negScreenWidthMargin = -(screen.width / 2);
        }

        public void Update()
        {
            if (xPosition > posScreenWidthMargin || xPosition < negScreenWidthMargin)
            {
                xDirection *= -1;
            }

            xPosition += xSpeed * xDirection;
        }

        public void Draw(IGetAsset pAssetManager, SpriteBatch pSpriteBatch)
        {
            Asset currentAsset = pAssetManager.GetAssetByID(textureID); // Get this token's asset from the AssetManager

            SpriteEffects horizontalDirection; // Stores whether the texture should be flipped horizontally

            if (xDirection < 0)
            {
                // If the token's horizontal direction is negative, draw it reversed
                horizontalDirection = SpriteEffects.FlipHorizontally;
            }
            else
            {
                // If the token's horizontal direction is positive, draw it regularly
                horizontalDirection = SpriteEffects.None;
            }

            // Draw an image centered at the token's position, using the associated texture / position
            pSpriteBatch.Draw(currentAsset.Texture,                                             // Texture
                              new Vector2(xPosition, yPosition * -1),                                // Position
                              null,                                                             // Source rectangle (null)
                              Color.White,                                                      // Background colour
                              0f,                                                               // Rotation (radians)
                              new Vector2(currentAsset.Size.X / 2, currentAsset.Size.Y / 2),    // Origin (places token position at centre of sprite)
                              new Vector2(1, 1),                                                // scale (resizes sprite)
                              horizontalDirection,                                              // Sprite effect (used to reverse image - see above)
                              1);                                                               // Layer depth
        }
    }
}

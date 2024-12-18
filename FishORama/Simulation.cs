﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FishORamaEngineLibrary;

/* FISHORAMA24 | .NET 6.0 | C.Blythe */

namespace FishORama
{
    /// CLASS: Simulation class - the main class users code in to set up a FishORama simulation
    /// All tokens to be displayed in the scene are added here
    public class Simulation : IUpdate, ILoadContent
    {
        // CLASS VARIABLES
        // Variables store the information for the class
        private IKernel kernel;                 // Holds a reference to the game engine kernel which calls the draw method for every token you add to it
        private Screen screen;                  // Holds a reference to the screeen dimensions (width, height)
        private ITokenManager tokenManager;     // Holds a reference to the TokenManager - for access to ChickenLeg variable

        /// PROPERTIES
        public ITokenManager TokenManager      // Property to access chickenLeg variable
        {
            set { tokenManager = value; }
        }

        // *** ADD YOUR CLASS VARIABLES HERE ***
        // Variables to hold fish will be declared here
        OrangeFish orangeFish;
        Piranha piranha;
        Urchin[] urchins = new Urchin[3];
        Seahorse[] seahorses = new Seahorse[5];
        Random rand;




        /// CONSTRUCTOR - for the Simulation class - run once only when an object of the Simulation class is INSTANTIATED (created)
        /// Use constructors to set up the state of a class
        public Simulation(IKernel pKernel)
        {
            kernel = pKernel;                   // Stores the game engine kernel which is passed to the constructor when this class is created
            screen = kernel.Screen;             // Sets the screen variable in Simulation so the screen dimensions are accessible

            // *** ADD OTHER INITIALISATION (class setup) CODE HERE ***
            rand = new Random();



        }

        /// METHOD: LoadContent - called once at start of program
        /// Create all token objects and 'insert' them into the FishORama engine
        public void LoadContent(IGetAsset pAssetManager)
        {
            // *** ADD YOUR NEW TOKEN CREATION CODE HERE ***
            // Code to create fish tokens and assign to thier variables goes here
            // Remember to insert each token into the kernel
            int urchinHeight = 112;

            int xPos = rand.Next(-screen.width / 2, screen.width / 2 + 1);
            int yPos = rand.Next(-screen.height / 2, screen.height / 2 + 1);
            orangeFish = new OrangeFish("OrangeFish", xPos, yPos, screen, tokenManager, rand);
            kernel.InsertToken(orangeFish);

            xPos = rand.Next(-screen.width / 2, screen.width / 2 + 1);
            yPos = rand.Next(screen.height * 1/3, screen.height / 2 + 1);
            piranha = new Piranha("Piranha1", xPos, yPos, screen, tokenManager, rand);
            kernel.InsertToken(piranha);

            for (int i = 0; i < seahorses.Length; i++)
            {
                xPos = rand.Next(-screen.width / 2, screen.width / 2 + 1);
                yPos = rand.Next(-screen.height / 2, screen.height / 2 + 1);

                seahorses[i] = new Seahorse("Seahorse", xPos, yPos, screen, tokenManager, rand);
                kernel.InsertToken(seahorses[i]);
            }

            for (int i = 0; i < urchins.Length; i++)
            {
                xPos = rand.Next(-screen.width / 2, screen.width / 2 + 1);
                yPos = rand.Next(-(screen.height - urchinHeight) / 2, -(screen.height - urchinHeight) / 4);

                urchins[i] = new Urchin("Urchin", xPos, yPos, screen, tokenManager, rand);
                kernel.InsertToken(urchins[i]);
            }


        }

        /// METHOD: Update - called 60 times a second by the FishORama engine when the program is running
        /// Add all tokens so Update is called on them regularly
        public void Update(GameTime gameTime)
        {

            // *** ADD YOUR UPDATE CODE HERE ***
            // Each fish object (sitting in a variable) must have Update() called on it here
            orangeFish.Update();

            piranha.Update();

            for (int i = 0; i < seahorses.Length; i++)
            {
                seahorses[i].Update();
            }

            for (int i = 0; i < urchins.Length; i++)
            {
                urchins[i].Update();
            }
        }
    }
}

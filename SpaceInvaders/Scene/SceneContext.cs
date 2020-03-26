using System;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public enum Scene
        {
            Select,
            SinglePlay,
            MultiPlay,
            HighScore,
            Instructions,
            Aliens,
            Credits,
            Over
        }

        private SceneContext()
        {
            // reserve the states
            this.poSceneSelect = new SceneSelect();
            this.poScenePlay = new ScenePlay();
            this.poSceneOver = new SceneOver();
            this.poSceneHighScore = new SceneHighScores();
            this.poSceneInstructions = new SceneInstructions();
            this.poSceneAliens = new SceneAlien();
            this.poSceneCredits = new SceneCredits();

            // initialize to the select state
            this.pSceneState = this.poSceneSelect;
            this.pSceneState.Transition();
        }

        public static SceneContext Create()
        {
            instance = new SceneContext();
            return instance;
        }

        public static SceneState GetState()
        {
            return instance.pSceneState;
        }

        public static void SetState( Scene eScene)
        {
            switch(eScene)
            {
                case Scene.Select:
                    instance.pSceneState = instance.poSceneSelect;
                    instance.pSceneState.Transition();
                    break;

                case Scene.SinglePlay:
                    instance.pSceneState = instance.poScenePlay;
                    instance.pSceneState.Transition();
                    break;

                case Scene.MultiPlay:
                    instance.pSceneState = instance.poScenePlay;
                    bMultiplayer = true;
                    instance.pSceneState.Transition();
                    break;

                case Scene.HighScore:
                    instance.pSceneState = instance.poSceneHighScore;
                    instance.pSceneState.Transition();
                    break;

                case Scene.Instructions:
                    instance.pSceneState = instance.poSceneInstructions;
                    instance.pSceneState.Transition();
                    break;

                case Scene.Aliens:
                    instance.pSceneState = instance.poSceneAliens;
                    instance.pSceneState.Transition();
                    break;

                case Scene.Credits:
                    instance.pSceneState = instance.poSceneCredits;
                    instance.pSceneState.Transition();
                    break;

                case Scene.Over:
                    instance.pSceneState = instance.poSceneOver;
                    instance.pSceneState.Transition();
                    break;

            }
        }

        // ----------------------------------------------------
        // Data: 
        // -------------------------------------------o---------
        SceneState pSceneState;
        SceneSelect poSceneSelect;
        SceneOver poSceneOver;
        SceneHighScores poSceneHighScore;
        SceneInstructions poSceneInstructions;
        SceneAlien poSceneAliens;
        ScenePlay poScenePlay;
        SceneCredits poSceneCredits;
        public static SceneContext instance;
        public static bool bMultiplayer = false;
        
    }
}

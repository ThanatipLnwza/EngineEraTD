using UnityEngine;
using UnityEngine.UI;

/****************************************************************************************************************************
 * 
 *  --{   Leaderboard Manager   }--
 *							  
 *	Leaderboard Manager Example
 *       This is not needed for the asset to work, it is just used in the example scene.
 *       Please do not edit this code as it will break the example scene provided with this asset.
 *			
 *  Written by:
 *      Jonathan Carter
 *      E: jonathan@carter.games
 *      W: https://jonathan.carter.games
 *		
 *  Version: 1.0.4
 *	Last Updated: 05/02/2021 (d/m/y)						
 * 
****************************************************************************************************************************/

namespace CarterGames.Assets.LeaderboardManager.Example
{
    /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   
    /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public class LeaderboardManagerExample : MonoBehaviour
    {
        /// <summary>
        /// The player name input field text component.
        /// </summary>
        public LeaderboardDisplay displayScript;

        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Leaderboard Manager Example | Calls the add to leaderboard method and passes through the values from the input fields.
        /// (NOTE: float.phase() is used here as we are getting a text component, normally you'd have the float value from the game's score to use instead)
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AddToLB()
        {
            LeaderboardManager.AddToLeaderboard(DataManager.instance.playerName, DataManager.instance.playerScore);
        }


        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Leaderboard Manager Example | Calls the remove from leaderboard method and passes through the values from the input field.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void RemoveFromLB()
        {
            LeaderboardManager.RemoveEntryFromLeaderboard(DataManager.instance.playerName, DataManager.instance.playerScore);
        }


        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Leaderboard Manager Example | Calls the update leaderboard method on the leaderboard display script.
        /// Needs a reference the leaderboard display script to work.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void UpdateLBDisplay()
        {
            displayScript.UpdateLeaderboardDisplay();
        }


        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Leaderboard Manager Example | Calls the clear leaderboard data method from the leaderboard manager.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void ClearLBData()
        {
            displayScript.ClearLeaderboard();
            LeaderboardManager.ClearLeaderboardData();
        }


        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Leaderboard Manager Example | Calls the clear leaderboard method on the display script.
        /// </summary>
        /// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void ClearLBDisplay()
        {
            displayScript.ClearLeaderboard();
        }
    }
}
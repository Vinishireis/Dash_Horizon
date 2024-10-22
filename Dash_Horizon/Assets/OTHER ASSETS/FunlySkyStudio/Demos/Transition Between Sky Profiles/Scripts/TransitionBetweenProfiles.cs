using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Funly.SkyStudio
{
    /// <summary>
    /// This is an example script showing you how to trigger a SkyProfile transition. In this demo scene,
    /// when you click the 2D canvas button to "Toggle Profiles" it calls ToggleSkyProfiles() on this class.
    /// All this script is doing is toggling between 2 sky profiles, and letting Sky Studio create a transition
    /// between the various Sky Profile properties. 
    /// </summary>
    public class TransitionBetweenProfiles : MonoBehaviour
    {
        // Some example sky profiles to demo transitioning between.
        public SkyProfile daySkyProfile;
        public SkyProfile nightSkyProfile;

        [Tooltip("How long the transition animation will last.")]
        [Range(0.1f, 30)] public float transitionDuration = 2;

        public TimeOfDayController timeOfDayController;

        private SkyProfile m_CurrentSkyProfile;

        void Start()
        {
            m_CurrentSkyProfile = daySkyProfile;

            if (timeOfDayController == null)
            {
                timeOfDayController = TimeOfDayController.instance;
            }
            
            timeOfDayController.skyProfile = m_CurrentSkyProfile;
        }
    
        // This method is called when the UI button is clicked to change profiles.
        public void ToggleSkyProfiles()
        {
            // If day go to night, else go to day.
            m_CurrentSkyProfile = m_CurrentSkyProfile == daySkyProfile ? nightSkyProfile : daySkyProfile;
            
            // This is what actually triggers the transition to the new Sky Profile.
            timeOfDayController.StartSkyProfileTransition(m_CurrentSkyProfile, transitionDuration);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Get random element from list. Throws exception for empty lists.
        /// </summary>
        /// <typeparam name="T">Generic type parameter of list</typeparam>
        /// <param name="list">list you want to get random element from</param>
        /// <returns>random element from list</returns>
        public static T RandomElement<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Creates audio source for given clip and adds it to the game object. 
        /// </summary>
        /// <param name="obj">game object to which the audio source will be added</param>
        /// <param name="clip">audio clip used</param>
        /// <param name="loop">should sound be looped</param>
        /// <param name="playAwake">should sound be played on awake</param>
        /// <param name="volume">sound volume</param>
        /// <returns></returns>
        public static AudioSource AddAudio(this GameObject obj, AudioClip clip, bool loop, bool playAwake, float volume)
        {
            var newAudio = obj.AddComponent<AudioSource>();
            newAudio.clip = clip;
            newAudio.loop = loop;
            newAudio.playOnAwake = playAwake;
            newAudio.volume = volume;

            return newAudio;
        }
    }
}

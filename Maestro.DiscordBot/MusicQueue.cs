using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Maestro.Core.Models;

namespace Maestro.DiscordBot
{
    public class MusicQueue
    {
        private List<Song> _songs = new();


        #region PROPERTIES
        public List<Song> Songs
        {

            get
            {
                return _songs;
            }
            set
            {
            _songs = value; }
        }
        #endregion //PROPERTIES

        /// <summary>
        /// Adds a song to the tail of the music queue.
        /// </summary>
        /// <param name="song">The song to be added.</param>
        public void AddSong(Song song) => _songs.Add(song);

        /// <summary>
        /// Clears the music queue, removing all songs.
        /// </summary>
        public void ClearQueue() => _songs.Clear();

        /// <summary>
        /// Shuffles the songs in the music queue.
        /// </summary>
        /// <remarks>
        /// This method randomly rearranges the order of the songs in the music queue.
        /// </remarks>
        public void Shuffle()
        {
            _songs = _songs.OrderBy(s => new Random().Next()).ToList();
        }

        /// <summary>
        /// Inserts a song at the front of the music queue.
        /// </summary>
        /// <param name="song">The song to be inserted.</param>
        public void InsertToFront(Song song)
        {
        }

        /// <summary>
        /// Removes a song from the music queue at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the song to be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range of the list</exception>
        public void RemoveSongFrom(int index)
        {
            if (index < 0 || index >= _songs.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range of the list");
            _songs.RemoveAt(index);
        }

        public Song GetSongAt(int index)
        {
            if (index < 0 || index >= _songs.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range of the list");
            return _songs[index];
        }
    }
}
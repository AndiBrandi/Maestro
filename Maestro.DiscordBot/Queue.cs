using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Maestro.Core.Models;

namespace Maestro.DiscordBot
{
    public class Queue
    {
        private List<Song> songs = new();
        
        
        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public bool RemoveSong(Song song)
        {
            return songs.Remove(song);
        }

        public void ClearQueue()
        {
            songs.Clear();
        }

        public void Shuffle()
        {
            var random = new Random();
            songs = songs.OrderBy(s => random.Next()).ToList();
        }
    }
}
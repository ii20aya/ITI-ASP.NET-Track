using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{

    public class Song
    {
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public int Duration { get; set; } 
        public string Genre { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }

        public override string ToString() => $"[{Genre}] {Title} - {Artist} ({Duration}s)";
    }

  
    public class MusicPlaylist : IEnumerable<Song>
    {
        private List<Song> _songs = new List<Song>();

        public void AddSong(Song song) => _songs.Add(song);

     
        public IEnumerator<Song> GetEnumerator() => _songs.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

     
        public IEnumerable<Song> GetSongsByGenre(string genre)
        {
            foreach (var song in _songs)
            {
                if (song.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                {
                    yield return song; 
                }
            }
        }

    
        public IEnumerable<Song> GetLongSongs(int minDuration)
        {
            foreach (var song in _songs)
            {
                if (song.Duration >= minDuration)
                    yield return song;
            }
        }

        
    }

}

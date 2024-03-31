using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace Maestro.Helpers;

internal class SqliteHelper
{
    private static readonly string databasePath =
        Path.Combine(ApplicationData.Current.LocalFolder.Path, "datastorage.sqlite");

    private static readonly string _connectionString = $"Data Source={databasePath};";
    private static SqliteConnection _connection;
    private static readonly object _syncObject = new();

    private SqliteHelper()
    {
    }

    private static SqliteConnection GetConnection()
    {
        //TODO: Error handling
        //TODO: Close Connection on Application close
        if (_connection == null)
        {
            lock (_syncObject)
            {
                if (!File.Exists(databasePath))
                {
                    File.Create(databasePath).Close();
                }

                _connection = new SqliteConnection(_connectionString);
                _connection.Open();
            }
        }

        return _connection;
    }

    /// <summary>
    /// Executes the specified SQL query against the database
    /// </summary>
    /// <param name="databaseQuery"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static SqliteDataReader ExecuteCustomQuery(string databaseQuery)
    {
        SqliteDataReader reader = null;
        try
        {
            var command = new SqliteCommand(databaseQuery, GetConnection());
            command.ExecuteNonQuery();
            reader = command.ExecuteReader();
        }
        catch (SqliteException e)
        {
            Console.WriteLine($"Exception: {e.InnerException}");
        }

        if (reader == null)
        {
            throw new InvalidOperationException("Something went wrong by executing the SQL query");
        }

        return reader;
    }

    public static List<Song> ExecuteGetAllSongsQuery()
    {
        SqliteDataReader result = ExecuteCustomQuery("SELECT * FROM main.song");
        List<Song> x = new();

        while (result.Read())
        {
            x.Add(new Song
            {
                SongID = new Guid(result.GetString(0)),
                SongTitle = result.GetString(1),
                SongDescription = result.GetString(2),
                SongAlbum = result.IsDBNull(3) ? null : result.GetString(3),
                SongArtists = new List<string>(result.GetString(4).Split(";")),
                SongDuration = result.GetInt32(5),
                SongURL = result.GetString(6),
                ThumbnailFilePath = result.IsDBNull(7) ? null : result.GetString(7),
            });
        }

        return x;
    }

    public static List<Playlist> ExecuteGetAllPlaylistsQuery()
    {
        SqliteDataReader result =
            ExecuteCustomQuery(
                "SELECT p.*, s.* FROM main.playlist p " + 
                "join main.map_song_playlist msp on p.id = msp.playlistid " +
                "join main.song s on s.id = msp.songid");
        Dictionary<Guid, Playlist> dict = new();

        while (result.Read())
        {
            //If playlist doesn't exist in Dictionary
            if (!dict.TryGetValue(new Guid(result.GetString(0)), out Playlist p1))
            {
                p1 = new()
                {
                    PlaylistID = new Guid(result.GetString(0)),
                    PlaylistName = result.GetString(1),
                    PlaylistDescription = result.GetString(2),
                    SongList = new List<Song>()
                    {
                        new Song()
                        {
                            SongID = new Guid(result.GetString(3)),
                            SongTitle = GetStringWithNullCheck(4, result),
                            SongDescription = GetStringWithNullCheck(5, result),
                            SongAlbum = GetStringWithNullCheck(6, result),
                            SongArtists = new List<string>(result.GetString(7).Split(";")),
                            SongDuration = GetIntWithNullCheck(8,result),
                            SongURL = result.GetString(9),
                            ThumbnailFilePath = GetStringWithNullCheck(10, result),
                        }
                    }
                };

                dict.Add(p1.PlaylistID, p1);
            }
            else if (dict.TryGetValue(new Guid(result.GetString(0)), out Playlist p2))
            {
                p2.SongList!.Add(new Song
                {
                    SongID = new Guid(result.GetString(3)),
                    SongTitle = GetStringWithNullCheck(4, result),
                    SongDescription = GetStringWithNullCheck(5, result),
                    SongAlbum = GetStringWithNullCheck(6, result),
                    SongArtists = new List<string>(result.GetString(7).Split(";")),
                    SongDuration = GetIntWithNullCheck(8,result),
                    SongURL = result.GetString(9),
                    ThumbnailFilePath = GetStringWithNullCheck(10, result),
                });
                dict[p2.PlaylistID] = p2;
            }
        }

        return dict.Values.ToList();
        
    }

    #region DatabaseNullChecks

    //These Methods are necessary because GetString and GetInt32 throw an Exception if the DB column is NULL, instead of just returning NULL

    /// <summary>
    /// Adds Null-Handling to GetString
    /// </summary>
    /// <returns></returns>
    public static string? GetStringWithNullCheck(int ordinal, SqliteDataReader dataReader)
    {
        return dataReader.IsDBNull(ordinal) ? null : dataReader.GetString(ordinal);
    }

    /// <summary>
    /// Adds Null-Handling to GetInt32
    /// </summary>
    /// <returns>The <see cref="Int32"/> Databaes value </returns>
    public static int? GetIntWithNullCheck(int ordinal, SqliteDataReader dataReader)
    {
        return dataReader.IsDBNull(ordinal) ? null : dataReader.GetInt32(ordinal);
    }

    #endregion
}
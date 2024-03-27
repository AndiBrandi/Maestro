using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace Maestro.Helpers;

internal class SqliteHelper
{
    private static readonly string databasePath =
        Path.Combine(ApplicationData.Current.LocalFolder.Path, "datastorage.sqlite");

    private static readonly string _connectionString = $"Data Source={databasePath};Version=3";
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

    public static SqliteDataReader ExecuteCustomQuery(string databaseQuery)
    {
        SqliteDataReader reader = null;
        try
        {
            using var command = new SqliteCommand(databaseQuery, GetConnection());
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

    public static IEnumerable<Song> ExecuteGetAllSongsQuery()
    {
        var result = ExecuteCustomQuery("SELECT * FROM main.song");

        var a = TimeSpan.FromSeconds(120);

        while (result.Read())
        {
            yield return new Song
            {
                SongID = new Guid(result.GetString(0)),
                SongTitle = result.GetString(1),
                SongDescription = result.GetString(2),
                SongAlbum = result.GetString(3),
                SongArtists = new List<string>(result.GetString(4).Split(";")),
                SongDuration = result.GetInt32(5),
                SongURL = result.GetString(6),
                ThumbnailFilePath = result.GetString(7),
            };
        }
    }

    public static List<Playlist> ExecuteGetAllPlaylistsQuery()
    {

        return null;
    }
    
}
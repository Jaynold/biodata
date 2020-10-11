using System.Threading.Tasks;
using BioData.Data;

namespace BioData.DbRepository
{
    public interface IBioDataRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Biodatas
        Task<Biodata[]> GetAllBioDataAsync();
        Task<Biodata> GetBioDataAsync(string biodataid);
        // // Talks
        // Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false);
        // Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false);

        // // Speakers
        // Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker);
        // Task<Speaker> GetSpeakerAsync(int speakerId);
        // Task<Speaker[]> GetAllSpeakersAsync();

    }
}
using System.Collections.Generic;
using System.Linq;
using VideoCore.Entities;
using VideoCore.Services.Interfaces;

namespace VideoCore.Services
{
    public class MockVideoData : IVideoData
    {
        private IList<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video> {
                new Video {Id=1,Title="Shreck",Genre = Models.Genres.Animated},
                new Video {Id = 2,Title = "Despicable Me",Genre = Models.Genres.Comedy},
                new Video {Id = 3,Title = "Megamind",Genre = Models.Genres.Action}
            };
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }

        public int Commit()
        {
            return 0;
        }
    }
}

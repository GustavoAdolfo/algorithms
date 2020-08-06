
using System;
using System.Collections.Generic;
using VideoCore.Entities;

namespace VideoCore.Services.Interfaces
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
        Video Get(int id);
        void Add(Video newVideo);
        int Commit();
    }
}

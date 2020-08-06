using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VideoCore.Services.Interfaces;
using VideoCore.ViewModels;
using VideoCore.Entities;

namespace VideoCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video => new VideoViewModel {
                Id = video.Id,
                Title = video.Title,
                Genre = video.Genre.ToString()
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Genre = model.Genre.ToString()
            });
        }

        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);
            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            var video = _videos.Get(id);
            if (video == null || !ModelState.IsValid)
            {
                return View(video);
            }
            var entitie = new Video
            {
                Genre = model.Genre,
                Title = model.Title
            };
            _videos.Commit();
            return RedirectToAction("Details", new { id = video.Id });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var entitie = new Video
            {
                Genre = model.Genre,
                Title = model.Title
            };
            _videos.Add(entitie);
            return RedirectToAction("Details", new { id = entitie.Id });
        }
    }
}

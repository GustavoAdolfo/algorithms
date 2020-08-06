using System.ComponentModel.DataAnnotations;
using VideoCore.Models;

namespace VideoCore.ViewModels
{
    public class VideoEditViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Title { get; set; }
        [Display(Name ="Filme Genre")]
        public Genres Genre { get; set; }
    }
}

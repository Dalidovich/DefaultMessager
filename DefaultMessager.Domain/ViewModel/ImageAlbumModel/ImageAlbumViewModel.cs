using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.ImageAlbumModel
{
    public class ImageAlbumViewModel
    {
        public Guid? Id { get; set; }
        public string[] PathPictures { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}

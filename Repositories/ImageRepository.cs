using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WebCamTimeLapse.Repositories;

public class ImageRepository : IImageRepository
{
    private IReadOnlyCollection<Bitmap> _images = Array.Empty<Bitmap>();

    public void Add(Bitmap entity)
    {
        _images = _images
            .Append(entity)
            .ToArray();
    }

    public IReadOnlyCollection<Bitmap> GetAll()
    {
        return _images;
    }

    public void Remove(Bitmap entity)
    {
        _images = _images
            .Where(image => image != entity)
            .ToArray();
    }
}
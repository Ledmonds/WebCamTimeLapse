﻿using System.Collections.Generic;
using System.Drawing;

namespace WebCamTimeLapse.Services.GifServices;

public interface IGifService
{
    void AnimateGifToFile(IEnumerable<Image> images);
}

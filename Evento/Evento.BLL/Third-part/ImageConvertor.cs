using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Evento.BLL.Third_part
{
    public static class ImageConvertor
    {

        public static byte[] ConvertImageToBytes(IFormFile picture)
        {
            byte[] bytes = new byte[0];
            using (var fs1 = picture.OpenReadStream())
            using (var ms1 = new MemoryStream())
            {
                fs1.CopyTo(ms1);
                bytes = ms1.ToArray();
            }
            return bytes;
        }
        public static string ConvertBytesToImage(byte[] bytes) {
            var base64 = Convert.ToBase64String(bytes);
            var imagesrc = string.Format("data:image/jpeg;base64,{0}", base64);
            return imagesrc;
        }


    }
}

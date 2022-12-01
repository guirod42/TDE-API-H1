using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Validations
{
    public static class ImageValidation
    {
        public class ValidImage
        {
            public ValidImage(string message, bool status)
            {
                Message = message;
                Status = status;
            }

            public string Message { get; set; }
            public bool Status { get; set; }
        }
        private static bool Extension(string ext)
        {
            List<string> exts = new List<string>();
            exts.Add("jpg");
            exts.Add("png");
            exts.Add("jpeg");

            if(exts.Contains(ext)) return true;
            else return false;
        }

        public static ValidImage UploadImage(IFormFile image, string imgName)
        {
            int largPx = 1200;
            int compPx = 1200;
            int imgSize = (largPx * compPx) + 100000;

            string[] checkFileExt = image.FileName.Split(".");
            string ext = checkFileExt[1];
            if (image == null || image.Length == 0 || image.Length > imgSize)
            {
                return new ValidImage("Imagem excede o limite de tamanho", false);
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images", imgName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyToAsync(stream);
            }
            if (Extension(ext))
                return new ValidImage("Upload de imagem realizado", true);
            else return new ValidImage("Extensão inválida", false);
        }
    }


}

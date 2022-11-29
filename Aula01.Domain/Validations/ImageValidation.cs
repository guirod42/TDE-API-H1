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
        private static bool Extension(string ext)
        {
            List<string> exts = new List<string>();
            exts.Add("jpg");
            exts.Add("png");
            exts.Add("jpeg");

            if(exts.Contains(ext)) return true;
            else return false;
        }

        public static async Task<ValidImage> UploadImage(IFormFile image, string imgName)
        {
            int largPx = 1200;
            int compPx = 1200;
            int imgSize = (largPx * compPx) + 100000;

            string[] checkFileExt = image.FileName.Split(".");
            string ext = checkFileExt[1];
            if (image == null || image.Length == 0 || image.Length > imgSize)
            {
                return new ValidImage() { Status = false, Message = $"Imagem excede o limite de tamanho" };
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Content/Images", imgName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            if (Extension(ext))
                return new ValidImage() { Status = true, Message = "Upload de imagem realizado" };
            else return new ValidImage() { Status = false, Message = "Extensão inválida" };
        }
    }

    public class ValidImage 
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}

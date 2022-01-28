using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tatu.Marchesan.Ideias.App.Core.Helpers
{
    public static class AnexoHelper
    {
        public static readonly string AnexosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/anexos");

        public static async Task<Tuple<bool, string>> UploadFile(IFormFile file, string imgPrefix)
        {
            if (file.Length <= 0)
            {
                return new Tuple<bool, string>(false, string.Empty);
            }

            if (!Directory.Exists(AnexosPath))
            {
                Directory.CreateDirectory(AnexosPath);
            }

            var path = Path.Combine(AnexosPath, $"{imgPrefix}{file.FileName}");

            if (File.Exists(path))
            {
                return new Tuple<bool, string>(false, "Já existe um arquivo com este nome!");
            }

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream).ConfigureAwait(true);
            }

            return new Tuple<bool, string>(true, string.Empty);
        }

        public static bool DeleteFile(string filename)
        {
            var path = Path.Combine(AnexosPath, filename);

            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);

            return true;
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();

            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
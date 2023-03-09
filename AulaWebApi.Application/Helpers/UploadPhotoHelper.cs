//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AulaWebApi.Application.Helpers
//{
//	public static class UploadPhotoHelper
//	{
//		public static async Task<string> UploadPhoto(IFormFile imagem, string contentRootPath, string hostName)
//		{
//			string urlImagem = "";
//			string uploads = Path.Combine(contentRootPath, "wwwroot", "images");
//			if (imagem != null && imagem.Length > 0)
//			{
//				string filePath = Path.Combine(uploads, imagem.FileName);
//				using (Stream fileStream = new FileStream(filePath, FileMode.Create))
//				{
//					await imagem.CopyToAsync(fileStream);
//				}
//				urlImagem = "https://" + hostName + "/images/" + imagem.FileName;
//			}

//			return urlImagem;
//		}
//	}
//}

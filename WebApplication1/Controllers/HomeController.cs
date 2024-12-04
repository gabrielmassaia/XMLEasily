using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        //private readonly string xmlFolderPath = @"C:\Caminho\Para\Pasta\XML"; // Ajuste para o caminho desejado.

        //public IActionResult Index(string dateFilter, string integratorFilter)
        //{
        //    DateTime.TryParse(dateFilter, out DateTime filterDate);

        //    var files = Directory.GetFiles(xmlFolderPath, "*.xml")
        //        .Select(file => new FileModel
        //        {
        //            FileName = Path.GetFileName(file),
        //            FilePath = file,
        //            LastModified = System.IO.File.GetLastWriteTime(file)
        //        })
        //        .Where(f => (filterDate == DateTime.MinValue || f.LastModified.Date == filterDate) &&
        //                    (string.IsNullOrEmpty(integratorFilter) || f.FileName.Contains(integratorFilter)))
        //        .OrderByDescending(f => f.LastModified)
        //        .ToList();

        //    return View(files);

        public IActionResult Index(string dateFilter, string integratorFilter)
        {
            // Simulando arquivos XML
            var simulatedFiles = Enumerable.Range(1, 10).Select(i => new FileModel
            {
                FileName = $"Cotacao_2024-12-{i:00}.xml",
                FilePath = $"SimulatedPath/Cotacao_2024-12-{i:00}.xml",
                LastModified = DateTime.Now.AddDays(-i)
            }).ToList();

            // Aplicando filtros simulados
            DateTime.TryParse(dateFilter, out DateTime filterDate);

            var filteredFiles = simulatedFiles
                .Where(f => (filterDate == DateTime.MinValue || f.LastModified.Date == filterDate) &&
                            (string.IsNullOrEmpty(integratorFilter) || f.FileName.Contains(integratorFilter)))
                .ToList();

            return View(filteredFiles);
        }

        public IActionResult Download(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                var fileName = Path.GetFileName(filePath);
                return File(System.IO.File.ReadAllBytes(filePath), "application/xml", fileName);
            }
            return NotFound();
        }

        public IActionResult Open(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                var content = System.IO.File.ReadAllText(filePath);
                return Content(content, "text/xml");
            }
            return NotFound();
        }
    }
}

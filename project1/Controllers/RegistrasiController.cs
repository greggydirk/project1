using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;

using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;

namespace project1.Controllers
{
    public class RegistrasiController : Controller
    {
        // GET: Registrasi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Pengguna pengguna)
        {
            PenggunaDAL pengDAL = new PenggunaDAL();
            try
            {
                if (ModelState.IsValid)
                {
                    pengDAL.Refistrasi(pengguna);
                    ViewBag.Pesan = "Data Pengguna berhasil di Tambah ";
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

    }
}
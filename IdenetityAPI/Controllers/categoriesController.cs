using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IdenetityAPI.Models;
using IdenetityAPI.ViewModel;
using System.IO;
using System.Web;

namespace IdenetityAPI.Controllers
{
    [AllowAnonymous]
    public class categoriesController : ApiController
    {
        private IntiteCompaney db = new IntiteCompaney();

        // GET: api/categories
        public IQueryable<category> Getcategories()
        {
            return db.categories;
        }

        // GET: api/categories/5
        [ResponseType(typeof(category))]
        public IHttpActionResult Getcategory(int id)
        {
            category category = db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategory(int id, category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                category.ImgUrl = "./assets/Images/cat.png"; ;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/categories
        [ResponseType(typeof(category))]
        public IHttpActionResult Postcategory(category category)
        {
            category.ImgUrl = "./assets/Images/cat.png";

            db.categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }
        //public IHttpActionResult Postcategory(CategoryViewModel cateView)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(cateView.imageFile.FileName);
        //    string Extention = Path.GetExtension(cateView.imageFile.FileName);
        //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + Extention;
        //    cateView.ImgUrl = "/assets/images/" + fileName;
        //    fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/Images"), fileName);
        //    cateView.imageFile.SaveAs(fileName);

        //    category category = new category
        //    {

        //        CategoryName = cateView.CategoryName,
        //        ImgUrl = cateView.ImgUrl

        //    };



        //    db.categories.Add(category);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        //}

        // DELETE: api/categories/5
        [ResponseType(typeof(category))]
        public IHttpActionResult Deletecategory(int id)
        {
            category category = db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryExists(int id)
        {
            return db.categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}
using BlogWithMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWithMongoDB.Controllers
{
    public class PostController : BaseController
    {
        public ActionResult Index()
        {
            Posts_Model model = new Posts_Model();
            ViewBag.Posts = model.getPosts();
            return View();
        }

        public ActionResult Delete(string Guid)
        {
            Posts_Model model = new Posts_Model();
            model.Delete(Guid);
            return RedirectToAction("Index");
        }

        public ActionResult DetalheNew()
        {
            return View("Detalhe");
        }

        public ActionResult Detalhe(string Guid)
        {
            if (Guid == null)
            {
                Guid = TempData["ObjId"].ToString();
            }
            Posts_Model model = new Posts_Model();
            ViewBag.Id = Guid;
            ViewBag.post = model.Detalhe(Guid);
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Post post = new Post();
            post.titulo = form["titulo"];
            post.texto = form["texto"];
            post.data = Convert.ToString(DateTime.Now);
            string tags = form["tags"];
            char[] delimitadores = { ' ', ',', '.', ';' };
            string[] TagsString = tags.Split(delimitadores);

            foreach (String tagtexto in TagsString)
            {
                post.Tags.Add(new Tag() { tag = tagtexto });
            }

            Posts_Model model = new Posts_Model();
            model.Insert(post);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateComment(FormCollection form)
        {
            Posts_Model model = new Posts_Model();
            model.CreateComment(form["id"].ToString(),
            new Comentario()
            {
                usuario = form["usuario"].ToString(),
                texto = form["comentario"].ToString(),
                data = Convert.ToString(DateTime.Now)
            });
            TempData["ObjId"] = form["id"].ToString();
            return RedirectToAction("Detalhe");
        }
    }
}
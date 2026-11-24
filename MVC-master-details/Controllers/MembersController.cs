using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test111.Models;
using System.Data.Entity;
using test111.ViewModels;
using System.IO;

namespace test111.Controllers
{
    public class MembersController : Controller
    {
        private readonly aaaFahad11Entities db = new aaaFahad11Entities();
        [HttpGet]
        public ActionResult Index()
        {
            var mem = db.Members.Include(c => c.Category).Include(b => b.BorrowedItems).ToList();
            return View(mem);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Member mem = db.Members.Find(id);
            if(mem == null) return HttpNotFound();
            db.Entry(mem).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
          MemberViewModel mem = new MemberViewModel();
            mem.Categorys = db.Categories.ToList();
            ViewBag.CategoryId = new SelectList(mem.Categorys, "CategoryId", "CategoryName", mem.CategoryId);
            return View(mem);
        }
        [HttpPost]
        public ActionResult Create(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uqImg = GetImage(model.ProfileFile);
                Member newMem = new Member
                {
                    MemberName = model.MemberName,
                    MobileNo = model.MobileNo,
                    IssueDate = model.IssueDate,
                    MembershipFee = model.MembershipFee,
                    IsStudent = model.IsStudent,
                    CategoryId = model.CategoryId,
                    ImageUrl = uqImg,

                };
                db.Members.Add(newMem);
                db.SaveChanges();
                if (model.BorrowedItems != null)
                {
                    foreach (var i in model.BorrowedItems)
                    {
                        db.BorrowedItems.Add(new BorrowedItem
                        {
                            BookName = i.BookName,
                            AuthorName = i.AuthorName,
                            MemberId = newMem.MemberId,
                        });
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, message = "Successfull" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Validation Failed", errors = errors });
        }

        private string GetImage(HttpPostedFileBase profileFile)
        {
            string image = "";
            if (profileFile != null)
            {
                image=Path.Combine("/images/",Guid.NewGuid().ToString() + Path.GetExtension(profileFile.FileName));
                profileFile.SaveAs(Server.MapPath(image));
            }
            return image;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var member = db.Members.Include(b => b.BorrowedItems).Include(c => c.Category).Where(m => m.MemberId == id).FirstOrDefault();
            if (member == null) return HttpNotFound("Member not found");

            var viewModel = new MemberViewModel
            {
                MemberId = member.MemberId,
                MemberName = member.MemberName,
                IssueDate = member.IssueDate,
                IsStudent = member.IsStudent,
                MobileNo = member.MobileNo,
                MembershipFee = member.MembershipFee,
                CategoryId = member.CategoryId,
                ImageUrl = member.ImageUrl,
                BorrowedItems = member.BorrowedItems.ToList(),
                Categorys = db.Categories.ToList(),
            };
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName", member.CategoryId);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(MemberViewModel member, string OldImageUrl)
        {
            Member domObj = db.Members.Include(b => b.BorrowedItems).Include(c => c.Category).Where(m => m.MemberId == member.MemberId).FirstOrDefault();

            if (domObj != null)
            {
                domObj.MemberName = member.MemberName;
                domObj.IssueDate = member.IssueDate;
                domObj.IsStudent = member.IsStudent;
                domObj.MobileNo = member.MobileNo;
                domObj.MembershipFee = member.MembershipFee;
                domObj.CategoryId = member.CategoryId;
                domObj.ImageUrl = member.ImageUrl;

                if (member.ProfileFile != null)
                {
                    string uniqueFileName = GetImage(member.ProfileFile);
                    domObj.ImageUrl = uniqueFileName;
                }
                else
                {
                    domObj.ImageUrl = OldImageUrl;
                }
                var existingItems = db.BorrowedItems.Where(m => m.MemberId == domObj.MemberId).ToList();
                db.BorrowedItems.RemoveRange(existingItems);

                foreach (var m in member.BorrowedItems)
                {
                    db.BorrowedItems.Add(new BorrowedItem
                    {
                        MemberId = domObj.MemberId,
                        BookName = m.BookName,
                        AuthorName = m.AuthorName
                    });
                }
                db.SaveChanges();
                return Json(new { success = true, message = "Member updated successfully" });
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName", member.CategoryId);
            return Json(new { success = false, message = "Failed to update Member" });
        }
    }
}
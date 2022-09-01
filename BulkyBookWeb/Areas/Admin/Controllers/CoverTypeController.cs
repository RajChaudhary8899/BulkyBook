
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
    public class CoverTypeController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        // To create constructor type "ctor" double tab 

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost] // post attribute
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
           
            if (ModelState.IsValid)
            {


                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //update
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var CoverTypeToDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            

            if (CoverTypeToDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeToDbFirst);
        }

        //upadte
        [HttpPost] // post attribute
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
           
            if (ModelState.IsValid)
            {


                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType update successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //update
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var CoverTypeToDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
         

            if (CoverTypeToDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeToDbFirst);
        }

        //upadte
        [HttpPost] // post attribute
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully";
            return RedirectToAction("Index");


        }
    }


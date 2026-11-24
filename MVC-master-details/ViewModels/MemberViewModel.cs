using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test111.Models;

namespace test111.ViewModels
{
    public class MemberViewModel
    {

        public int MemberId { get; set; }
        [Display(Name = "Member Name")]
        [Required(ErrorMessage = "Member Name required")]
        [StringLength(30, MinimumLength = 2)]
        public string MemberName { get; set; }
        [Display(Name = "Mobile No")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Valid Mobile No(10-11)")]
        public string MobileNo { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage = "MemberShip Fee must be within 100000")]
        [Display(Name = "MemberShip Fee")]
        public decimal MembershipFee { get; set; }
        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString ="{0:yyyy-MM-dd}")]
        public System.DateTime IssueDate { get; set; }=DateTime.Now;

        [Display(Name = "Student?")]
        public bool IsStudent { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Profile Picture")]
        public HttpPostedFileBase ProfileFile { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

 
        public virtual IList<BorrowedItem> BorrowedItems { get; set; }=new List<BorrowedItem>();
        public virtual IList<Category> Categorys { get; set; }
    }
}
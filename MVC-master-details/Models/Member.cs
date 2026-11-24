using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test111.Models
{
    public partial class Member
    {
        public Member()
        {
            this.BorrowedItems = new HashSet<BorrowedItem>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MobileNo { get; set; }
        public decimal MembershipFee { get; set; }
        public System.DateTime IssueDate { get; set; }
        public bool IsStudent { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<BorrowedItem> BorrowedItems { get; set; }
        public virtual Category Category { get; set; }
    }


    public partial class Category
    {
        public Category()
        {
            this.Members = new HashSet<Member>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }


    public partial class BorrowedItem
    {
        public int BorrowedItemId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
    }

    public partial class aaaFahad11Entities : DbContext
    {
        public aaaFahad11Entities()
            : base("name=aaaFahad11Entities")
        {
        }

        public virtual DbSet<BorrowedItem> BorrowedItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }

}
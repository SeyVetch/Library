//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Issue = new HashSet<Issue>();
            this.Genre = new HashSet<Genre>();
            this.Author = new HashSet<Author>();
        }
    
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public System.DateTime DateRelease { get; set; }
        public int PageQty { get; set; }
        public bool IssueStatus { get; set; }
        public int SectionID { get; set; }
        public int PublishHouseID { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public string Authors { get
                {
                string res = "";
                foreach (EF.Author A in Author)
                {
                    res += " " + A.LastName;
                }
                res.Trim();
                return res;
                } 
        }
    
        public virtual PublishHouse PublishHouse { get; set; }
        public virtual Section Section { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Issue> Issue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> Genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Author { get; set; }
    }
}

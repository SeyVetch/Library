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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library.ClassHelper;
    using Library.EF;

    public partial class Issue
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int BookID { get; set; }
        public System.DateTime DateIssue { get; set; }
        public System.DateTime DateReturn { get; set; }
        public Nullable<System.DateTime> DateTurnIn { get; set; }
        public Nullable<int> WorkerID { get; set; }
        public bool IsPaidFor { get; set; }
        public double Debt {
            get
            {
                return DebtClass.Debt((double)AppData.Context.Book.FirstOrDefault(i => i.ID == this.BookID).Price, this.DateReturn);
            }
        }
        
        public virtual Book Book { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

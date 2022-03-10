using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ClassHelper;
using Library.EF;

namespace Library.ClassHelper
{
    class DebtClass
    {
        public static double DebtClient(int IDClient)
        {
            var issues = AppData.Context.Issue.ToList().Where(i => i.ClientID == IDClient && i.IsPaidFor);
            var books = AppData.Context.Book.ToList();
            double result = 0;
 
            foreach (Issue issue in issues)
            {
                DateTime dateReturn = issue.DateReturn;
                DateTime? dateTurnIn = issue.DateTurnIn;
                DateTime dateEnd;
                if (dateTurnIn == null)
                {
                    dateEnd = DateTime.Now;
                }
                else
                {
                    dateEnd = (DateTime)dateTurnIn;
                }
                TimeSpan interval = dateEnd - dateReturn;
                double days = interval.TotalDays;
                if (days > 30)
                {
                    int BookID = issue.BookID;
                    Book book = books.FirstOrDefault(i => i.ID == BookID);
                    double price = (double)book.Price;
                    result += price / 100 * (days - 30);
                }
            }

            return result;
        }
        public static double Debt(double bookPrice, DateTime dateStart)
        {
            return bookPrice / 100 * ((int)(DateTime.Now - dateStart).TotalDays - 30);
        }
    }
}

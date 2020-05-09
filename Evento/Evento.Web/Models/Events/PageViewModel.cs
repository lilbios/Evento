using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web.Models.Events
{
    public class PageViewModel
    {
        public int CurrentPageNumber { get; set; }
        public int TotalPageNumber { get; set; }
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            CurrentPageNumber = pageNumber;
            TotalPageNumber = (int)Math.Round(count/pageSize + 0.0);
        }

        public bool HasPrevious => CurrentPageNumber > 1;
        public bool HasNext => CurrentPageNumber < TotalPageNumber;
    }
}

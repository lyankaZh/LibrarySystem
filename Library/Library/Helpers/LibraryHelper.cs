using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repository;

namespace Library.Helpers
{
    public static class LibraryHelper
    {
        public static bool IsInLibrary(Book book, IUnitOfWork unitOfWork)
        {
            return !unitOfWork.BorrowInfoRepository.Get().Any(x => x.Book == book && x.ReturningDate == null);
        }

        //public static bool IsDeptor(Reader reader, IUnitOfWork unitOfWork)
        //{
        //    return !unitOfWork.BorrowInfoRepository.Get().Any(x => x.Reader == reader && x.ReturningDate == null);
        //}
    }
}

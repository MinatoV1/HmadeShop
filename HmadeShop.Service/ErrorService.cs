using HmadeShop.Data.Infrastructure;
using HmadeShop.Data.Responsitories;
using HmadeShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void Save();
    }
    public class ErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOFWork;

        public ErrorService(IErrorRepository errorReponsitory, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorReponsitory;
            this._unitOFWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }
        public void Save()
        {
            _unitOFWork.Commit();
        }

    }
}

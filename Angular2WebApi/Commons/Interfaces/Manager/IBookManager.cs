using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.DTOs;
using Commons.Entities;
using Commons.Interfaces.Manager.baseManager;

namespace Commons.Interfaces.Manager
{
    public interface IBookManager : IBaseManager<BookDto>
    {
    }
}

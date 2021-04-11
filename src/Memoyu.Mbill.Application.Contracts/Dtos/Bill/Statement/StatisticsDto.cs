using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memoyu.Mbill.Application.Contracts.Dtos.Bill.Statement
{
    public class StatisticsDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Data { get; set; }
    }
}
